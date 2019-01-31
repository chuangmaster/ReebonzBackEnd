using AutoMapper;
using Reebonz.Models.Output;
using Reebonz.Models.Parameters;
using Reebonz.Service.DTO.Parameters;
using Reebonz.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Reebonz.Controllers.API
{
    /// <summary>
    /// class OrderDetailController
    /// </summary>
    public class OrderDetailController : BaseApiController
    {
        IOrderService _OrderService;
        [HttpPut]
        [Route("~/api/v1/OrderDetail")]
        public HttpResponseMessage UpdateOrderDetail(OrderDetailUpdateActionParameter parameter)
        {
            var ResponseStatus = HttpStatusCode.BadRequest;
            var Resp = new ResponseResult<object>();
            try
            {
                var serviceResult = _OrderService.UpdateDetail(Mapper.Map<List<OrderDetailUpdateParameterDTO>>(parameter.OrderDeatils));
                if (serviceResult)
                {
                    Resp.Message = "更新成功";
                    Resp.Description = "更新成功";
                }
            }
            catch (Exception)
            {
                Resp.Message = "發生錯誤";
                Resp.Description = "發生錯誤";
                ResponseStatus = HttpStatusCode.BadRequest;
            }
            return Request.CreateResponse(ResponseStatus, Resp);
        }

        public OrderDetailController(IOrderService orderService)
        {
            _OrderService = orderService;
        }
    }
}