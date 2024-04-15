using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BackEnd.Models;

public class IComponents
{
  [ForeignKey ("AlimentId")]
  public string? AlimentId { get; set; }
  [Key] public string? ComponentsId { get; set; }

  public ICollection<ISingleComponent>? SingleComponent { get; set; }
}