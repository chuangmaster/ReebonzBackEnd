using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Service.DTO
{
    /// <summary>
    /// class RefundDetailDTO
    /// </summary>
    public class RefundDetailDTO
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
        /// 退款金額
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 追蹤碼
        /// </summary>
        public string TrackNumber { get; set; }

    }
}
