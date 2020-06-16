using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoWebMvc.Models.Services;
using SistemaAdministrativoWebMvc.Models;

namespace SistemaAdministrativoWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private VendedorService _vendedorService;

        public VendedoresController(VendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }

        public IActionResult Index()
        {
            var list = _vendedorService.ListarVendedores();

            return View(list);
        }

        public IActionResult CadVendedor()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadVendedor(Vendedor vendedor)
        {
            _vendedorService.Inserir(vendedor);

            return RedirectToAction(nameof(Index));
        }
    }
}