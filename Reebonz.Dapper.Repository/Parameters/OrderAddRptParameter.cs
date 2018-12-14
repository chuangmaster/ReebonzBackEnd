using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository.Parameters
{
    /// <summary>
    /// class OrderAddRptParameter
    /// </summary>
    public class OrderAddRptParameter
    {
        /// <summary>
        /// 訂單編號
        /// </summary>
        public string TransationID { get; set; }

        /// <summary>
        /// 訂單明細
        /// </summary>
        public List<OrderDetailAddRptParameter> OrderDetailCollection { get; set; }

        public OrderAddRptParameter()
        {
            OrderDetailCollection = new List<OrderDetailAddRptParameter>();
        }
    }
}
