using Dapper;
using Reebonz.Dapper.Repository.Interfaces;
using Reebonz.Dapper.Repository.Models;
using Reebonz.Dapper.Repository.Parameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository
{
    /// <summary>
    /// class OrderRepository
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        ISQLConnectionProvider _Provider;
        public OrderRepository(ISQLConnectionProvider connectionProvider)
        {
            _Provider = connectionProvider;
        }

        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="transationID"></param>
        /// <returns></returns>
        public bool Add(OrderAddRptParameter parameter)
        {
            using (var conn = _Provider.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {

                        var PredictEffectRow = 1 + parameter.OrderDetails.Count;
                        var PhysicallyEffectRow = 0;
                        var sb = new StringBuilder();
                        var SQLParameters = new DynamicParameters();
                        sb.AppendLine(@"DECLARE @OrderID bigint;");
                        sb.AppendLine(@"INSERT INTO [Order] (TransactionID) VALUES(@TransactionID);");
                        sb.AppendLine(@"SET @OrderID = SCOPE_IDENTITY();");
                        SQLParameters.Add("TransactionID", parameter.TransactionID);
                        var index = 1;
                        foreach (var item in parameter.OrderDetails)
                        {
                            sb.AppendLine(@"INSERT INTO OrderDetail (OrderID, SKU, Amount, Price)");
                            sb.AppendLine($" VALUES(@OrderID, @SKU{index}, @Amount{index}, @Price{index})");
                            SQLParameters.Add($"SKU{index}", item.SKU);
                            SQLParameters.Add($"Amount{index}", item.Amount);
                            SQLParameters.Add($"Price{index}", item.Price);
                            index++;
                        }

                        PhysicallyEffectRow = conn.Execute(sb.ToString(), SQLParameters, trans);
                        if (PredictEffectRow == PhysicallyEffectRow)
                        {
                            trans.Commit();
                        }
                        else
                        {
                            trans.Rollback();
                        }
                        return PredictEffectRow == PhysicallyEffectRow;
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
        /// 新增訂單明細
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public bool AddDetail(List<OrderDetailBaseAddRptParameter> parameters)
        {
            var Result = false;
            using (var conn = _Provider.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {

                        var sb = new StringBuilder();
                        var sqlParameters = new DynamicParameters();
                        int counter = 1;
                        foreach (var item in parameters)
                        {
                            sb.AppendLine($"INSERT INTO [OrderDetail] (OrderID, SKU, Amount, Price) VALUES(@OrderID{counter}, @SKU{counter}, @Amount{counter}, @Price{counter});");
                            sqlParameters.Add($"OrderID{counter}", item.OrderID);
                            sqlParameters.Add($"SKU{counter}", item.SKU);
                            sqlParameters.Add($"Amount{counter}", item.Amount);
                            sqlParameters.Add($"Price{counter}", item.Price);
                            counter++;
                        }
                        Result = conn.Execute(sb.ToString(), sqlParameters) > 0;
                        if (Result)
                            trans.Commit();
                        else
                            trans.Rollback();
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
        /// 取得訂單
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public OrderModel Get(string transationID)
        {
            using (var conn = _Provider.GetConnection())
            {
                try
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(@"SELECT * FROM [Order] WHERE TransactionID = @TransactionID AND Enable != 0");
                    sb.AppendLine(@"SELECT * FROM [OrderDetail] ");

                    var SQLParameters = new DynamicParameters();
                    SQLParameters.Add("TransactionID", transationID);
                    var datas = conn.QueryMultiple(sb.ToString(), SQLParameters);
                    var Result = datas.ReadFirstOrDefault<OrderModel>();
                    if (Result != null)
                    {
                        var allDetails = datas.Read<OrderDetailModel>().ToList();
                        Result.OrderDetails = allDetails.FindAll(x => x.OrderID == Result.ID);
                    }
                    return Result;
                }
                catch (Exception ex)
                {
                    throw new Exception("資料庫發生錯誤", ex);
                }
            }
        }

        /// <summary>
        /// 修改訂單明細  
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public bool UpdateDetail(List<OrderDetailUpdateRptParameter> parameters)
        {
            using (var conn = _Provider.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        var sql = new StringBuilder();
                        var SQLParameters = new DynamicParameters();
                        int counter = 0;
                        foreach (var item in parameters)
                        {
                            sql.AppendLine($@"UPDATE OrderDetail SET Amount = @Amount{counter}, Price = @Price{counter} WHERE ID = @ID{counter};");
                            SQLParameters.Add($"Amount{counter}", item.Amount);
                            SQLParameters.Add($"Price{counter}", item.Price);
                            SQLParameters.Add($"ID{counter}", item.ID);
                            counter++;
                        }
                        var Result = conn.Execute(sql.ToString(), SQLParameters, trans) == counter;
                        if (Result)
                        {
                            trans.Commit();
                        }
                        else
                        {
                            trans.Rollback();
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
    }
}
