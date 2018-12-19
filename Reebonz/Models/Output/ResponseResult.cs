using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reebonz.Models.Output
{
    /// <summary>
    /// class ResponseResult
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseResult<T>
    {
        /// <summary>
        /// 資料
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }
    }
}