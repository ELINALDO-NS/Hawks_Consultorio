using FluentValidation;
using HC.Core.Domain;
using HC.Core.Shared.ModelViews.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Manager.Validator
{
    public class NovoClienteValidator : AbstractValidator<NovoCliente>
    {
        public NovoClienteValidator()
        {
            RuleFor(x => x.Sexo).NotNull();
            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(8).MaximumLength(150);
            RuleFor(x => x.DataNascimento).NotNull().NotEmpty().GreaterThan(DateTime.Now.AddYears(-100)).LessThan(DateTime.Now);
            RuleFor(x => x.Documento).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
            RuleFor(x => x.Telefones).NotNull().NotEmpty();
            RuleFor(x => x.Endereco).SetValidator(new EnderecoValidator());



        }


    }
}
