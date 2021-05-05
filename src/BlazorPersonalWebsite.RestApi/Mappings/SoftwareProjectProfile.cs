using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApiModel = BlazorPersonalWebsite.RestApi.Models;
using CoreModel = BlazorPersonalWebsite.Models;

namespace BlazorPersonalWebsite.RestApi.Mappings
{
    public class SoftwareProjectProfile : Profile
	{
		public SoftwareProjectProfile()
		{
			CreateMap<CoreModel.SoftwareProject, RestApiModel.SoftwareProject>();
			CreateMap<CoreModel.SoftwareProjectImage, RestApiModel.SoftwareProjectImage>();
		}
	}
}
