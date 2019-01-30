using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Service.DTO
{
    /// <summary>
    /// class RefundDTO
    /// </summary>
    public class RefundDTO
    {
        /// <summary>
        /// The returns ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 訂單編號
        /// </summary>
        public string TransactionID { get; set; }

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
        /// 退款金額
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 資料編輯者ID
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Case Number
        /// </summary>
        public string CaseNum { get; set; }

        /// <summary>
        /// 資料寫入時間
        /// </summary>
        public DateTime DateIn { get; set; }

        /// <summary>
        /// 資料修改時間
        /// </summary>
        public DateTime ModifiedTime { get; set; }

        /// <summary>
        /// 資料存取狀態
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 被取件人名稱
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// 被取件人地址
        /// </summary>
        public string SenderAddr { get; set; }

        /// <summary>
        /// 被取件人電話
        /// </summary>
        public string SenderPhone { get; set; }

        /// <summary>
        /// 退貨明細
        /// </summary>
        public List<RefundDetailDTO> RefundDetails { get; set; }

        public RefundDTO()
        {
            this.RefundDetails = new List<RefundDetailDTO>();
        }
    }
}
