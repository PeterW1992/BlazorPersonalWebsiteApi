using AutoMapper;
using BlazorPersonalWebsite.Models;
using BlazorPersonalWebsite.Models.Interfaces;
using BlazorPersonalWebsite.RestApi.Models;
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
        public async Task<IEnumerable<RestApi.Models.SoftwareProject>> Get()
        {
            var softwareProjects = await _repo.ListSoftwareProjectsAsync();
            return _mapper.Map<List<Models.SoftwareProject>>(softwareProjects);
        }

        [HttpGet]
        [Route("{projectRef}")]
        public async Task<IEnumerable<RestApi.Models.SoftwareProject>> Get(string projectRef)
        {
            var softwareProject = await _repo.GetSoftwareProjectAsync(projectRef);

            if (softwareProject == null)
            {
                return new List<RestApi.Models.SoftwareProject>();
            }
            else
            {
                return new List<RestApi.Models.SoftwareProject> { _mapper.Map<Models.SoftwareProject>(softwareProject) };
            }
        }

        [HttpPost]
        public async Task<RestApi.Models.SoftwareProject> PostSoftwareProject(SoftwareProjectCreateModel createModel)
        {
            var newSoftwareProject = await _repo.AddSoftwareProjectAsync(createModel);
            return _mapper.Map<Models.SoftwareProject>(newSoftwareProject);
        }

        [HttpPut]
        [Route("{projectRef}")]
        public async Task<RestApi.Models.SoftwareProject> UpdateSoftwareProject(SoftwareProjectUpdateModel updateModel, string projectRef)
        {
            var updatedSoftwareProject = await _repo.UpdateSoftwareProjectAsync(projectRef, updateModel);
            return _mapper.Map<Models.SoftwareProject>(updatedSoftwareProject);
        }

        [HttpGet]
        [Route("{projectRef}/images")]
        public async Task<ActionResult<IEnumerable<RestApi.Models.SoftwareProjectImage>>> ListImages(string projectRef)
        {
            if (string.IsNullOrEmpty(projectRef))
                return ValidationProblem();

            var softwareProject = await _repo.GetSoftwareProjectAsync(projectRef);

            if (softwareProject == null)
                return NotFound();
            else
                return _mapper.Map<List<Models.SoftwareProjectImage>>(softwareProject.Images);
        }

        [HttpDelete]
        [Route("{projectRef}/images/{imageRef}")]
        public async Task<ActionResult<IEnumerable<RestApi.Models.SoftwareProjectImage>>> DeleteImage(string projectRef, string imageRef)
        {
            if (string.IsNullOrEmpty(projectRef))
                return ValidationProblem();

            var updatedSoftwareProject = await _repo.DeleteSoftwareProjectImageAsync(projectRef, imageRef);

            var softwareProject = await _repo.GetSoftwareProjectAsync(projectRef);

            if (softwareProject == null)
                return NotFound();
            else
                return _mapper.Map<List<Models.SoftwareProjectImage>>(softwareProject.Images);
        }
    }
}
