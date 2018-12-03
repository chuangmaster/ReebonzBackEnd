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
        /// <summary>
        /// 新增退貨
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool Add(RefundAddRptParameter parameter)
        {
            int Result = 0;
            using (var conn = new SqlConnection())
            {
                var sqlParameters = new DynamicParameters();
                var sql = new StringBuilder();
                sql.AppendLine(@"INSERT INTO Refund");
                sql.AppendLine(@"           ([OrderID]");
                sql.AppendLine(@"           ,[SenderName]");
                sql.AppendLine(@"           ,[SenderAddr]");
                sql.AppendLine(@"           ,[SenderPhone]");
                sql.AppendLine(@"           ,[AskDate]");


                sqlParameters.Add("OrderID", parameter.OrderID);
                sqlParameters.Add("SenderName", parameter.SenderName);
                sqlParameters.Add("SenderAddr", parameter.SenderAddr);
                sqlParameters.Add("SenderPhone", parameter.SenderPhone);
                sqlParameters.Add("AskDate", parameter.AskDate);

                var sqlParaString = new List<string>();
                if (!string.IsNullOrEmpty(parameter.CaseNum))
                {
                    sqlParameters.Add("CaseNum", parameter.CaseNum);
                    sqlParaString.Add("CaseNum");
                }

                if (!string.IsNullOrEmpty(parameter.Memo))
                {
                    sqlParameters.Add("Memo", parameter.Memo);
                    sqlParaString.Add("Memo");
                }

                if (parameter.ShipmentDate.HasValue)
                {
                    sqlParameters.Add("ShipmentDate", parameter.ShipmentDate.Value);
                    sqlParaString.Add("ShipmentDate");
                }

                if (parameter.UserID.HasValue)
                {
                    sqlParameters.Add("UserID", parameter.UserID.Value);
                    sqlParaString.Add("UserID");
                }


                sql.AppendLine(string.Join(",", sqlParaString.Select(x => $"{x} = @{x}")));

                sql.AppendLine(@") ");

                sql.AppendLine(@"VALUES (@OrderID, @Memo, @CaseNum, @SenderName, ");
                sql.AppendLine(@"@SenderAddr, @SenderPhone, @AskDate, @ShipmentDate, @UserID,");
                sql.AppendLine(string.Join(",", sqlParaString.Select(x => $" @{x}")));
                sql.AppendLine(")");

                Result = conn.Execute(sql.ToString(), sqlParameters);

                return Result > 0;
            }
        }

        /// <summary>
        /// 取得所有退款資料
        /// </summary>
        /// <returns></returns>
        public List<RefundModel> Get()
        {
            List<RefundModel> Result = null;
            using (var conn = new SqlConnection())
            {
                var sql = new StringBuilder();
                sql.AppendLine(@"SELECT * FROM Refund");
                sql.AppendLine(@"SELECT * FROM RefundDetail");

                var DataSet = conn.QueryMultiple(sql.ToString());

                Result = DataSet.Read<RefundModel>().ToList();

                if (Result != null && Result.Count > 0)
                {
                    var details = DataSet.Read<RefundDetailModel>().ToList();
                    Result.ForEach(x =>
                    {
                        x.RefundDetailCollection = details.FindAll(y => y.RefundID == x.ID);
                    });
                }

            }
            return Result;
        }


        public bool Update()
        {
            throw new NotImplementedException();
        }

        public RefundRepository()
        {

        }
    }
}
