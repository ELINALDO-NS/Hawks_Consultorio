using FluentValidation;
using HC.Core.Shared.ModelViews;
using HC.Manager.Interfaces.Managers;
using HC.Manager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Validator
{
    public class NovoMedicoValidator : AbstractValidator<NovoMedico>
    {
        public NovoMedicoValidator(IEspecialidadeRepository repositorio)
        {
            RuleFor(p => p.Nome).NotNull().NotEmpty().MaximumLength(200);

            RuleFor(p => p.CRM).NotNull().NotEmpty().GreaterThan(0);

            RuleForEach(p => p.Especialidades).SetValidator(new ReferenciaEspecialidadeValidator(repositorio));
        }

    }
}
