using ExampleOData.Domain;

namespace ExampleOData.NH.Mapping
{
    public class TeamMapping : AbsBaseClassMap<Team>
    {
        public TeamMapping()
            : base("Teams")
        {
            Id(x => x.Id)
                .Column("IdTeam")
                .UnsavedValue(0)
                .GeneratedBy.Native();

            Map(x => x.Nome)
                .Column("Nome");
            
            HasMany(x => x.Sviluppatori)
                .KeyColumn("IdTeam")
                .Cascade.All();
        }
    }
}
