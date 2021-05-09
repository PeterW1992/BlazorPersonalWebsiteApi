using AutoMapper;
using BlazorPersonalWebsite.Models;
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
        [Route("{projectRef}")]
        public async Task<IEnumerable<RestApi.Models.WoodworkProject>> Get(string projectRef)
        {
            var project = await _repo.GetWoodworkProjectAsync(projectRef);

            if (project == null)
            {
                return new List<RestApi.Models.WoodworkProject>();
            }
            else
            {
                return new List<RestApi.Models.WoodworkProject> { _mapper.Map<Models.WoodworkProject>(project) };
            }
        }

        [HttpGet]
        public async Task<IEnumerable<RestApi.Models.WoodworkProject>> GetAllAsync()
        {
            var WoodworkProjects = await _repo.ListWoodworkProjectsAsync();
            return _mapper.Map<List<Models.WoodworkProject>>(WoodworkProjects);
        }

        [HttpPost]
        public async Task<RestApi.Models.WoodworkProject> PostWoodworkProject(WoodworkProjectCreateModel createModel)
        {
            var newWoodworkProject = await _repo.AddWoodworkProjectAsync(createModel);
            return _mapper.Map<Models.WoodworkProject>(newWoodworkProject);
        }

        [HttpPut]
        [Route("{projectRef}")]
        public async Task<RestApi.Models.WoodworkProject> UpdateWoodworkProject(WoodworkProjectUpdateModel updateModel, string projectRef)
        {
            var updatedWoodworkProject = await _repo.UpdateWoodworkProjectAsync(projectRef, updateModel);
            return _mapper.Map<Models.WoodworkProject>(updatedWoodworkProject);
        }

        [HttpGet]
        [Route("{projectRef}/images")]
        public async Task<ActionResult<IEnumerable<RestApi.Models.WoodworkProjectImage>>> ListImages(string projectRef)
        {
            if (string.IsNullOrEmpty(projectRef))
                return ValidationProblem();

            var WoodworkProject = await _repo.GetWoodworkProjectAsync(projectRef);

            if (WoodworkProject == null)
                return NotFound();
            else
                return _mapper.Map<List<Models.WoodworkProjectImage>>(WoodworkProject.Images);
        }

        [HttpDelete]
        [Route("{projectRef}/images/{imageRef}")]
        public async Task<ActionResult<IEnumerable<RestApi.Models.WoodworkProjectImage>>> DeleteImage(string projectRef, string imageRef)
        {
            if (string.IsNullOrEmpty(projectRef))
                return ValidationProblem();

            var updatedWoodworkProject = await _repo.DeleteWoodworkProjectImageAsync(projectRef, imageRef);

            var WoodworkProject = await _repo.GetWoodworkProjectAsync(projectRef);

            if (WoodworkProject == null)
                return NotFound();
            else
                return _mapper.Map<List<Models.WoodworkProjectImage>>(WoodworkProject.Images);
        }
    }
}
