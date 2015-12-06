using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockOrder.Models;

namespace StockOrder.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Form()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Form(Stock stock)
        {
            if (ModelState.IsValid)                     // check server-side validation
            {
                return RedirectToAction("Details", stock);
            }
            else
            {
                return View();
            }
        }

        // display details of the company data
        public ActionResult Details(Stock stock)
        {
            return View(stock);
        }

    }

}
