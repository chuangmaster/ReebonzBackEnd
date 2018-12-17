using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository.Parameters
{
    /// <summary>
    /// class OrderDetailBaseAddRptParameter
    /// </summary>
    public class OrderDetailBaseAddRptParameter
    {
        /// <summary>
        /// Order ID
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
        /// 價格
        /// </summary>
        public decimal Price { get; set; }
    }
}
