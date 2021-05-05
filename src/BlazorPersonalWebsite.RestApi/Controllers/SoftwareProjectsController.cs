using AutoMapper;
using BlazorPersonalWebsite.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPersonalWebsite.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoftwareProjectsController : ControllerBase
    {
        private ISoftwareProjectRepository _repo;
        private IMapper _mapper;

        public SoftwareProjectsController(ISoftwareProjectRepository softwareProjectRepository, IMapper mapper)
        {
            _repo = softwareProjectRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RestApi.Models.SoftwareProject>> Get(string projectRef)
        {
            if (string.IsNullOrEmpty(projectRef))
            {
                var softwareProjects = await _repo.ListSoftwareProjectsAsync();
                return _mapper.Map<List<Models.SoftwareProject>>(softwareProjects);
            }

            var softwareProject = await _repo.GetSoftwareProjectAsync(projectRef);

            if (softwareProject == null)
            {
                return new List<RestApi.Models.SoftwareProject>();
            } else
            {
                return new List<RestApi.Models.SoftwareProject> { _mapper.Map<Models.SoftwareProject>(softwareProject) };
            }
        }
    }
}
