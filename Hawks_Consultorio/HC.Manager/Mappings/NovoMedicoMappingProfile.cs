using AutoMapper;
using HC.Core.Domain;
using HC.Core.Shared.ModelViews.Especialidade;
using HC.Core.Shared.ModelViews.Medico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Mappings
{
    public class NovoMedicoMappingProfile:Profile
    {
        public NovoMedicoMappingProfile()
        {
            CreateMap<NovoMedico, Medico>();
            CreateMap<Medico, MedicoView>();
            CreateMap<Especialidade, ReferenciaEspecialidade>().ReverseMap();
            CreateMap<Especialidade, EspecialidadeView>().ReverseMap();
            CreateMap<AlteraMedico, Medico>().ReverseMap();
        }
    }
}
