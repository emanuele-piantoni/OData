using System.Collections.Generic;
using ExampleOData.Domain.Interface;

namespace ExampleOData.Domain
{
    public class Team : ITeam
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual IList<Sviluppatore> Sviluppatori { get; set; }

        public Team()
        {
            Sviluppatori = new List<Sviluppatore>();
        }
    }
}
