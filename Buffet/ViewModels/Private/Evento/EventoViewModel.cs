using Buffet.Models;
using Buffet.Models.Cliente;
using Buffet.Models.Local;
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
        public List<TipoEventoEntity> tipos { get; set; }
        public TipoEventoEntity tipoEvento { get; set; }
        public List<ClienteEntity> Clientes { get; set; }
        public List<SituacaoEventoEntity> Situacoes{ get; set; }
        public List<LocalEntity> Locais{ get; set; }
        public LocalEntity local { get; set; }
        public ClienteEntity Cliente { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public SituacaoEventoEntity SituacaoEvento { get; set; }
        public string obs{ get; set; }
        public string mensagem{ get; set; }
        public List<EventoEntity> Eventos { get; set; }
    }
}
