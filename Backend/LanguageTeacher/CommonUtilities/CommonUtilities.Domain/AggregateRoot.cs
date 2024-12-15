using System.ComponentModel.DataAnnotations;

namespace CommonUtilities.Domain;
public class AggregateRoot : IAggregateRoot
{
    public AggregateRoot()
    {
        Id = Guid.NewGuid();
    }

    [Key]
    public Guid Id { get; protected set; }
}
