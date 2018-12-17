using Reebonz.Service.DTO;
using Reebonz.Service.DTO.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Service.Interfaces
{
    /// <summary>
    /// interface IOrderService
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// 取得訂單
        /// </summary>
        /// <param name="transationID"></param>
        /// <returns></returns>
        OrderDTO Get(string transationID);

        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool Add(OrderAddParameterDTO parameter);

        /// <summary>
        /// 新增訂單明細
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        bool AddDetail(List<OrderDetailBaseAddParameterDTO> parameters);

    }
}
