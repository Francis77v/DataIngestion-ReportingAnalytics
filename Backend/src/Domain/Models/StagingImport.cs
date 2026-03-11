using System.ComponentModel.DataAnnotations;

namespace Backend.Domain.Models;

public class StagingImport
{
    [Key]
    public long Id { get; set; }
    public Guid BatchId { get; set; }
    public int RowNumber { get; set; }
    [MaxLength(100)]
    public string? RawRegistryNumber { get; set; } = null!;
    [MaxLength(100)]
    public string? RawCaseFileNumber { get; set; } = null!;
    [MaxLength(100)]
    public string? RawCaseCategory { get; set; } = null!;
    [MaxLength(50)]
    public string? RawSex { get; set; } = null!;
    [MaxLength(100)]
    public string? RawAddress { get; set; } = null!;
    [MaxLength(100)]
    public string? RawMaritalStatus { get; set; } = null!;
    [MaxLength(100)]
    public string? RawOccupation { get; set; } = null!;
    [MaxLength(100)]
    public string? RawAgeBracket { get; set; } = null!;
    [MaxLength(100)]
    public string? RawEducationalAttainment { get; set; } = null!;
    [MaxLength(100)]
    public string? RawReligion { get; set; } = null!;
    [MaxLength(100)]
    public string? RawIfAfterCare { get; set; } = null!;
    [MaxLength(100)]
    public string? RawIfDde { get; set; } = null!;
    [MaxLength(100)]
    public string? RawNationality { get; set; } = null!;
    [MaxLength(100)]
    public string? RawEthnicity { get; set; } = null!;
    [MaxLength(100)]
    public string? RawLivingArrangement { get; set; } = null!;
    [MaxLength(100)]
    public string? RawSubstanceUse { get; set; } = null!;
    [MaxLength(100)]
    public string? RawProgram { get; set; } = null!;
    public DateTime ImportedAt { get; set; } = DateTime.UtcNow;
    public bool Processed { get; set; } = false;
}