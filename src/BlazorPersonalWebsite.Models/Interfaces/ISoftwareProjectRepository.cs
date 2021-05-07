using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPersonalWebsite.Models.Interfaces
{
    public interface ISoftwareProjectRepository
    {
        public Task<List<SoftwareProject>> ListSoftwareProjectsAsync();

        public Task<SoftwareProject> GetSoftwareProjectAsync(string uniqueRef);

        public Task<SoftwareProject> AddSoftwareProjectAsync(SoftwareProjectCreateModel createModel);

        public Task<SoftwareProject> UpdateSoftwareProjectAsync(string projectRef, SoftwareProjectUpdateModel updateModel);

        public Task<SoftwareProject> DeleteSoftwareProjectImageAsync(string projectRef, string imageRef);
    }
}
