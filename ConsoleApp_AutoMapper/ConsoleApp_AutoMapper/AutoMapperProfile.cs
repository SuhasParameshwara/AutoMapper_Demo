using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConsoleApp_AutoMapper.Domain;
using ConsoleApp_AutoMapper.View;

namespace ConsoleApp_AutoMapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<User, UserData>()
				.ForMember(d => d.UserId,
					op => op.MapFrom(
						s => Guid.NewGuid()));
		}
	}
}
