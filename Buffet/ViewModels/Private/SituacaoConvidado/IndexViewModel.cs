using System.Collections.Generic;
using Buffet.Models.SituacaoConvidado;

namespace Buffet.ViewModels.Private.SituacaoConvidado
{
    public class IndexViewModel
    {
        public string Error { get; set; }
        public string Mensagem { get; set; }
        public List<SituacaoConvidadoEntity> Situacoes { get; set; }
    }
}