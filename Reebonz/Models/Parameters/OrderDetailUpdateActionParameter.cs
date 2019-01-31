using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reebonz.Models.Parameters
{
    /// <summary>
    /// class OrderDetailUpdateActionParameter
    /// </summary>
    public class OrderDetailUpdateActionParameter
    {
        /// <summary>
        /// 要更新的訂單明細
        /// </summary>
        public List<OrderDeatil> OrderDeatils { get; set; }

        public class OrderDeatil
        {
            /// <summary>
            /// OrderDetail ID
            /// </summary>
            public long ID { get; set; }

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
}