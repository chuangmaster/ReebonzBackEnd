using Reebonz.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Reebonz.Infrastructure.Filtter
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var response = new ResponseResult<object>()
            {
                Message = context.Exception.Message,
                Description = "發生錯誤"
            };
            context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, response);
        }
    }
}