using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Service.DTO.Parameters
{
    /// <summary>
    /// class RefundAddDTOParameter
    /// </summary>
    public class RefundAddParameterDTO
    {
        /// <summary>
        /// 訂單編號
        /// </summary>
        public long OrderID { get; set; }

        /// <summary>
        /// 通知物流時間
        /// </summary>
        public DateTime ShipmentDate { get; set; }

        /// <summary>
        /// 客戶要求取件時間
        /// </summary>
        public DateTime AskDate { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 資料編輯者ID
        /// </summary>
        public Guid? UNo { get; set; }

        /// <summary>
        /// Case Number
        /// </summary>
        public string CaseNum { get; set; }

        /// <summary>
        /// 取件人名稱
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// 取件地址
        /// </summary>
        public string SenderAddr { get; set; }

        /// <summary>
        /// 取件人電話
        /// </summary>
        public string SenderPhone { get; set; }

        /// <summary>
        /// 退貨明細
        /// </summary>
        public List<RefundDetailAddParameterDTO> RefundDetails { get; set; }

        public class RefundDetailAddParameterDTO
        {
            /// <summary>
            /// SKU
            /// </summary>
            public string SKU { get; set; }
            /// <summary>
            /// 單價
            /// </summary>
            public decimal Price { get; set; }
            /// <summary>
            /// 數量
            /// </summary>
            public int Amount { get; set; }

        }
    }
}
