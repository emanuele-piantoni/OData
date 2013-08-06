using ExampleOData.Domain.Interface;

namespace ExampleOData.Domain
{
    public class Sviluppatore : ISviluppatore
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cognome { get; set; }
        public virtual Team Team { get; set; }
    }
}