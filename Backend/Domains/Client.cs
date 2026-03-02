using System.ComponentModel.DataAnnotations;

namespace Backend.Domains;

public class Client
{
    public int Id { get; set; }
    [MaxLength(100)]
    public required string Sex { get; set; }
    [MaxLength(100)]
    public required string Address { get; set; }
    [MaxLength(100)]
    public required string MaritalStatus { get; set; }
    [MaxLength(100)]
    public required string Occupation { get; set; }
    [MaxLength(100)]
    public required string AgeBracket { get; set; }
    [MaxLength(100)]
    public required string EducationalAttainment { get; set; }
    [MaxLength(100)]
    public required string Religion { get; set; }
    [MaxLength(100)]
    public string? IfAfterCare { get; set; } = null!;
    [MaxLength(100)]
    public required string IfDde { get; set; } 
    [MaxLength(100)]
    public required string Nationality { get; set; }
    [MaxLength(100)]
    public required string Ethnicity { get; set; }
    [MaxLength(100)]
    public required string LivingArrangement { get; set; }
    [MaxLength(100)]
    public required string SubstanceUse { get; set; }
    [MaxLength(100)]
    public required string Program { get; set; }
    
    public int CaseId { get; set; }
    public Case? CaseNavigation { get; set; } = null!;
}