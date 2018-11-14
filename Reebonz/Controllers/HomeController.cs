﻿using Reebonz.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reebonz.Controllers
{
    public class HomeController : Controller
    {
        IRefundService _RefundService;
        public HomeController(IRefundService refundService)
        {
            _RefundService = refundService;
        }
        public ActionResult Index()
        {
            _RefundService.Get();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}