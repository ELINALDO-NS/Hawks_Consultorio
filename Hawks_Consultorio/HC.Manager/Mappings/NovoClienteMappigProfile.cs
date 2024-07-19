﻿using AutoMapper;
using HC.Core.Domain;
using HC.Core.Shared.ModelViews;
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
        }
    }
}
