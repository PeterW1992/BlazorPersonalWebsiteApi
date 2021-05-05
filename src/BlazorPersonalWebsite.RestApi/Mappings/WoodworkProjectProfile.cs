using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApiModel = BlazorPersonalWebsite.RestApi.Models;
using CoreModel = BlazorPersonalWebsite.Models;

namespace BlazorPersonalWebsite.RestApi.Mappings
{
    public class WoodworkProjectProfile : Profile
	{
		public WoodworkProjectProfile()
		{
			CreateMap<CoreModel.WoodworkProject, RestApiModel.WoodworkProject>();
			CreateMap<CoreModel.WoodworkProjectImage, RestApiModel.WoodworkProjectImage>();
		}
	}
}
