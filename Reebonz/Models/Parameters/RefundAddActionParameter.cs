using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Models.Parameters
{
    /// <summary>
    /// class RefundAddActionParameter
    /// </summary>
    public class RefundAddActionParameter
    {
        /// <summary>
        /// 訂單編號
        /// </summary>
        [Required]
        public string OrderID { get; set; }

        /// <summary>
        /// 通知物流時間
        /// </summary>
        [Required]
        public string ShipmentDate { get; set; }

        /// <summary>
        /// 客戶要求取件時間
        /// </summary>
        [Required]
        public string AskDate { get; set; }

        /// <summary>
        /// 取件人名稱
        /// </summary>
        [Required]
        public string SenderName { get; set; }

        /// <summary>
        /// 取件地址
        /// </summary>
        [Required]
        public string SenderAddr { get; set; }

        /// <summary>
        /// 取件人電話
        /// </summary>
        [Required]
        public string SenderPhone { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// Case Number
        /// </summary>
        public string CaseNum { get; set; }

        /// <summary>
        /// 退貨明細
        /// </summary>
        public List<RefundDetail> RefundDetails { get; set; }

        public class RefundDetail
        {
            /// <summary>
            /// SKU
            /// </summary>
            [Required]
            public string SKU { get; set; }
            /// <summary>
            /// 單價
            /// </summary>
            [Required]
            public string Price { get; set; }
            /// <summary>
            /// 數量
            /// </summary>
            [Required]
            public string Amount { get; set; }
        }

    }
}
