using Reebonz.Dapper.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository
{
    /// <summary>
    /// class SQLConnectionProvider
    /// </summary>
    public class SQLConnectionProvider : ISQLConnectionProvider
    {
        private string _ConnectSting;

        /// <summary>
        /// 取得SQL Connection
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetConnection()
        {
            var SQLConncetion = new SqlConnection(_ConnectSting);
            return SQLConncetion;
        }


        public SQLConnectionProvider(string connStr)
        {
            _ConnectSting = connStr;
        }
    }
}
