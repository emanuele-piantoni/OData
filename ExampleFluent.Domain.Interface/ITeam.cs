using System.Collections.Generic;

namespace ExampleOData.Domain.Interface
{
    public interface ITeam
    {
        int Id { get; set; }
        string Nome { get; set; }
    }
}