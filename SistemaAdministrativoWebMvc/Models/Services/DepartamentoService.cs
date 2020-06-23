using SistemaAdministrativoWebMvc.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAdministrativoWebMvc.Models.Services
{
    public class DepartamentoService
    {
        private readonly SisAdminMvcContext _context;

        public DepartamentoService(SisAdminMvcContext context)
        {
            _context = context;
        }

        public List<Departamento> ListarDepartamentos()
        {
            return _context.Departamento.OrderBy(d => d.Nome).ToList();
        }

        public void Inserir(Departamento obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}