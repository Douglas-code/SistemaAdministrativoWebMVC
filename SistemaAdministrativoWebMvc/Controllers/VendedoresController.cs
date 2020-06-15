using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoWebMvc.Models.Services;

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
    }
}