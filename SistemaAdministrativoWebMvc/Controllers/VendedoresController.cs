using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoWebMvc.Models.Services;
using SistemaAdministrativoWebMvc.Models;
using SistemaAdministrativoWebMvc.Models.ViewModels;
using SistemaAdministrativoWebMvc.Models.Services.Exceptions;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var list = await _vendedorService.ListarVendedores();

            return View(list);
        }

        public async Task<IActionResult> CadVendedor()
        {
            var departamentos = await _departamentoService.ListarDepartamentos();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadVendedor(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoService.ListarDepartamentos();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };

                return View(viewModel);
            }

            await _vendedorService.Inserir(vendedor);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteVendedor(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _vendedorService.BuscarPorId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVendedor(int id)
        {
            try
            {
                await _vendedorService.Remover(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message});
            }
        }

        public async Task<IActionResult> DetalhesVendedor(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _vendedorService.BuscarPorId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Encontrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> EditarVendedor(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = await _vendedorService.BuscarPorId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Departamento> departamentos = await _departamentoService.ListarDepartamentos();

            VendedorFormViewModel formViewModel = new VendedorFormViewModel
            { Vendedor = obj, Departamentos = departamentos };

            return View(formViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarVendedor(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoService.ListarDepartamentos();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };

                return View(viewModel);
            }

            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Ids não correspodem" });
            }

            try
            {
                await _vendedorService.Atualizar(vendedor);
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