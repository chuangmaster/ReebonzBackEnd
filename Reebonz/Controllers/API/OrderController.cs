using Reebonz.Models.Output;
using Reebonz.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reebonz.Controllers.API
{
    /// <summary>
    /// class OrderController
    /// </summary>
    public class OrderController : ApiController
    {
        IOrderService _OrderService;
        public OrderController(IOrderService orderService)
        {
            _OrderService = orderService;
        }
        [HttpGet]
        [Route("~/api/v1/Order/{transationID}")]
        public HttpResponseMessage Get(string transationID)
        {
            var Result = new ResponseResult<object>()
            {
                Description = string.Empty,
                Message = string.Empty,
                Data = _OrderService.Get(transationID)
            };

            return Request.CreateResponse(
                Result.Data != null ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
                Result);
        }
    }
}
