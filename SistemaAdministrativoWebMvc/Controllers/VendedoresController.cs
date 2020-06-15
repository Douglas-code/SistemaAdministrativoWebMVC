using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoWebMvc.Models.Data;
using System.Linq;

namespace SistemaAdministrativoWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly SisAdminMvcContext _context;

        public VendedoresController(SisAdminMvcContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}