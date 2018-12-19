using Reebonz.Models.Output;
using Reebonz.Models.Parameters;
using Reebonz.Service.DTO;
using Reebonz.Service.DTO.Parameters;
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
    /// class RefundController
    /// </summary>
    public class RefundController : ApiController
    {
        IRefundService _RefundService;
        IOrderService _OrderService;
        public RefundController(IRefundService refundService, IOrderService orderService)
        {
            _RefundService = refundService;
            _OrderService = orderService;
        }
        [HttpGet]
        [Route("~/api/v1/create/{transationID}")]
        public HttpResponseMessage Get(string transationID)
        {
            var Result = new ResponseResult<RefundDTO>()
            {
                Message = string.Empty,
                Description = string.Empty

            };
            Result.Data = _RefundService.Get().FirstOrDefault(x => x.TransationID == transationID);
            return Request.CreateResponse(Result != null ? HttpStatusCode.OK : HttpStatusCode.BadRequest, Result);
        }
        [HttpPost]
        [Route("~/api/v1/create")]
        public HttpResponseMessage Create(RefundAddActionParameter parameter)
        {
           
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
