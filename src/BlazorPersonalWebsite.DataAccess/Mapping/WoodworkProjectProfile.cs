using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorPersonalWebsite.Models;

namespace BlazorPersonalWebsite.DataAccess.Mappings
{
    public class WoodworkProjectProfile : Profile
	{
		public WoodworkProjectProfile()
		{
			CreateMap<WoodworkProjectCreateModel, WoodworkProject>();
			CreateMap<WoodworkProjectImageUpdateModel, WoodworkProjectImage>();

			CreateMap<WoodworkProjectUpdateModel, WoodworkProject>();
		}
	}
}
