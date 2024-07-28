using FluentValidation;
using FluentValidation.Validators;
using HC.Core.Shared.ModelViews.Telefone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Validator
{
    public class NovoTelefoneValidator : AbstractValidator <NovoTelefone>
    {
        public NovoTelefoneValidator()
        {
                RuleFor(t => t.Numero).NotEmpty().Matches("[2-9][0-9]{10}").WithMessage("O telefone tem que ter o formato [2-9][0-9]{10}");
        }
    }
}
