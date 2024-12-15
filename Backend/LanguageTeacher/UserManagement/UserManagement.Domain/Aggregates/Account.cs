using System.ComponentModel.DataAnnotations;
using CommonUtilities.Domain;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.Domain.Aggregates;

[Index(nameof(Username), IsUnique = true)]
public class Account : AggregateRoot
{
    public Account(string username, string email, string password) : base()
    {
        Username = username;
        Email = email;
        Password = password;
    }

    [Required]
    [MaxLength(50)]
    public string Username { get; private set; }

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; private set; }

    [Required]
    [MaxLength(80)]
    public string Password { get; private set; }
}
