using ExampleOData.Domain;

namespace ExampleOData.NH.Mapping
{
    public class SviluppatoreMapping : AbsBaseClassMap<Sviluppatore>
    {
        public SviluppatoreMapping()
            : base("Sviluppatori")
        {
            Id(x => x.Id)
                .Column("Id")
                .UnsavedValue(0)
                .GeneratedBy.Native();

            Map(x => x.Nome)
                .Column("Nome");

            Map(x => x.Cognome)
                .Column("Cognome");

            References(x => x.Team)
                .Column("IdTeam");
        }
    }
}
