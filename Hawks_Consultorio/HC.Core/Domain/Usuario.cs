﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Core.Domain
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public ICollection<Funcao> Funcoes { get; set; }

        public Usuario()
        {
           Funcoes = new HashSet<Funcao>();
        }
    }
}
