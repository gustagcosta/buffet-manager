using System.Collections.Generic;
using Buffet.Models.TipoEvento;

namespace Buffet.ViewModels.Private.TipoEvento
{
    public class IndexViewModel
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string mensagem { get; set; }
        public List<TipoEventoEntity> Tipos { get; set; }
    }
}