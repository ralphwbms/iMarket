using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetHelper.AddressProvider.Providers;
using iMarket.Infra.Repositories;

namespace iMarket.Controllers
{
    public class HomeController : Controller
    {

        private EFSupermercadoRepository supermercadoRep = new EFSupermercadoRepository();

        public ActionResult Index(string cep = "")
        {
            if (!string.IsNullOrEmpty(cep))
            {
                var dadosCEP = CEPAberto.GetCepInfo(cep);

                if (dadosCEP == null)
                    return Content("CEP inválido!");
                else
                    return RedirectToAction("SelecaoSupermercado", "Home", new { cidade = dadosCEP.cidade });
            }
            else
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

        public ActionResult SelecaoSupermercado(string cidade)
        {
            var supermercados = supermercadoRep.Supermercados.Where(s => s.Cidade == cidade);
            return View(supermercados);
        }
    }
}