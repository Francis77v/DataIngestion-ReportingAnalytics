namespace Backend.Domains;

public class Case
{
   public int Id { get; set; }
   public required string RegistryNumber { get; set; }
   public required string CaseFileNumber { get; set; }
   public required string CaseCategory { get; set; }
   public Client? ClientNavigation { get; set; }
}