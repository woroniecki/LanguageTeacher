using System.ComponentModel.DataAnnotations;

namespace CommonUtilities.Domain;
public class AggregateRoot : IAggregateRoot
{
    [Key]
    public Guid Id { get; protected set; }
}
