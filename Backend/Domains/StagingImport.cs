using System.ComponentModel.DataAnnotations;
namespace Backend.Models;

public class StagingImport
{
    IEnumerable<>
    [Key]
    public long Id { get; set; }
    public required Guid BatchId { get; set; }
    public required int RowNumber { get; set; }
    public required string RawData { get; set; } = string.Empty; 
    public DateTime ImportedAt { get; set; } = DateTime.UtcNow;
    public bool Processed { get; set; } = false;
}