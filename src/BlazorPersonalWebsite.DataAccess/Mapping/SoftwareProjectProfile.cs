using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorPersonalWebsite.Models;

namespace BlazorPersonalWebsite.DataAccess.Mappings
{
    public class SoftwareProjectProfile : Profile
	{
		public SoftwareProjectProfile()
		{
			CreateMap<SoftwareProjectCreateModel, SoftwareProject>();
			CreateMap<SoftwareProjectImageUpdateModel, SoftwareProjectImage>();

			CreateMap<SoftwareProjectUpdateModel, SoftwareProject>();
		}
	}
}
