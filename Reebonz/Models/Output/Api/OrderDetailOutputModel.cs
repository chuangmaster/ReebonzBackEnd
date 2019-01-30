using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reebonz.Models.Output.Api
{
    public class OrderDetailOutputModel
    {
        /// <summary>
        /// SKU
        /// </summary>
        public string sku { get; set; }

        /// <summary>
        /// 售價
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        public int amount { get; set; }
    }
}