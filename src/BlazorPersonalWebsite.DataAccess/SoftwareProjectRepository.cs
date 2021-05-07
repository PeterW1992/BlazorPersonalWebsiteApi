using BlazorPersonalWebsite.Models;
using BlazorPersonalWebsite.Models.Interfaces;
using System.Collections.Generic;
using BlazorPersonalWebsite.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using BlazorPersonalWebsite.DataAccess.Mappings;

namespace BlazorPersonalWebsite.DataAccess
{
    public class SoftwareProjectRepository : ISoftwareProjectRepository
    {
        private readonly WebsiteContext _dbContext;
        private readonly IMapper _mapper;

        public SoftwareProjectRepository(WebsiteContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = new MapperConfiguration(cnf =>
                    cnf.AddProfile<SoftwareProjectProfile>())
                .CreateMapper();
        }

        public async Task<SoftwareProject> AddSoftwareProjectAsync(SoftwareProjectCreateModel createModel)
        {
            var softwareProject = _mapper.Map<SoftwareProject>(createModel);

            await this._dbContext.SoftwareProjects.AddAsync(softwareProject);
            await this._dbContext.SaveChangesAsync();

            return await this.GetSoftwareProjectAsync(createModel.ProjectRef);
        }

        public async Task<SoftwareProject> GetSoftwareProjectAsync(string projectRef)
        {
            return await this._dbContext
                .SoftwareProjects
                .AsNoTracking()
                .Include(sp => sp.Images)
                .SingleOrDefaultAsync(sp => sp.ProjectRef == projectRef);
        }

        public async Task<List<SoftwareProject>> ListSoftwareProjectsAsync()
        {
            return await this._dbContext
                    .SoftwareProjects
                    .Include(sp => sp.Images)
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<SoftwareProject> UpdateSoftwareProjectAsync(string projectRef, SoftwareProjectUpdateModel updateModel)
        {
            var softwareProject = _mapper.Map<SoftwareProject>(updateModel);

            var existingProject = await GetSoftwareProjectAsync(projectRef);

            softwareProject.Id = existingProject.Id;
            softwareProject.ProjectRef = projectRef;
            
            softwareProject.Images.ForEach(img =>
            {
                img.SoftwareProjectImageId = softwareProject.Images.Where(upImg => img.ImageRef == upImg.ImageRef).First().SoftwareProjectImageId;
            });

            foreach (var image in existingProject.Images)
            {
                var exists = updateModel.Images.Exists(img => img.ImageRef == image.ImageRef);
            }

            this._dbContext.SoftwareProjects.Update(softwareProject);
            await this._dbContext.SaveChangesAsync();

            return await this.GetSoftwareProjectAsync(projectRef);
        }

        public async Task<SoftwareProject> DeleteSoftwareProjectImageAsync(string projectRef, string imageRef)
        {
            var existingProject = await GetSoftwareProjectAsync(projectRef);

            var imageToDelete = existingProject.Images.Where(img => img.ImageRef == imageRef).FirstOrDefault();

            this._dbContext.Attach(imageToDelete).State = EntityState.Deleted;

            await this._dbContext.SaveChangesAsync();

            return await this.GetSoftwareProjectAsync(projectRef);
        }
    }
}
