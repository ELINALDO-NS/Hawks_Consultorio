﻿using FluentValidation;
using HC.Core.Domain;
using HC.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Manager.Validator
{
    public class NovoClienteValidator : AbstractValidator<NovoCliente>
    {
        public NovoClienteValidator()
        {
            RuleFor(x => x.Sexo).NotNull().NotEmpty().Must(IsMorF).WithMessage("O sexo precisa ser M ou F");
            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(8).MaximumLength(150);
            RuleFor(x => x.DataNascimento).NotNull().NotEmpty().GreaterThan(DateTime.Now.AddYears(-100)).LessThan(DateTime.Now);
            RuleFor(x => x.Documento).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
            RuleFor(x => x.Telefone).NotNull().NotEmpty().Matches("[2-9][0-9]{10}").WithMessage("O telefone tem que ter o formato [2-9][0-9]{10}");
            RuleFor(x => x.Endereco).SetValidator(new EnderecoValidator());



        }

        private bool IsMorF(char sexo)
        {

            return sexo == 'M' || sexo == 'F';
        }
    }
}
