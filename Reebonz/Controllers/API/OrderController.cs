using AutoMapper;
using Reebonz.Models.Output;
using Reebonz.Models.Output.Api;
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
    /// class OrderController
    /// </summary>
    public class OrderController : BaseApiController
    {
        IOrderService _OrderService;
        public OrderController(IOrderService orderService)
        {
            _OrderService = orderService;
        }

        /// <summary>
        /// 取得訂單
        /// </summary>
        /// <param name="transationID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/Order/{transationID}")]
        public HttpResponseMessage Get(string transationID)
        {
            var ResponseStatus = HttpStatusCode.OK;
            var Result = new ResponseResult<OrderOutputModel>()
            {
                Description = string.Empty,
                Message = string.Empty,
            };
            try
            {
                Result.Data = Mapper.Map<OrderOutputModel>(_OrderService.Get(transationID));
            }
            catch (Exception)
            {
                Result.Message = "發生錯誤";
                Result.Description = "發生錯誤";
                ResponseStatus = HttpStatusCode.BadRequest;
            }
            return Request.CreateResponse(ResponseStatus, Result);
        }

        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/Order")]
        public HttpResponseMessage Create(OrderAddActionParameter parameter)
        {
            var ResponseStatus = HttpStatusCode.OK;
            var Resp = new ResponseResult<object>();
            if (!ModelState.IsValid)
            {
                GetValidationErrorResult();
            }
            try
            {
                _OrderService.Add(Mapper.Map<OrderAddParameterDTO>(parameter));
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
