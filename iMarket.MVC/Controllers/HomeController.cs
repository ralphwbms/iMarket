﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iMarket.AddressProvider.Providers;
using iMarket.Models;
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

            Supermercado supermercado = new Supermercado();

            if (Session["Supermercado"] != null)
                supermercado = (Supermercado)Session["supermercado"];

            if (supermercado.Id != 0 )
                return RedirectToAction("Selecionar", "Supermercado", new { supermercadoId = supermercado.Id });

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