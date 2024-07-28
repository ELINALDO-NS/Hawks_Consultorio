using FluentValidation;
using HC.Core.Shared.ModelViews.Especialidade;
using HC.Manager.Interfaces.Managers;
using HC.Manager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Validator
{
    public class ReferenciaEspecialidadeValidator : AbstractValidator<ReferenciaEspecialidade>
    {
        private readonly IEspecialidadeRepository _repository;
        public ReferenciaEspecialidadeValidator(IEspecialidadeRepository repository)
        {
            _repository = repository;
            RuleFor(p => p.Id).NotEmpty().NotNull().GreaterThan(0).
                Must(ExisteNaBase).                
                //MustAsync(async (id, cancelar) => await  ExisteNaBase(id)).                
                WithMessage("Especialidade não cadastrada !");
        }

        private bool ExisteNaBase(int id)
        {
            return  _repository.ExisteNaBaseAsync(id).GetAwaiter().GetResult(); ;
        }
    }
}
