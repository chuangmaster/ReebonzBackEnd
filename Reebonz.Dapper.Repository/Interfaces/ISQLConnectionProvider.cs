using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository.Interfaces
{
    /// <summary>
    /// interface ISQLConnectionProvider
    /// </summary>
    public interface ISQLConnectionProvider
    {
        /// <summary>
        /// 取得SQL Connection
        /// </summary>
        /// <returns></returns>
        IDbConnection GetConnection();
    }
}
