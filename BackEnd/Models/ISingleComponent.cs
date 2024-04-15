using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BackEnd.Models;

public class ISingleComponent
{
    [ForeignKey ("AlimentId")]
    public string? AlimentId { get; set; }
    
    [ForeignKey ("ComponentsId")]
    public string? ComponentsId { get; set; }

    [Key] public string? SingleComponentId { get; set; }
    public string? Componente { get; set; }
    public string? Unidades { get; set; }
    public string? ValorPor100g { get; set; }
    public string? DesvioPadrão { get; set; }
    public string? ValorMínimo { get; set; }
    public string? ValorMáximo { get; set; }
    public string? NúmeroDeDadosUtilizado { get; set; }
    public string? Referências { get; set; }
    public string? TipoDeDados { get; set; }
}