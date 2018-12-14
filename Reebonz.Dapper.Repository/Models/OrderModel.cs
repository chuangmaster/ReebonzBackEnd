using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository.Models
{
    /// <summary>
    /// class OrderModel
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 訂單編號
        /// </summary>
        public string TransationID { get; set; }
        /// <summary>
        /// 寫入日期
        /// </summary>
        public DateTime DateIn { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifiedTime { get; set; }
        /// <summary>
        /// 資料狀態
        /// </summary>
        public bool Enable { get; set; }

    }
}
