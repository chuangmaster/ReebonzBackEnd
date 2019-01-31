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
        private ISQLConnectionProvider _Provider { get; set; }

        /// <summary>
        /// 新增退貨
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public int Add(RefundAddRptParameter parameter)
        {
            using (var conn = _Provider.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        int Result = 0;

                        var sqlParameters = new DynamicParameters();
                        var sql = new StringBuilder();

                        sql.AppendLine(@"DECLARE @refundID bigint;");
                        sql.AppendLine(@"INSERT INTO Refund");
                        sql.AppendLine(@"           ([OrderID]");
                        sql.AppendLine(@"           ,[SenderName]");
                        sql.AppendLine(@"           ,[SenderAddr]");
                        sql.AppendLine(@"           ,[SenderPhone]");
                        sql.AppendLine(@"           ,[AskDate]");
                        sql.AppendLine(@"           ,[ShipmentDate]");
                        sql.AppendLine(@"           ,[UserID]");
                        sql.AppendLine(@"           ,[CaseNum]");
                        sql.AppendLine(@"           ,[Memo] )");
                        sql.AppendLine(@"VALUES (@OrderID, @SenderName ");
                        sql.AppendLine(@", @SenderAddr, @SenderPhone, @AskDate, @ShipmentDate, @UserID");
                        sql.AppendLine(@", @Memo, @CaseNum)");
                        sql.AppendLine(@"SET @refundID = SCOPE_IDENTITY();");
                        sqlParameters.Add("OrderID", parameter.OrderID);
                        sqlParameters.Add("SenderName", parameter.SenderName);
                        sqlParameters.Add("SenderAddr", parameter.SenderAddr);
                        sqlParameters.Add("SenderPhone", parameter.SenderPhone);
                        sqlParameters.Add("AskDate", parameter.AskDate);
                        sqlParameters.Add("ShipmentDate", parameter.ShipmentDate);
                        sqlParameters.Add("UserID", parameter.UserID ?? default(Guid));
                        sqlParameters.Add("CaseNum", parameter.CaseNum);
                        sqlParameters.Add("Memo", parameter.Memo);


                        int index = 0;
                        parameter.RefundDetails.ForEach(d =>
                        {
                            sql.AppendLine($"INSERT INTO RefundDetail (RefundID, SKU, Price, Amount) VALUES(@refundID ,@SKU{index}, @Price{index}, @Amount{index});");
                            sqlParameters.Add($"SKU{index}", d.SKU);
                            sqlParameters.Add($"Price{index}", d.Price);
                            sqlParameters.Add($"Amount{index}", d.Amount);
                            index++;
                        });

                        Result = conn.Execute(sql.ToString(), sqlParameters, trans);
                        if (Result > 0)
                        {
                            trans.Commit();
                        }
                        return Result;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw new Exception("資料庫發生錯誤", ex);
                    }
                }
            }
        }

        /// <summary>
        /// 取得所有退款資料
        /// </summary>
        /// <returns></returns>
        public List<RefundModel> Get()
        {
            List<RefundModel> Result = new List<RefundModel>();
            using (var conn = _Provider.GetConnection())
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
                        x.RefundDetails = details.FindAll(y => y.RefundID == x.ID);
                    });
                }

            }
            return Result;
        }

        /// <summary>
        /// 更新退貨單資料
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            using (var conn = _Provider.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {


                    //conn.Execute();
                }
            }
            throw new NotImplementedException();
        }

        public RefundRepository(ISQLConnectionProvider connectionProvider)
        {
            _Provider = connectionProvider;
        }
    }
}
