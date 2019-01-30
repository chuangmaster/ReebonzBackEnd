using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Reebonz.Dapper.Repository.Models;
using Reebonz.Dapper.Repository.Parameters;
using Reebonz.Service.DTO;
using Reebonz.Service.DTO.Parameters;

namespace Reebonz.Service.MapperProfile
{
    /// <summary>
    /// class RefundMapperProfile
    /// </summary>
    internal class RefundMapperProfile : Profile
    {
        internal static IMapper Config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<RefundModel, RefundDTO>()
            .ForMember(d => d.RefundDetails, o => o.MapFrom(s => s.RefundDetails));

            cfg.CreateMap<RefundDetailModel, RefundDetailDTO>();

            cfg.CreateMap<RefundAddParameterDTO, RefundAddRptParameter>()
            .ForMember(d => d.RefundDetails, o => o.MapFrom(s => s.RefundDetails));

            cfg.CreateMap<RefundAddParameterDTO.RefundDetailAddParameterDTO, RefundAddRptParameter.RefundDetailAddRptParameter>();
        }).CreateMapper();
    }
}
