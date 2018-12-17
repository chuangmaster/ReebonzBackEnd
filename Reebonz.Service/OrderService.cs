using AutoMapper;
using Reebonz.Dapper.Repository.Interfaces;
using Reebonz.Dapper.Repository.Parameters;
using Reebonz.Service.DTO;
using Reebonz.Service.DTO.Parameters;
using Reebonz.Service.Interfaces;
using Reebonz.Service.MapperProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Service
{
    /// <summary>
    /// class OrderService
    /// </summary>
    public class OrderService : IOrderService
    {
        IOrderRepository _OrderRepository;
        IMapper _Mapper;
        public OrderService(IOrderRepository orderRepository)
        {
            _OrderRepository = orderRepository;
            _Mapper = OrderProfile.Config;
        }

        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool Add(OrderAddParameterDTO parameter)
        {
            var Result = false;
            var addOrderParameter = _Mapper.Map<OrderAddRptParameter>(parameter);
            Result = _OrderRepository.Add(addOrderParameter);
            return Result;
        }

        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool Add(List<OrderAddParameterDTO> parameter)
        {
            var Result = false;
            var addOrderParameter = _Mapper.Map<OrderAddRptParameter>(parameter);
            Result = _OrderRepository.Add(addOrderParameter);
            return Result;
        }

        /// <summary>
        /// 新增訂單明細
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public bool AddDetail(List<OrderDetailBaseAddParameterDTO> parameters)
        {
            var Result = false;
            var addOrderDetailParameter = _Mapper.Map<List<OrderDetailBaseAddRptParameter>>(parameters);
            Result = _OrderRepository.AddDetail(addOrderDetailParameter);
            return Result;
        }
        /// <summary>
        /// 取得訂單
        /// </summary>
        /// <param name="transationID"></param>
        /// <returns></returns>
        public OrderDTO Get(string transationID)
        {
            var Result = _Mapper.Map<OrderDTO>(_OrderRepository.Get(transationID));
            return Result;
        }
    }
}
