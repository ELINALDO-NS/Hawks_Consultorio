using FluentValidation;
using HC.Core.Shared.ModelViews.Endereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Validator
{
    public class EnderecoValidator:AbstractValidator<NovoEndereco>
    {
        public EnderecoValidator()
        {
            RuleFor(c => c.Cidade).NotNull();
        }
    }
}
