using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository.Models
{
    /// <summary>
    /// class OrderDetailModel
    /// </summary>
    public class OrderDetailModel
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
        /// 數量
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// 價格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 資料存取狀態
        /// </summary>
        public bool Enable { get; set; }
    }
}
