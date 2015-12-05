using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockOrder.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Having trouble? Send us a message.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(string message)
        {
            // Todo: send message to Developer
            ViewBag.Message = "Thanks, we got your message!";

            return View();
        }
    }
}