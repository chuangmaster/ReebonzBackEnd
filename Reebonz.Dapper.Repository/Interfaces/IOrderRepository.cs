﻿using Reebonz.Dapper.Repository.Models;
using Reebonz.Dapper.Repository.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Dapper.Repository.Interfaces
{
    /// <summary>
    /// interface IOrderRepository
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// 取得訂單
        /// </summary>
        /// <param name="transationID"></param>
        /// <returns></returns>
        OrderModel Get(string transationID);

        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool Add(OrderAddRptParameter parameter);


        /// <summary>
        /// 新增訂單明細
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        bool AddDetail(List<OrderDetailBaseAddRptParameter> parameters);

        /// <summary>
        /// 修改訂單明細  
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        bool UpdateDetail(List<OrderDetailUpdateRptParameter> parameters);
    }
}
