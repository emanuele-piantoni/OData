using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Query;
using ExampleOData.Models;
using ExampleOData.Service;
using ExampleOData.Service.Dto;

namespace ExampleOData.Controllers
{
    public class TeamController : ApiController
    {
        // GET api/<controller>
        //public IQueryable<TeamDto> Get(ODataQueryOptions queryOptions)
        //{
        //    var session = NHelper.SessionFactory.OpenSession();
        //    var query = new TeamRepository(session).Find().Select(t => new TeamDto(){NomeTeam = t.Nome});
        //    //var query = new TeamRepository(session).Find().Select(t => Mapper.Map<Team, TeamDto>(t));
        //    //var query = new TeamRepository(session).Find();

        //    return queryOptions.ApplyTo(query) as IQueryable<TeamDto>;
        //}

        //public IQueryable<TeamDto> Get(ODataQueryOptions queryOptions)
        //{
        //    var query = new TeamService().Get();
        //    //var query = new TeamRepository(session).Find().Select(t => Mapper.Map<Team, TeamDto>(t));
        //    //var query = new TeamRepository(session).Find();

        //    return queryOptions.ApplyTo(query) as IQueryable<TeamDto>;
        //}

        public IQueryable<TeamModel> Get(ODataQueryOptions queryOptions)
        {
            var query = new TeamService().Get().Select(t => new TeamModel() { NomeModel = t.NomeTeam });
            //var query = new TeamRepository(session).Find().Select(t => Mapper.Map<Team, TeamDto>(t));
            //var query = new TeamRepository(session).Find();

            return queryOptions.ApplyTo(query) as IQueryable<TeamModel>;
        }

        //public IEnumerable<TeamDto> Get(ODataQueryOptions queryOptions)
        //{
        //    var results = new List<TeamDto>();

        //    var session = NHelper.SessionFactory.OpenSession();
        //    //var query = new TeamRepository(session).Find().Select(t => new TeamDto() { NomeTeam = t.Nome });
        //    //var query = new TeamRepository(session).Find().Select(t => Mapper.Map<Team, TeamDto>(t));
        //    var query = new TeamRepository(session).Find();

        //    var modelBuilder = new ODataConventionModelBuilder();
        //    modelBuilder.EntitySet<TeamDto>("Team");
        //    var model = modelBuilder.GetEdmModel();

        //    var mappedQuery = new ODataQueryOptions(new ODataQueryContext(model, typeof(TeamDto)), Request);

        //    foreach (var result in mappedQuery.ApplyTo(query))
        //    {
        //        results.Add(Mapper.Map<TeamDto>(result));
        //    }
        //    return results;
        //}
    }
}