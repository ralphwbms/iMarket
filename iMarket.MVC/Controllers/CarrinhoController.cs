using System.Linq;
using System.Web.Mvc;
using iMarket.Models;
using iMarket.ViewModels;
using iMarket.Infra.Repositories;

namespace iMarket.Controllers
{
    public class CarrinhoController : Controller
    {
        private EFProdutoRepository produtoRep;
        private ProcessarOrdemEmail processarOrdem;

        public CarrinhoController()
        {
            produtoRep = new EFProdutoRepository();
            processarOrdem = new ProcessarOrdemEmail(new EmailSettings());
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CarrinhoIndexViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectResult AdicionarAoCarrinho(int Id, string returnUrl)
        {
            Produto produto = produtoRep.Produtos
                .FirstOrDefault(p => p.Id == Id);

            if (produto != null)
            {
                ObterCarrinho().AddItem(produto, 1);
            }
            return Redirect(returnUrl);
        }

        public RedirectToRouteResult RemoverDoCarrinho(int Id, string returnUrl)
        {
            Produto product = produtoRep.Produtos
                .FirstOrDefault(p => p.Id == Id);

            if (product != null)
            {
                ObterCarrinho().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Carrinho ObterCarrinho()
        {
            Carrinho carrinho = (Carrinho)Session["Carrinho"];
            if (carrinho == null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }
            return carrinho;
        }

        public PartialViewResult Sumario(Carrinho carrinho)
        {
            carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }

        public ViewResult Checkout(DetalhesEntrega detalhesEntrega)
        {
            Carrinho carrinho = ObterCarrinho();

            if (carrinho.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Desculpe, seu carrinho está vazio!");
            }

            if (ModelState.IsValid)
            {
                processarOrdem.ProcessOrder(carrinho, detalhesEntrega);
                carrinho.Clear();
                return View("Finalizado");
            }
            else
            {
                return View(new DetalhesEntrega());
            }
        }

        //[HttpPost]
        //public ViewResult Checkout()
        //{
        //    return View(new DetalhesEntrega());
        //}
    }
}