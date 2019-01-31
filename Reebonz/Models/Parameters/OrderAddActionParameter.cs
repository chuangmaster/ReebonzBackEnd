using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(AllowEmptyStrings = false)]
        public string TransactionID { get; set; }

        /// <summary>
        /// 訂單明細
        /// </summary>
        public List<OrderDetail> OrderDetails { get; set; }
        public class OrderDetail
        {
            /// <summary>
            /// SKU
            /// </summary>
            [Required]
            public string SKU { get; set; }
            /// <summary>
            /// 單價
            /// </summary>
            [Required]
            public decimal Price { get; set; }
            /// <summary>
            /// 數量
            /// </summary>
            [Required]
            public int Amount { get; set; }
        }
    }
}