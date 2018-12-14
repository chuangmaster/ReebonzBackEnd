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
                    var PredictEffectRow = 1 + parameter.OrderDetailCollection.Count;
                    var PhysicallyEffectRow = 0;
                    var sb = new StringBuilder();
                    var SQLParameters = new DynamicParameters();
                    sb.AppendLine(@"DECLARE @OrderID bigint;");
                    sb.AppendLine(@"INSERT INTO [Order] (TransationID) VALUES(@TransationID);");
                    sb.AppendLine(@"SET @OrderID = SCOPE_IDENTITY();");
                    SQLParameters.Add("TransationID", parameter.TransationID);
                    var index = 1;
                    foreach (var item in parameter.OrderDetailCollection)
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
            }
        }

        public bool AddDetail()
        {
            var Result = false;
            using (var conn = _Provider.GetConnection())
            {
                var sb = new StringBuilder();
                sb.AppendLine(@"INSERT INTO [OrderDetail] (OrderID, SKU, Amount, Price) VALUES(@OrderID, @SKU, @Amount, @Price);");
                var sqlParameters = new DynamicParameters();
                sqlParameters.Add("OrderID");
                sqlParameters.Add("SKU");
                sqlParameters.Add("Amount");
                sqlParameters.Add("Price");


                Result = conn.Execute(sb.ToString(), sqlParameters) > 0;

                return Result;
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
                var sb = new StringBuilder();
                sb.AppendLine(@"SELECT * FROM Order WHERE TransationID = @TransationID AND Enable != 0");
                var SQLParameters = new DynamicParameters();
                SQLParameters.Add("TransationID", transationID);
                var Result = conn.QueryFirst<OrderModel>(sb.ToString(), SQLParameters);
                return Result;
            }
        }
    }
}
