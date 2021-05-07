using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPersonalWebsite.Models.Interfaces
{
    public interface IWoodworkProjectRepository
    {
        public Task<List<WoodworkProject>> ListWoodworkProjectsAsync();

        public Task<WoodworkProject> GetWoodworkProjectAsync(string uniqueRef);

        public Task<WoodworkProject> AddWoodworkProjectAsync(WoodworkProjectCreateModel createModel);

        public Task<WoodworkProject> UpdateWoodworkProjectAsync(string projectRef, WoodworkProjectUpdateModel updateModel);

        public Task<WoodworkProject> DeleteWoodworkProjectImageAsync(string projectRef, string imageRef);

    }
}
