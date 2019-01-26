using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reebonz.Models.Parameters
{
    /// <summary>
    /// class OrderAddActionParameter
    /// </summary>
    public class OrderAddActionParameter
    {
        /// <summary>
        /// 訂單編號
        /// </summary>
        public string TransationID { get; set; }
        /// <summary>
        /// 訂單明細
        /// </summary>
        public List<OrderDetail> OrderDetails { get; set; }
        public class OrderDetail
        {
            /// <summary>
            /// SKU
            /// </summary>
            public string SKU { get; set; }
            /// <summary>
            /// 單價
            /// </summary>
            public decimal Price { get; set; }
            /// <summary>
            /// 數量
            /// </summary>
            public int Amount { get; set; }
        }
    }
}