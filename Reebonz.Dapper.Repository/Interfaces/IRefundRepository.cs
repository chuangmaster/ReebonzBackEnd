using Reebonz.Dapper.Repository.Models;
using Reebonz.Dapper.Repository.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository.Interfaces
{
    /// <summary>
    /// interface IRefundRepository
    /// </summary>
    public interface IRefundRepository
    {
        /// <summary>
        /// 取得所有退貨
        /// </summary>
        /// <returns></returns>
        List<RefundModel> Get();


        int Add(RefundAddRptParameter parameter);

        bool Update()

    }
}
