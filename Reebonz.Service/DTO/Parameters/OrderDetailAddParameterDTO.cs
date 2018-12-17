using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Service.DTO.Parameters
{
    /// <summary>
    /// class OrderDetailAddParameterDTO
    /// </summary>
    public class OrderDetailAddParameterDTO
    {
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
