using System.ComponentModel.DataAnnotations;
using Buffet.Models.Cliente;

namespace Buffet.Models.ClienteFisico
{
    public class ClienteFisicoEntity
    {
        [Key] public int Id { get; set; }
        [Required] private ClienteEntity Cliente { get; set; }
        [Required] public string Cnpj { get; set; }
    }
}