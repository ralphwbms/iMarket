using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iMarket.Models;
using iMarket.ViewModels;
using iMarket.Infra.Repositories;
using Microsoft.AspNet.Identity;

namespace iMarket.Controllers
{
    [Authorize(Roles = "Supermercado")]
    public class SupermercadoController : Controller
    {
        private EFSupermercadoRepository supermercadoRep = new EFSupermercadoRepository();
        private EFProdutoRepository produtoRep = new EFProdutoRepository();
        private EFUserRepository userRep = new EFUserRepository();
        private EFDepartamentoRepository departamentoRep = new EFDepartamentoRepository();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
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
            string userId = User.Identity.GetUserId();
            int supermercadoId = supermercadoRep.LocalizarPorUserId(userId).Id;

            var produtos = produtoRep.ProdutosBySupermercado(supermercadoId);
            return View("Produto/Index", produtos);
        }

        public ActionResult NewProduto()
        {
            var departamentos = departamentoRep.Departamentos.ToList();
            var produto = new Produto();

            var viewModel = new NewProdutoViewModel()
            {
                Departamentos = departamentos,
                Produto = produto
            };

            return View("Produto/New", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewProduto(Produto produto)
        {
            string userId = User.Identity.GetUserId();
            int supermercadoId = supermercadoRep.LocalizarPorUserId(userId).Id;

            produto.SupermercadoId = supermercadoId;

            produtoRep.SalvarProduto(produto);

            var produtos = produtoRep.ProdutosBySupermercado(supermercadoId);

            return View("Produto/Index", produtos);
        }

        [AllowAnonymous]
        public ActionResult Listar(string cidade)
        {
            var supermercados = supermercadoRep.Supermercados.Where(s => s.Cidade == cidade);
            return View(supermercados);
        }

        [AllowAnonymous]
        public ActionResult Selecionar(int supermercadoId)
        {
            Session["supermercadoId"] = supermercadoId;
            return RedirectToAction("List", "Produto", new { supermercadoId });
        }
    }
}