using Reebonz.Service.DTO;
using Reebonz.Service.DTO.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Interfaces.Service
{
    /// <summary>
    /// ingerface IRefundService
    /// </summary>
    public interface IRefundService
    {
        /// <summary>
        /// 取得所有退貨
        /// </summary>
        /// <returns></returns>
        List<RefundDTO> Get();

        /// <summary>
        /// 新增退貨
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        int Add(RefundAddDTOParameter parameter);

        /// <summary>
        /// 更新退貨
        /// </summary>
        /// <returns></returns>
        bool Update();
    }
}
