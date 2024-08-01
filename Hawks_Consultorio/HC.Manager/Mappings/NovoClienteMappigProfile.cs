using AutoMapper;
using HC.Core.Domain;
using HC.Core.Shared.ModelViews.Cliente;
using HC.Core.Shared.ModelViews.Endereco;
using HC.Core.Shared.ModelViews.Telefone;
using HC.Manager.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Manager.Mappings
{
    public class NovoClienteMappigProfile : Profile
    {
        public NovoClienteMappigProfile()
        {
            CreateMap<NovoCliente, Cliente>().
            ForMember(d => d.Criacao , o => o.MapFrom(x=> DateTime.Now.Date)).
            ForMember(d => d.DataNascimento , o => o.MapFrom(x=> x.DataNascimento.Date));

            CreateMap<NovoEndereco, Endereco>();
            CreateMap<NovoTelefone, Telefone>();
            CreateMap<NovoCliente, Cliente>();          
            CreateMap<Cliente, ClienteView>();          
            CreateMap<Endereco, EnderecoView>();
            CreateMap<Telefone, TelefoneView>();
        }
    }
}
