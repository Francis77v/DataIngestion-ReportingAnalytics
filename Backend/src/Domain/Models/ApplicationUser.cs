using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Backend.Domain.Models;

public class ApplicationUser : IdentityUser
{
    [Key]
    public new Guid Id { get; set; }
    [MaxLength(100)]
    public required string FullName { get; set; }
}