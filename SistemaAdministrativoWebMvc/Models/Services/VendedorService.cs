using SistemaAdministrativoWebMvc.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAdministrativoWebMvc.Models.Services
{
    public class VendedorService
    {
        private readonly SisAdminMvcContext _context;

        public VendedorService(SisAdminMvcContext context)
        {
            _context = context;
        }

        public List<Vendedor> ListarVendedores()
        {
            return _context.Vendedor.ToList();
        }
    }
}