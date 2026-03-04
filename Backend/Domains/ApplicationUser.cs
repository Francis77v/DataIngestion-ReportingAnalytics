using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Backend.Domains;

public class ApplicationUser : IdentityUser
{
    [Key]
    public new Guid Id { get; set; }
    [MaxLength(100)]
    public required string FullName { get; set; }
}