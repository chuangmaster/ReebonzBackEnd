using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository.Models
{
    /// <summary>
    /// class RefundDetailModel
    /// </summary>
    public class RefundDetailModel
    {

        /// <summary>
        /// ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Refund ID
        /// </summary>
        public long RefundID { get; set; }

        /// <summary>
        /// 商品編號
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 退款金額
        /// </summary>
        public decimal Price { get; set; }
    }
}
