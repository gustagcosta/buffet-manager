using System.ComponentModel.DataAnnotations;

namespace Buffet.Models.TipoCliente
{
    public class TipoClienteEntity
    {
        [Key] public int Id { get; set; }
        [Required] public string Descricao { get; set; }
    }
}