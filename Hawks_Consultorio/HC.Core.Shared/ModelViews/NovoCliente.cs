﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Core.Shared.ModelViews
{    /// <summary>
     /// Objeto utilizado para inserção de um novo cliente
     /// </summary>
    public class NovoCliente
    {
        /// <summary>
        /// Nome do cliente
        /// </summary>
        /// <example>Maria Luiza Dantas</example>
        public string Nome { get; set; }
        /// <summary>
        /// Data de Nascimento
        /// </summary>
        /// <example>1995-01-05</example>
        public DateTime DataNascimento { get; set; }
        /// <summary>
        /// Sexo do cliente: M ou F
        /// </summary>
        /// <example>F</example>
        public char Sexo { get; set; }
        /// <summary>
        /// Telefone do cliente
        /// </summary>
        /// <example>99999999999</example>
        public string Telefone { get; set; }
        /// <summary>
        /// Documento do cliente: CNH,CPF ou RG 
        /// </summary>
        /// <example>11111</example>
        public string Documento { get; set; }
    }
}
