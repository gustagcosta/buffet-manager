using System.ComponentModel.DataAnnotations;

namespace Buffet.Models.Endereco
{
    public class EnderecoEntity
    {
        [Key] public int Id { get; set; }
        [Required] public string Estado { get; set; }
        [Required] public string Cidade { get; set; }
        [Required] public string Bairro { get; set; }
        [Required] public string Rua { get; set; }
        [Required] public int Numero { get; set; }

        public EnderecoEntity( string estado, string cidade, string bairro, string rua, int numero)
        {
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
        }

        public EnderecoEntity()
        {
        }
    }

}