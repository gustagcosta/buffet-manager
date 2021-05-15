using System.Collections.Generic;
using Buffet.Models.SituacaoConvidado;

namespace Buffet.ViewModels.Private.SituacaoConvidado
{
    public class IndexViewModel
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string mensagem { get; set; }
        public List<SituacaoConvidadoEntity> Situacoes { get; set; }
        
    }
}