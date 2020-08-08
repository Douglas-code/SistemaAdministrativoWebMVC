using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SistemaAdministrativoWebMvc.Models.Services;

namespace SistemaAdministrativoWebMvc.Controllers
{
    public class RegistroVendasController : Controller
    {
        private readonly RegistroVendasServices _registroVendasService;

        public RegistroVendasController(RegistroVendasServices registroVendasServices)
        {
            _registroVendasService = registroVendasServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples(DateTime? inicio, DateTime? fim)
        {
            if(!inicio.HasValue)
                inicio = new DateTime(DateTime.Now.Year, 1, 1);
            
            if(!fim.HasValue)
                fim = DateTime.Now;

            ViewData["inicio"] = inicio.Value.ToString("dd-MM-yyyy");
            ViewData["fim"] = fim.Value.ToString("dd-MM-yyyy");
            
            var result = await _registroVendasService.BuscaPorData(inicio, fim);

            return View(result);
        }

        public IActionResult BuscaAgrupada()
        {
            return View();
        }
    }
}