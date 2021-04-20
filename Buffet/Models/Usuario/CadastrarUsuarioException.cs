using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Buffet.Models.Usuario
{
    public class CadastrarUsuarioException : Exception
    {
        public IEnumerable<IdentityError> Erros { get; set; }

        public CadastrarUsuarioException(IEnumerable<IdentityError> erros)
        {
            Erros = erros;
        }
    }
}