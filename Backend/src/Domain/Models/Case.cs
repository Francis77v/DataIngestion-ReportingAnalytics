using System.ComponentModel.DataAnnotations;

namespace Backend.Domain.Models;

public class Case
{
   public int Id { get; set; }
   [MaxLength(100)]
   public required string RegistryNumber { get; set; }
   [MaxLength(100)]
   public required string CaseFileNumber { get; set; }
   [MaxLength(100)]
   public required string CaseCategory { get; set; }
   public Client? ClientNavigation { get; set; }
}