using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Service.DTO
{
    /// <summary>
    /// class RefundSingaporeRecordDTO
    /// </summary>
    public class RefundSingaporeRecordDTO
    {
        /// <summary>
        /// ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// RefundRecordID
        /// </summary>
        public int RefundRecordID { get; set; }

        /// <summary>
        /// 寫入時間
        /// </summary>
        public DateTime DateIn { get; set; }

        /// <summary>
        /// 裝箱編號
        /// </summary>
        public int PackageNumber { get; set; }

        /// <summary>
        /// Invocie時間(裝箱時間)
        /// </summary>
        public DateTime InvoiceDateTime { get; set; }


    }
}
