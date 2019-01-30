using AutoMapper;
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
    public class RefundController : BaseApiController
    {
        IRefundService _RefundService;
        IOrderService _OrderService;
        public RefundController(IRefundService refundService, IOrderService orderService)
        {
            _RefundService = refundService;
            _OrderService = orderService;
        }
        [HttpGet]
        [Route("~/api/v1/create/{transactionID}")]
        public HttpResponseMessage Get(string transactionID)
        {
            var Result = new ResponseResult<RefundDTO>()
            {
                Message = string.Empty,
                Description = string.Empty

            };
            Result.Data = _RefundService.Get().FirstOrDefault(x => x.TransactionID == transactionID);
            return Request.CreateResponse(Result != null ? HttpStatusCode.OK : HttpStatusCode.BadRequest, Result);
        }
        [HttpPost]
        [Route("~/api/v1/refund")]
        public HttpResponseMessage Create(RefundAddActionParameter parameter)
        {
            var ResponseStatus = HttpStatusCode.OK;
            var Resp = new ResponseResult<object>();
            if (!ModelState.IsValid)
            {
                GetValidationErrorResult();
            }
            try
            {
                var serviceResult = _RefundService.Add(Mapper.Map<RefundAddParameterDTO>(parameter));
                if (serviceResult > 0)
                {
                    Resp.Data = serviceResult;
                    Resp.Message = "新增成功";
                    Resp.Description = "新增成功";
                }
            }
            catch (Exception ex)
            {
                Resp.Message = "發生錯誤";
                Resp.Description = "發生錯誤";
                ResponseStatus = HttpStatusCode.BadRequest;
            }
            return Request.CreateResponse(ResponseStatus, Resp);
        }
    }
}
