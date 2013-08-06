using System;
using System.Collections.Generic;
using System.Linq;
using ExampleOData.Domain.Interface;
using ExampleOData.Domain;
using NHibernate;
using NHibernate.Linq;

namespace ExampleOData.NH
{
    public class TeamRepository : Repository<Team>
    {
        public TeamRepository(ISession session) : base(session)
        {
        }

        //public Team FindByNome(string nome)
        //{
        //    var team = Session.QueryOver<Team>()
        //        .Where(a => a.Nome == nome).SingleOrDefault();

        //    return team;
        //}

        public Team FindByNome(string nome)
        {
            var team = Session.QueryOver<Team>()
                .Where(a => a.Nome == nome).List();

            if (team.Count == 0)
                return null;
            if (team.Count == 1)
                return team[0];
            throw new Exception(string.Format("Nome TEAM non univoco. Nome: {0}", nome));
        }

        public IList<Team> FindAll()
        {
            var team = Session.QueryOver<Team>()
                .List();

            return team;
        }

        public IQueryable<Team> Find()
        {
            return Session.Query<Team>();
        }
    }
}
