using AutoMapper;
using BlazorPersonalWebsite.DataAccess.Mappings;
using BlazorPersonalWebsite.EntityFramework;
using BlazorPersonalWebsite.Models;
using BlazorPersonalWebsite.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPersonalWebsite.DataAccess
{
    public class WoodworkProjectRepository : IWoodworkProjectRepository
    {
        private readonly WebsiteContext _dbContext;
        private readonly IMapper _mapper;

        public WoodworkProjectRepository(WebsiteContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = new MapperConfiguration(cnf =>
                    cnf.AddProfile<WoodworkProjectProfile>())
                .CreateMapper();
        }

        public async Task<WoodworkProject> GetWoodworkProjectAsync(string projectRef)
        {
            return await this._dbContext
                .WoodworkProjects
                .Include(sp => sp.Images)
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.ProjectRef == projectRef);
        }

        public async Task<List<WoodworkProject>>ListWoodworkProjectsAsync()
        {
            return await this._dbContext
                .WoodworkProjects
                .Include(sp => sp.Images)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<WoodworkProject> AddWoodworkProjectAsync(WoodworkProjectCreateModel createModel)
        {
            var WoodworkProject = _mapper.Map<WoodworkProject>(createModel);

            await this._dbContext.WoodworkProjects.AddAsync(WoodworkProject);
            await this._dbContext.SaveChangesAsync();

            return await this.GetWoodworkProjectAsync(createModel.ProjectRef);
        }

        public async Task<WoodworkProject> UpdateWoodworkProjectAsync(string projectRef, WoodworkProjectUpdateModel updateModel)
        {
            var WoodworkProject = _mapper.Map<WoodworkProject>(updateModel);

            var existingProject = await GetWoodworkProjectAsync(projectRef);

            WoodworkProject.Id = existingProject.Id;
            WoodworkProject.ProjectRef = projectRef;

            WoodworkProject.Images.ForEach(img =>
            {
                img.WoodworkProjectImageId = WoodworkProject.Images.Where(upImg => img.ImageRef == upImg.ImageRef).First().WoodworkProjectImageId;
            });

            foreach (var image in existingProject.Images)
            {
                var exists = updateModel.Images.Exists(img => img.ImageRef == image.ImageRef);
            }

            this._dbContext.WoodworkProjects.Update(WoodworkProject);
            await this._dbContext.SaveChangesAsync();

            return await this.GetWoodworkProjectAsync(projectRef);
        }

        public async Task<WoodworkProject> DeleteWoodworkProjectImageAsync(string projectRef, string imageRef)
        {
            var existingProject = await GetWoodworkProjectAsync(projectRef);

            var imageToDelete = existingProject.Images.Where(img => img.ImageRef == imageRef).FirstOrDefault();

            this._dbContext.Attach(imageToDelete).State = EntityState.Deleted;

            await this._dbContext.SaveChangesAsync();

            return await this.GetWoodworkProjectAsync(projectRef);
        }
    }
}
