using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository.Parameters
{
    /// <summary>
    /// class OrderDetailUpdateRptParameter
    /// </summary>
    public class OrderDetailUpdateRptParameter
    {
        /// <summary>
        /// OrderDetail ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        public decimal Price { get; set; }
    }
}
