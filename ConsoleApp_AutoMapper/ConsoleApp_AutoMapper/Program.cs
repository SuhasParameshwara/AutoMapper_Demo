using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp_AutoMapper.Domain;
using ConsoleApp_AutoMapper.View;
using Newtonsoft.Json;

namespace ConsoleApp_AutoMapper
{
	class Program
	{
		static void Main(string[] args)
		{


			#region mapperConfig_CreateMapper

			var mapperConfig = new MapperConfiguration(
				config =>
				{
					config.CreateMap<User, UserData>()
						.ForMember(d => d.UserId, 
							op => op.MapFrom(
								s => Guid.NewGuid()));
				});

			var mapper = mapperConfig.CreateMapper();

			var user = new User()
			{
				Name = "Suhas",
				Age = 23
			};
			var userData = new UserData();
			mapper.Map(user, userData);
			userData = mapper.Map<UserData>(user);

			#endregion

			#region Profiles

			mapperConfig = new MapperConfiguration(config =>
			{
				config.AddProfile<AutoMapperProfile>();
			});

			mapper = mapperConfig.CreateMapper();

			mapper.Map(user, userData);

			#endregion
			Console.WriteLine(JsonConvert.SerializeObject(userData));
			Console.ReadLine();
		}
	}
}
