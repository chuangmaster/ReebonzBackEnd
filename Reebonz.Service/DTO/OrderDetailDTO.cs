using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Service.DTO
{
    /// <summary>
    /// class OrderDetailDTO
    /// </summary>
    public class OrderDetailDTO
    {

        /// <summary>
        /// ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 訂單ID
        /// </summary>
        public long OrderID { get; set; }

        /// <summary>
        /// SKU
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 售價
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 寫入時間
        /// </summary>
        public DateTime DateIn { get; set; }

    }
}
