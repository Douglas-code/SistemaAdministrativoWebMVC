using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoWebMvc.Models.Services;
using SistemaAdministrativoWebMvc.Models.Services.Exceptions;
using SistemaAdministrativoWebMvc.Models;
using SistemaAdministrativoWebMvc.Models.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SistemaAdministrativoWebMvc.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly DepartamentoService _departamentoService;

        public DepartamentosController(DepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _departamentoService.ListarDepartamentos();

            return View(list);
        }

        public IActionResult CadDepartamento()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadDepartamento(Departamento departamento)
        {
            if (!ModelState.IsValid)
            {
                return View(departamento);
            }

            await _departamentoService.Inserir(departamento);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteDepartamento(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O ID não foi informado" });
            }

            var obj = await _departamentoService.BuscaPorId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O ID não encontrado" });

            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            await _departamentoService.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DetalhesDepartamento(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O ID não foi informado" });

            }
            var obj = await _departamentoService.BuscaPorId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O ID não foi encontrado" });

            }

            return View(obj);
        }

        public async Task<IActionResult> EditarDepartamento(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O ID não foi informado" });
            }

            var obj = await _departamentoService.BuscaPorId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O ID não foi encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarDepartamento(int id, Departamento departamento)
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
                await _departamentoService.Atualizar(departamento);
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