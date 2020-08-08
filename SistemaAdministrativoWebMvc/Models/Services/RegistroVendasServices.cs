using System;
using SistemaAdministrativoWebMvc.Models.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAdministrativoWebMvc.Models.Services
{
    public class RegistroVendasServices
    {
        private readonly SisAdminMvcContext _context;

        public RegistroVendasServices(SisAdminMvcContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroVendas>> BuscaPorData(DateTime? inicio, DateTime? fim)
        {
            var result = from obj in _context.RegistroVendas select obj;

            if (inicio.HasValue)
                result = result.Where(x => x.Data >= inicio.Value);

            if (fim.HasValue)
                result = result.Where(x => x.Data <= fim.Value);

            return await result.Include(x => x.Vendedor)
            .Include(x => x.Vendedor.Departamento)
            .OrderByDescending(x => x.Data)
            .ToListAsync();
        }

    }
}