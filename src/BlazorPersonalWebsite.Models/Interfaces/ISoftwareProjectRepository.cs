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
    }
}
