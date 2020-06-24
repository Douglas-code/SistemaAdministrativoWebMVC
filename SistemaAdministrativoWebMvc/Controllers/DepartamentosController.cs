using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoWebMvc.Models.Services;
using SistemaAdministrativoWebMvc.Models;

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
            _departamentoService.Inserir(departamento);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteDepartamento(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _departamentoService.BuscaPorId(id.Value);

            if (obj == null)
            {
                return NotFound();
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
    }
}