using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoWebMvc.Models.Data;
using System.Linq;

namespace SistemaAdministrativoWebMvc.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly SisAdminMvcContext _context;

        public DepartamentosController(SisAdminMvcContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var departamentos = _context.Departamento.Where(d => d.Id > 0).ToList();
            
            return View(departamentos);
        }
    }
}