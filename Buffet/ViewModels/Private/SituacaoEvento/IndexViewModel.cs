using System.Collections.Generic;
using Buffet.Models.SituacaoEvento;

namespace Buffet.ViewModels.Private.SituacaoEvento
{
    public class IndexViewModel
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string mensagem { get; set; }
        public List<SituacaoEventoEntity> Situacoes { get; set; }
    }
}