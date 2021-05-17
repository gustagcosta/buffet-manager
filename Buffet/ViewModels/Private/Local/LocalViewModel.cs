using System.Collections.Generic;
using Buffet.Models.Local;

namespace Buffet.ViewModels.Private.Local
{
    public class LocalViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }

        public List<LocalEntity> Locais;
    }
}