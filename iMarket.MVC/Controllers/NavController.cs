using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iMarket.Infra.Repositories;

namespace iMarket.Controllers
{
    public class NavController : Controller
    {
        private EFDepartamentoRepository departamentoRep;

        public NavController()
        {
            departamentoRep = new EFDepartamentoRepository();
        }

        public PartialViewResult Menu(string departamento = null)
        {

            ViewBag.DepartamentoSelecionado = departamento == null ? "Todos Produtos" : departamento;

            IEnumerable<string> departamentos = departamentoRep.Departamentos
                                    .Select(d => d.Nome).ToList();

            return PartialView("MenuProdutos", departamentos);
        }
    }
}