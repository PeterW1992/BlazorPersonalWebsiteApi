using BlazorPersonalWebsite.Models;
using BlazorPersonalWebsite.Models.Interfaces;
using System.Collections.Generic;
using BlazorPersonalWebsite.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlazorPersonalWebsite.DataAccess
{
    public class SoftwareProjectRepository : ISoftwareProjectRepository
    {
        private readonly WebsiteContext _dbContext;

        public SoftwareProjectRepository(WebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SoftwareProject> GetSoftwareProjectAsync(string projectRef)
        {
            return await this._dbContext
                .SoftwareProjects
                .Include(sp => sp.Images)
                .AsNoTracking()
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
    }
}
