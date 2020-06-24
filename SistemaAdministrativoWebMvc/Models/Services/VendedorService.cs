using SistemaAdministrativoWebMvc.Models.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SistemaAdministrativoWebMvc.Models.Services.Exceptions;

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
            return _context.Vendedor.OrderBy(obj => obj.Id).ToList();
        }

        public void Inserir(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendedor BuscarPorId(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remover(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }

        public void Atualizar(Vendedor obj)
        {
            if (!(_context.Vendedor.Any(x => x.Id == obj.Id)))
            {
                throw new NotFoundException("Id não encontrado");
            }
            
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}