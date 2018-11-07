using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository.Models
{
    /// <summary>
    /// class RefundContactModel
    /// </summary>
    public class RefundContactModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// RefundID
        /// </summary>
        public long RefundID { get; set; }

        /// <summary>
        /// 取件人名稱
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// 取件人地址
        /// </summary>
        public string SenderAddr { get; set; }

        /// <summary>
        /// 取件人電話
        /// </summary>
        public string SenderPhone { get; set; }
    }
}
