using FluentValidation;
using HC.Core.Shared.ModelViews.Cliente;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Validator
{
    public class AlteraClienteValidator:AbstractValidator<AlteraCliente>
    {
        public AlteraClienteValidator()
        {
            RuleFor(p =>p.Id).NotEmpty().NotNull().GreaterThan(0);
            Include(new NovoClienteValidator());
        }
    }
}
