using Reebonz.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reebonz.Controllers
{
    public class RefundController : Controller
    {
        IRefundService _RefundService;
        public RefundController(IRefundService refundService)
        {
            _RefundService = refundService;
        }

        [Route("~/Refund")]
        public ActionResult Index()
        {
            var model = _RefundService.Get();
            return View(model);
        }

        [Route("~/Refund/Detail/{id}")]
        public ActionResult Detail(long id)
        {
            var model = _RefundService.Get().FirstOrDefault(x => x.ID == id);
            if (model == null)
            {
                ViewBag.errorMsg = "找不到內容...";
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}