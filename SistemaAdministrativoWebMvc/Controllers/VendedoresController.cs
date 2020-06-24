using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoWebMvc.Models.Services;
using SistemaAdministrativoWebMvc.Models;
using SistemaAdministrativoWebMvc.Models.ViewModels;

namespace SistemaAdministrativoWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var list = _vendedorService.ListarVendedores();

            return View(list);
        }

        public IActionResult CadVendedor()
        {
            var departamentos = _departamentoService.ListarDepartamentos();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadVendedor(Vendedor vendedor)
        {
            _vendedorService.Inserir(vendedor);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteVendedor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendedorService.BuscarPorId(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteVendedor(int id)
        {
            _vendedorService.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DetalhesVendedor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendedorService.BuscarPorId(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}