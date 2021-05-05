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

        public WoodworkProjectRepository(WebsiteContext dbContext)
        {
            _dbContext = dbContext;
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
    }
}
