using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.Configuration;
using iMarket.Models;
using iMarket.Dtos;

namespace iMarket.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoDto>();
                cfg.CreateMap<ProdutoDto, Produto>();
            });
        }
    }
}