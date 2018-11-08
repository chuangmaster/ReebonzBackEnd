using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository.Models
{
    /// <summary>
    /// class RefundRecordModel
    /// </summary>
    public class RefundRecordModel
    {

        public long ID { get; set; }

        public long RefundID { get; set; }

        public DateTime ReceiveDate { get; set; }

        public string TrackNumber { get; set; }

        public DateTime DateIn { get; set; }
    }
}
