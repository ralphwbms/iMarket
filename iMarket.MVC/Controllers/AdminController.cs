using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iMarket.Infra.Repositories;
using iMarket.Models;

namespace iMarket.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private EFSupermercadoRepository supermercadoRepo;

        public AdminController()
        {
            supermercadoRepo = new EFSupermercadoRepository();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}