using System.ComponentModel.DataAnnotations;
using Buffet.Models.Endereco;

namespace Buffet.Models.Local
{
    public class LocalEntity
    {
        [Key] public int Id { get; set; }
        [Required] public string Descricao { get; set; }
        [Required] public EnderecoEntity Endereco { get; set; }
    }
}