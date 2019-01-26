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
        public string TransactionID { get; set; }

        /// <summary>
        /// 編輯者ID
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// 修改時間
        /// </summary>
        public DateTime ModifiedTime { get; set; }

        /// <summary>
        /// 資料存取狀態
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 寫入時間
        /// </summary>
        public DateTime DateIn { get; set; }

    }
}
