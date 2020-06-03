using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoWebMvc.Models;

namespace SistemaAdministrativoWebMvc.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> departamentos = new List<Departamento>();
            departamentos.Add(new Departamento(1, "Eletronicos"));
            departamentos.Add(new Departamento(2, "Moda"));

            return View(departamentos);
        }
    }
}