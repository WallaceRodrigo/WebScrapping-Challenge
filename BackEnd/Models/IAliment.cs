using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BackEnd.Models;

public class IAliment
{
    [Key] public string? AlimentId { get; set; }
    public string? name { get; set; }
    public string? scientificName { get; set; }
    public string? group { get; set; }
    public string? brand { get; set; }
    [NotMapped] public IEnumerable<Dictionary<string, string>>? components { get; set; }
}
