using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iMarket.Infra.Repositories;
using iMarket.Models;
using iMarket.ViewModels;

namespace iMarket.Controllers
{
    [Authorize(Roles = "Admin")]
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

        public ActionResult SupermercadoIndex()
        {
            var supermercados = supermercadoRepo.Supermercados;

            return View("Supermercado/Index", supermercados);
        }
    }
}