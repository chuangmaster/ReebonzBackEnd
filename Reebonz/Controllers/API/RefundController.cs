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
using static Reebonz.Models.Parameters.RefundAddActionParameter;

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
                var orderDTO = _OrderService.Get(parameter.TransactionID);
                var updateOrderDetails = new List<OrderDetailUpdateParameterDTO>();
                foreach (var item in parameter.RefundDetails)
                {
                    var orderDetail = orderDTO.OrderDetails.FirstOrDefault(x => x.SKU == item.SKU);
                    if (orderDetail.Amount - int.Parse(item.Amount) < 0)
                    {
                        throw new Exception("訂單數量有誤無法退貨");
                    }
                    updateOrderDetails.Add(new OrderDetailUpdateParameterDTO()
                    {
                        ID = orderDetail.ID,
                        Amount = orderDetail.Amount - int.Parse(item.Amount),
                        Price = orderDetail.Price
                    });
                }
                var serviceAddResult = _RefundService.Add(Mapper.Map<RefundAddParameterDTO>(parameter));
                if (serviceAddResult <= 0)
                {
                    Resp.Message = "新增失敗";
                    Resp.Description = "新增失敗";
                }
                var serviceUpdateResult = _OrderService.UpdateDetail(updateOrderDetails);
                if (!serviceUpdateResult)
                {
                    Resp.Message = "更新失敗";
                    Resp.Description = "更新失敗";
                }
                Resp.Message = "新增成功";
                Resp.Description = "新增成功";
                Resp.Data = serviceAddResult;
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
