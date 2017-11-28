using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iMarket.Models;
using iMarket.Infra.Repositories;

namespace iMarket.Controllers
{
    [Authorize]
    public class SupermercadoController : Controller
    {
        private EFSupermercadoRepository supermercadoRep = new EFSupermercadoRepository();
        private EFProdutoRepository produtoRep = new EFProdutoRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Afiliacao()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Afiliacao(Supermercado supermercado)
        {
            if (ModelState.IsValid)
            {
                supermercado.Ativo = false;
                supermercado.DataCadastro = DateTime.Now;

                supermercadoRep.SalvarSupermercado(supermercado);

                return View("ConfirmacaoAfiliacao");
            }

            return View(supermercado);
        }

        public ActionResult IndexProdutos()
        {
            var produtos = produtoRep.ProdutosBySupermercado(3);
            return View("Produto/Index", produtos);
        }
    }
}