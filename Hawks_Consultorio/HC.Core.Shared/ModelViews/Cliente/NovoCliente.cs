using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HC.Core.Shared.ModelViews.Endereco;
using HC.Core.Shared.ModelViews.Telefone;

namespace HC.Core.Shared.ModelViews.Cliente
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
        public SexoView Sexo { get; set; }

        public ICollection<NovoTelefone> Telefones { get; set; }
        /// <summary>
        /// Documento do cliente: CNH,CPF ou RG 
        /// </summary>
        /// <example>11111</example>
        public string Documento { get; set; }
        public NovoEndereco Endereco { get; set; }
    }
}
