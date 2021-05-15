using System;
using System.Collections.Generic;

namespace Buffet.Models.Usuario
{
    public class UpdateUsuarioException : Exception
    {
        public List<string> Erros { get; set; }

        public UpdateUsuarioException(List<string> erros)
        {
            Erros = erros;
        }
    }
}