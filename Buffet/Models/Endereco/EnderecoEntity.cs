using System.ComponentModel.DataAnnotations;

namespace Buffet.Models.Endereco
{
    public class EnderecoEntity
    {
        [Key] public int Id;
        [Required] public string Estado;
        [Required] public string Cidade;
        [Required] public string Bairro;
        [Required] public string Rua;
        [Required] public int Numero;
    }
}