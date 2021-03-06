﻿using AutoMapper;
using Reebonz.Dapper.Repository.Models;
using Reebonz.Dapper.Repository.Parameters;
using Reebonz.Service.DTO;
using Reebonz.Service.DTO.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Service.MapperProfile
{
    /// <summary>
    /// class OrderMapperProfile
    /// </summary>
    public class OrderMapperProfile : Profile
    {
        internal static IMapper Config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<OrderModel, OrderDTO>();
            cfg.CreateMap<OrderDetailModel, OrderDetailDTO>();
            cfg.CreateMap<OrderAddParameterDTO, OrderAddRptParameter>();
            cfg.CreateMap<OrderDetailAddParameterDTO, OrderDetailAddRptParameter>();
            cfg.CreateMap<OrderDetailUpdateParameterDTO, OrderDetailUpdateRptParameter>();
        }).CreateMapper();
    }
}
