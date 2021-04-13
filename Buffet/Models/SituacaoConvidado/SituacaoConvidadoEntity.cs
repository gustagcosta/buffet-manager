using System.ComponentModel.DataAnnotations;

namespace Buffet.Models.SituacaoConvidado
{
    public class SituacaoConvidadoEntity
    {
        [Key] public int Id { get; set; }
        [Required] public string Descricao { get; set; }
    }
}