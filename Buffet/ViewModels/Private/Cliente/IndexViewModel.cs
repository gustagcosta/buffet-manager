using Buffet.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.ViewModels.Private.Cliente
{
    public class IndexViewModel
    {
        internal int id;

        public List<ClienteEntity> Clientes { get; internal set; }
    }
}
