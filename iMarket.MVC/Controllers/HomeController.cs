﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iMarket.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string cep = "")
        {
            if (cep.Equals("99999999"))
                return Content("CEP Correto!");
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