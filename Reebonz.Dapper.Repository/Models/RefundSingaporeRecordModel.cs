using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository.Models
{
    /// <summary>
    /// class RefundSingaporeRecordModel
    /// </summary>
    public class RefundSingaporeRecordModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 退貨明細ID
        /// </summary>
        public int RefundDetailID { get; set; }

        /// <summary>
        /// 裝箱編號
        /// </summary>
        public int PackageNumber { get; set; }

        /// <summary>
        /// Invocie時間(裝箱時間)-修改時間
        /// </summary>
        public DateTime ModifiedTime { get; set; }

        /// <summary>
        /// 寫入時間
        /// </summary>
        public DateTime DateIn { get; set; }

        /// <summary>
        /// 編輯者ID
        /// </summary>
        public Guid UserID { get; set; }

    }
}
