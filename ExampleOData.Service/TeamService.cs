using System.Linq;
using ExampleOData.NH;
using ExampleOData.NH.Helpers;
using ExampleOData.Service.Dto;

namespace ExampleOData.Service
{
    public class TeamService
    {
        public IQueryable<TeamDto> Get()
        {
             var session = NHelper.SessionFactory.OpenSession();
             return new TeamRepository(session).Find().Select(t => new TeamDto() { NomeTeam = t.Nome });
        }
    }
}