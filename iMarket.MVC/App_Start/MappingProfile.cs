using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using iMarket.Models;
using iMarket.Dtos;

namespace iMarket.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Produto, ProdutoDto>());
            Mapper.Initialize(cfg => cfg.CreateMap<ProdutoDto, Produto>());
        }
    }
}