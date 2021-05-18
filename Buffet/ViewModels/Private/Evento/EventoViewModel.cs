using Buffet.Models;
using Buffet.Models.Cliente;
using Buffet.Models.SituacaoEvento;
using Buffet.Models.TipoEvento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.ViewModels.Private.Evento
{
    public class EventoViewModel
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public TipoEventoEntity tipoEvento { get; set; }
        public ClienteEntity Cliente { get; set; }
        public DateTime inicio { get; set; }
        public DateTime fim { get; set; }
        public SituacaoEventoEntity SituacaoEvento { get; set; }
        public string obs{ get; set; }
        public string mensagem{ get; set; }
        public List<EventoEntity> Eventos { get; set; }
    }
}
