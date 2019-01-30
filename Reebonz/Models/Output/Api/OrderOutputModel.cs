using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reebonz.Models.Output.Api
{
    public class OrderOutputModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// 訂單編號
        /// </summary>
        public string transactionID { get; set; }

        /// <summary>
        /// 訂單明細
        /// </summary>
        public List<OrderDetailOutputModel> orderDetails { get; set; }
    }
}