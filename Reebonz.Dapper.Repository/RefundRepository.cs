using Dapper;
using Reebonz.Dapper.Repository.Interfaces;
using Reebonz.Dapper.Repository.Models;
using Reebonz.Dapper.Repository.Parameters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository
{
    /// <summary>
    /// class RefundRepository
    /// </summary>
    public class RefundRepository : IRefundRepository
    {
        public int Add(RefundAddRptParameter parameter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取得所有退款資料
        /// </summary>
        /// <returns></returns>
        public List<RefundModel> Get()
        {
            using (var con = new SqlConnection())
            {
                var sql = new StringBuilder();
                sql.AppendLine("SELECT * FRM Refund");
                sql.AppendLine("SELECT * FRM Refund");
                con.ExecuteReader(sql.ToString());
                con.Query<RefundModel>(sql.ToString());
            }
            throw new NotImplementedException();
        }


        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}
