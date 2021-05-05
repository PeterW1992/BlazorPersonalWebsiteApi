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
    public class WoodworkProjectsController : ControllerBase
    {
        private IWoodworkProjectRepository _repo;
        private IMapper _mapper;

        public WoodworkProjectsController(IWoodworkProjectRepository woodworkProjectRepository, IMapper mapper)
        {
            _repo = woodworkProjectRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RestApi.Models.WoodworkProject>> Get(string projectRef)
        {
            if (string.IsNullOrEmpty(projectRef))
            {
                var softwareProjects = await _repo.ListWoodworkProjectsAsync();
                return _mapper.Map<List<Models.WoodworkProject>>(softwareProjects);
            }

            var project = await _repo.GetWoodworkProjectAsync(projectRef);

            if (project == null)
            {
                return new List<RestApi.Models.WoodworkProject>();
            } else
            {
                return new List<RestApi.Models.WoodworkProject> { _mapper.Map<Models.WoodworkProject>(project) };
            }
        }
    }
}
