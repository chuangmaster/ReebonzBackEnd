using AutoMapper;
using Reebonz.Models.Parameters;
using Reebonz.Service.DTO.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reebonz.MapProfile
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderAddActionParameter, OrderAddParameterDTO>();
            CreateMap<OrderAddActionParameter.OrderDetail, OrderDetailAddParameterDTO>();
        }
    }
}