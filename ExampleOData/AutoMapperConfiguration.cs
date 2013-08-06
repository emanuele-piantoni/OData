using AutoMapper;
using ExampleOData.Domain;
using ExampleOData.Service.Dto;

namespace ExampleOData
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Team, TeamDto>()
                  .ForMember(p => p.NomeTeam, opt => opt.MapFrom(p => p.Nome));
        }
    }
}