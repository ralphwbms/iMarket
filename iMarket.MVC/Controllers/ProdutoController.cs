using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using iMarket.Infra.Repositories;
using iMarket.ViewModels;
using iMarket.Models;

namespace iMarket.Controllers
{
	public class ProdutoController : Controller
	{
		private EFProdutoRepository produtoRep;
		public int PageSize = 4;

		public ProdutoController()
		{
			produtoRep = new EFProdutoRepository();
		}

		public ViewResult List(int supermercadoId = 0, string departamento = null, int pagina = 1)
		{

			supermercadoId = ((Supermercado)Session["Supermercado"]).Id;
			ViewBag.DepartamentoSelecionado = departamento == null ? "Todos Produtos" : departamento;

			ProdutosListViewModel model =
				new ProdutosListViewModel
				{

					Produtos = produtoRep.Produtos
							.Where(p => p.SupermercadoId == supermercadoId)
							.Where(p => departamento == null || p.Departamento.Nome == departamento)
							.OrderBy(p => p.Id)
							.Skip((pagina - 1) * PageSize)
							.Take(PageSize),

					PagingInfo = new PagingInfo
					{
						CurrentPage = pagina,
						ItemsPerPage = PageSize,
						TotalItems = departamento == null ?
						produtoRep.Produtos.Where(p => p.SupermercadoId == supermercadoId).Count() :
						produtoRep.Produtos.Where(p => p.SupermercadoId == supermercadoId && p.Departamento.Nome == departamento).Count()
					},

					DepartamentoIdAtual = departamento
				};

			return View(model);
		}
	}
}