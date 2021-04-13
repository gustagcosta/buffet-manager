using System.ComponentModel.DataAnnotations;

namespace Buffet.Models.TipoEvento
{
    public class TipoEventoEntity
    {
        [Key] public int Id { get; set; }
        [Required] public string Descricao { get; set; }
    }
}