using System;
using System.Linq;
using System.Web.Mvc;
using iMarket.Models;
using iMarket.Infra.Repositories;
using iMarket.Infra.Context;
using System.Data.Entity;

namespace iMarket.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private EFSupermercadoRepository supermercadoRepo;
        private EFDepartamentoRepository departamentoRepo;
        private EFUserRepository userRepo;

        public AdminController()
        {
            supermercadoRepo = new EFSupermercadoRepository();
            departamentoRepo = new EFDepartamentoRepository();
            userRepo = new EFUserRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Supermercado Actions
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
                var usuario = userRepo.Users
                .Where(u => u.UserName == supermercado.Usuario.UserName)
                .FirstOrDefault();

                if (usuario == null)
                {
                    TempData["error"] = "Usuário informado não existe!";
                    return View("Supermercado/Edit", supermercado);
                }
                else
                {
                    // remove o perfil 'Supermercado' do usuário antigo
                    userRepo.RemoveUserToRole(supermercado.UsuarioId, "Supermercado");
                    
                    // adiciona o perfil 'Supermercado' ao novo usuário
                    userRepo.AddUserToRole(usuario.Id, "Supermercado");

                    supermercado.UsuarioId = usuario.Id;

                    supermercadoRepo.SalvarSupermercado(supermercado);
                    TempData["message"] = "Alterações salvas com sucesso!";
                    return RedirectToAction("IndexSupermercado");
                }
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
        #endregion

        #region Departamento Actions
        public ActionResult IndexDepartamento()
        {
            var departamentos = departamentoRepo.Departamentos;

            return View("Departamento/Index", departamentos);
        }

        public ActionResult EditDepartamento(int Id)
        {
            Departamento departamento = departamentoRepo.Departamentos
                .FirstOrDefault(s => s.Id == Id);

            return View("Departamento/Edit", departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDepartamento(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                departamentoRepo.SalvarDepartamento(departamento);
                TempData["message"] = "Alterações salvas com sucesso!";
                return RedirectToAction("IndexDepartamento");
            }
            else
                return View("Departamento/Edit", departamento);
        }

        public ActionResult NewDepartamento()
        {
            return View("Departamento/New");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewDepartamento(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                departamentoRepo.SalvarDepartamento(departamento);
                TempData["message"] = "Alterações salvas com sucesso!";
                return RedirectToAction("IndexDepartamento");
            }
            else
                return View("Departamento/New", departamento);
        }


        public ActionResult DetailsDepartamento(int Id)
        {
            Departamento departamento = departamentoRepo.Departamentos
                .FirstOrDefault(s => s.Id == Id);

            return View("Departamento/Details", departamento);
        }

        public ActionResult DeleteDepartamento(int Id)
        {
            Departamento departamento = departamentoRepo.Departamentos
                .FirstOrDefault(s => s.Id == Id);

            return View("Departamento/Delete", departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDepartamento(Departamento departamento)
        {
            departamentoRepo.DeletarDepartamento(departamento.Id);
            TempData["message"] = "Departamento excluído com sucesso!";
            return RedirectToAction("IndexDepartamento");
        }
        #endregion

        #region Users Actions
        public ActionResult IndexUsers()
        {
            return View("User/Index", userRepo.Users);
        }
        #endregion
    }
}