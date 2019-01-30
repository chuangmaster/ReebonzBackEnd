using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Service.DTO.Parameters
{
    /// <summary>
    /// class OrderAddParameterDTO
    /// </summary>
    public class OrderAddParameterDTO
    {
        /// <summary>
        /// 訂單編號
        /// </summary>
        public string TransationID { get; set; }

        /// <summary>
        /// 訂單明細
        /// </summary>
        public List<OrderDetailAddParameterDTO> OrderDetails { get; set; }

    }
}
