using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoWebMvc.Models.Services;
using SistemaAdministrativoWebMvc.Models.Services.Exceptions;
using SistemaAdministrativoWebMvc.Models;
using SistemaAdministrativoWebMvc.Models.ViewModels;
using System.Diagnostics;

namespace SistemaAdministrativoWebMvc.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly DepartamentoService _departamentoService;

        public DepartamentosController(DepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var list = _departamentoService.ListarDepartamentos();

            return View(list);
        }

        public IActionResult CadDepartamento()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadDepartamento(Departamento departamento)
        {
            if (!ModelState.IsValid)
            {
                return View(departamento);
            }

            _departamentoService.Inserir(departamento);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteDepartamento(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O ID não foi informado" });
            }

            var obj = _departamentoService.BuscaPorId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O ID não encontrado" });

            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDepartamento(int id)
        {
            _departamentoService.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DetalhesDepartamento(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O ID não foi informado" });

            }
            var obj = _departamentoService.BuscaPorId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O ID não foi encontrado" });

            }

            return View(obj);
        }

        public IActionResult EditarDepartamento(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O ID não foi informado" });
            }

            var obj = _departamentoService.BuscaPorId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O ID não foi encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarDepartamento(int id, Departamento departamento)
        {
            if (!ModelState.IsValid)
            {
                return View(departamento);
            }

            if (id != departamento.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Ids não correspodem" });
            }

            try
            {
                _departamentoService.Atualizar(departamento);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}