using SistemaAdministrativoWebMvc.Models.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SistemaAdministrativoWebMvc.Models.Services.Exceptions;
using System.Threading.Tasks;

namespace SistemaAdministrativoWebMvc.Models.Services
{
    public class VendedorService
    {
        private readonly SisAdminMvcContext _context;

        public VendedorService(SisAdminMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> ListarVendedores()
        {
            return await _context.Vendedor.OrderBy(obj => obj.Id).ToListAsync();
        }

        public async Task Inserir(Vendedor obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> BuscarPorId(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task Remover(int id)
        {
            try
            {
                var obj = await _context.Vendedor.FindAsync(id);
                _context.Vendedor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task Atualizar(Vendedor obj)
        {
            if (!(await _context.Vendedor.AnyAsync(x => x.Id == obj.Id)))
            {
                throw new NotFoundException("Id não encontrado");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Impossível deletar esse vendedor");
            }
        }
    }
}