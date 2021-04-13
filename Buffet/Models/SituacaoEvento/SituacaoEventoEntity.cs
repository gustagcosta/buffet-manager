using System.ComponentModel.DataAnnotations;

namespace Buffet.Models.SituacaoEvento
{
    public class SituacaoEventoEntity
    {
        [Key] public int Id { get; set; }
        [Required] public string Descricao { get; set; }
    }
}