using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Service.DTO.Parameters
{
    /// <summary>
    /// class OrderDetailBaseAddParameterDTO
    /// </summary>
    public class OrderDetailBaseAddParameterDTO
    {
        /// <summary>
        /// 訂單ID
        /// </summary>
        public long OrderID { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public string SKU { get; set; }
        /// <summary>
        /// 數量
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// 售價
        /// </summary>
        public decimal Price { get; set; }
    }
}
