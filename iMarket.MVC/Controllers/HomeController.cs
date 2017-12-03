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
                    return RedirectToAction("Listar", "Supermercado", new { cidade = dadosCEP.cidade });
            }
            else
                return View();
        }

        public ActionResult Sobre()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }
    }
}