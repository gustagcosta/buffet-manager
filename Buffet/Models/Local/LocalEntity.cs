using System.ComponentModel.DataAnnotations;
using Buffet.Models.Endereco;

namespace Buffet.Models.Local
{
    public class LocalEntity
    {
        [Key] public int Id;
        [Required] public string Descricao;
        [Required] public EnderecoEntity Endereco;
    }
}