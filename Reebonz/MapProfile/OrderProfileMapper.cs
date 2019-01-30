using AutoMapper;
using Reebonz.Models.Output.Api;
using Reebonz.Models.Parameters;
using Reebonz.Service.DTO;
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
            CreateMap<OrderDTO, OrderOutputModel>();
            CreateMap<OrderDetailDTO, OrderDetailOutputModel>();
            CreateMap<RefundAddActionParameter, RefundAddParameterDTO>()
                .ForMember(d => d.AskDate, o => o.MapFrom(s => DateTime.Parse(s.AskDate)))
                .ForMember(d => d.ShipmentDate, o => o.MapFrom(s => DateTime.Parse(s.ShipmentDate)))
                .ForMember(d => d.RefundDetails, o => o.MapFrom(s => s.RefundDetails));
            CreateMap<RefundAddActionParameter.RefundDetail, RefundAddParameterDTO.RefundDetailAddParameterDTO>()
                .ForMember(d => d.Price, o => o.MapFrom(s => decimal.Parse(s.Price)))
                .ForMember(d => d.Amount, o => o.MapFrom(s => decimal.Parse(s.Amount)));
            CreateMap<RefundAddActionParameter, RefundAddParameterDTO>();

        }
    }
}