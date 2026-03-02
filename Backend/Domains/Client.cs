using Backend.Infrastructure.enums;

namespace Backend.Domains;

public class Client
{
    public int Id { get; set; }
    public required string Sex { get; set; }
    public required string Address { get; set; }
    public required string MaritalStatus { get; set; }
    public required string Occupation { get; set; }
    public required string AgeBracket { get; set; }
    public required string EducationalAttainment { get; set; }
    public required string Religion { get; set; }
    public string? IfAfterCare { get; set; } = null!;
    public required string IfDdeEnum { get; set; } 
    public required string Nationality { get; set; }
    public required string Ethnicity { get; set; }
    public required string LivingArrangement { get; set; }
    public required string SubstanceUse { get; set; }
    public required string Program { get; set; }
    

    public Case? CaseNavigation { get; set; } = null!;
}