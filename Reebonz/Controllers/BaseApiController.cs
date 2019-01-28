using Reebonz.Infrastructure.Filtter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Reebonz.Controllers
{
    [CustomExceptionFilter]
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// 取得Parameter驗證錯誤結果
        /// </summary>
        protected void GetValidationErrorResult()
        {
            if (!ModelState.IsValid)
            {
                var errorMessage = new StringBuilder();
                var errors = ModelState.Values.SelectMany(x => x.Errors).ToList();
                errors.ForEach(x => { errorMessage.AppendLine(x.ErrorMessage.ToString()); });
                throw new Exception(errorMessage.ToString());
            }

        }

    }
}