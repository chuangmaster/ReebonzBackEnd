using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository.Models
{
    /// <summary>
    /// class RefundLogisticsRecordModel
    /// </summary>
    public class RefundLogisticsRecordModel
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
        /// 公司收件日期
        /// </summary>
        public DateTime ReceiveDate { get; set; }

        /// <summary>
        /// 追蹤碼
        /// </summary>
        public string TrackNumber { get; set; }

        /// <summary>
        /// 寫入時間
        /// </summary>
        public DateTime DateIn { get; set; }
    }
}
