using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stock.Models;

namespace StockOrder.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Price()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Price (StockOrderClass p)
        {
            return View(p);
        }
    }
}