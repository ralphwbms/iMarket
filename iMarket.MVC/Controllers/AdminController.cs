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

        public ActionResult IndexSupermercado()
        {
            var supermercados = supermercadoRepo.Supermercados;

            return View("Supermercado/Index", supermercados);
        }

        public ActionResult EditSupermercado(int Id)
        {
            Supermercado supermercado = supermercadoRepo.Supermercados
                .FirstOrDefault(s => s.Id == Id);

            return View("Supermercado/Edit", supermercado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSupermercado(Supermercado supermercado)
        {
            if (ModelState.IsValid)
            {
                supermercadoRepo.SalvarSupermercado(supermercado);
                TempData["message"] = "Alterações salvas com sucesso!";
                return RedirectToAction("IndexSupermercado");
            }
            else
                return View("Supermercado/Edit", supermercado);
        }


        public ActionResult DetailsSupermercado(int Id)
        {
            Supermercado supermercado = supermercadoRepo.Supermercados
                .FirstOrDefault(s => s.Id == Id);

            return View("Supermercado/Details", supermercado);
        }

        public ActionResult DeleteSupermercado(int Id)
        {
            Supermercado supermercado = supermercadoRepo.Supermercados
                .FirstOrDefault(s => s.Id == Id);

            return View("Supermercado/Delete", supermercado);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSupermercado(Supermercado supermercado)
        {
            supermercadoRepo.DeletarSupermercado(supermercado.Id);
            TempData["message"] = "Supermercado excluído com sucesso!";
            return RedirectToAction("IndexSupermercado");
        }
    }
}