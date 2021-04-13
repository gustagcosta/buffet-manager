using System.ComponentModel.DataAnnotations;
using Buffet.Models.Cliente;

namespace Buffet.Models.ClienteFisico
{
    public class ClienteFisicoEntity
    {
        [Key] public int Id;
        [Required] private ClienteEntity Cliente;
        [Required] public string Cnpj { get; set; }
    }
}