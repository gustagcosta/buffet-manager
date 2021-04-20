using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Buffet.Models.Usuario
{
    public class CadastrarUsuarioException : Exception
    {
        public List<string> Erros { get; set; }

        public CadastrarUsuarioException(List<string> erros)
        {
            Erros = erros;
        }
    }
}