using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository.Models
{
    /// <summary>
    /// class RefundModel
    /// </summary>
    public class RefundModel
    {
        /// <summary>
        /// The returns ID
        /// </summary>
        public long ID { get; set; }

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
        public int UserID { get; set; }

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
        /// 退貨聯絡資訊
        /// </summary>
        public RefundContactModel RefundContact { get; set; }

        /// <summary>
        /// 退貨物流資訊
        /// </summary>
        public RefundLogisticsRecordModel RefundLogisticsRecord { get; set; }
    }
}
