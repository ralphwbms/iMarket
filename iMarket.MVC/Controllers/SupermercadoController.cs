using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
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
        [AllowAnonymous]
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

        [AllowAnonymous]
        public ActionResult Listar(string cidade)
        {
            var supermercados = supermercadoRep.Supermercados.Where(s => s.Cidade == cidade);
            return View(supermercados);
        }

        [AllowAnonymous]
        public ActionResult Selecionar(int supermercadoId)
        {
            var supermercado = supermercadoRep.Supermercados
                    .FirstOrDefault(s => s.Id == supermercadoId);

            Session["Supermercado"] = supermercado;
            return RedirectToAction("List", "Produto", new { supermercado.Id });
        }

        [AllowAnonymous]
        private Supermercado ObtemSupermercadoEscolhido()
        {
            return (Supermercado)Session["Supermercado"];
        }

        [AllowAnonymous]
        public PartialViewResult SelecaoSupermercado()
        {
            Supermercado supermercado = ObtemSupermercadoEscolhido();
            return PartialView(supermercado);
        }

        #region Produto Actions
        public ActionResult IndexProduto()
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

        public ActionResult DetailsProduto(int Id)
        {
            Produto produto = produtoRep.Produtos
                .FirstOrDefault(s => s.Id == Id);

            return View("Produto/Details", produto);
        }

        public ActionResult EditProduto(int Id)
        {
            Produto produto = produtoRep.Produtos
                .FirstOrDefault(s => s.Id == Id);

            var departamentos = departamentoRep.Departamentos.ToList();

            var viewModel = new EditProdutoViewModel()
            {
                Departamentos = departamentos,
                Produto = produto
            };

            return View("Produto/Edit", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                produtoRep.SalvarProduto(produto);
                TempData["message"] = "Alterações salvas com sucesso!";
                return RedirectToAction("IndexProduto");
            }
            else
                return View("Produto/Edit", produto);
        }

        public ActionResult DeleteProduto(int Id)
        {
            Produto produto = produtoRep.Produtos
                .FirstOrDefault(s => s.Id == Id);

            return View("Produto/Delete", produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduto(Produto produto)
        {
            produtoRep.DeletarProduto(produto.Id);
            TempData["message"] = "Produto excluído com sucesso!";
            return RedirectToAction("IndexProduto");
        }
        #endregion
    }
}