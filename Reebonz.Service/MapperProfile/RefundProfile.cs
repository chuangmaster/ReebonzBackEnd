using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Reebonz.Dapper.Repository.Models;
using Reebonz.Service.DTO;

namespace Reebonz.Service.MapperProfile
{
    /// <summary>
    /// class RefundProfile
    /// </summary>
    internal class RefundProfile : Profile
    {
        internal static IMapper Config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<RefundModel, RefundDTO>();
        }).CreateMapper();
    }
}
