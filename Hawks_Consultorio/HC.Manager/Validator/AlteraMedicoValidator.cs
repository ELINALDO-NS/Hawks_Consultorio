using FluentValidation;
using HC.Core.Shared.ModelViews;
using HC.Manager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Validator
{
    public class AlteraMedicoValidator:AbstractValidator<AlteraMedico>
    {
        public AlteraMedicoValidator(IEspecialidadeRepository repository)
        {
            RuleFor( i => i.Id).NotEmpty().NotNull();
            Include(new NovoMedicoValidator(repository));
        }
    }
}
