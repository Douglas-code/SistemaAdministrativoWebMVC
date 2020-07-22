using SistemaAdministrativoWebMvc.Models.Data;
using System.Collections.Generic;
using System.Linq;
using SistemaAdministrativoWebMvc.Models.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace SistemaAdministrativoWebMvc.Models.Services
{
    public class DepartamentoService
    {
        private readonly SisAdminMvcContext _context;

        public DepartamentoService(SisAdminMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> ListarDepartamentos()
        {
            return await _context.Departamento.ToListAsync();
        }

        public async Task Inserir(Departamento obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Departamento> BuscaPorId(int id)
        {
            return await _context.Departamento.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task Remover(int id)
        {
            var obj = await _context.Departamento.FindAsync(id);
            _context.Departamento.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Departamento obj)
        {
            if (!(await _context.Departamento.AnyAsync(x => x.Id == obj.Id)))
            {
                throw new NotFoundException("Id nao encontrado");
            }

            try
            {
                _context.Departamento.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}