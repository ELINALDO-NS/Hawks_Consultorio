using AutoMapper;
using HC.Core.Domain;
using HC.Core.Shared.ModelViews.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Mappings
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<Usuario, UsuarioView>().ReverseMap();
            CreateMap<Usuario, NovoUsuario>().ReverseMap();
            CreateMap<Usuario, UsuarioLogado>().ReverseMap();
            CreateMap<Funcao, FuncaoView>().ReverseMap();
            CreateMap<Funcao, ReferenciaFuncao>().ReverseMap();
        }
    }
}
