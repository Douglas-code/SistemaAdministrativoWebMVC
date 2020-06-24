using SistemaAdministrativoWebMvc.Models.Data;
using System.Collections.Generic;
using System.Linq;
using SistemaAdministrativoWebMvc.Models.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

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
            return _context.Departamento.ToList();
        }

        public void Inserir(Departamento obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Departamento BuscaPorId(int id)
        {
            return _context.Departamento.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remover(int id)
        {
            var obj = _context.Departamento.Find(id);
            _context.Departamento.Remove(obj);
            _context.SaveChanges();
        }

        public void Atualizar(Departamento obj)
        {
            if (!(_context.Departamento.Any(x => x.Id == obj.Id)))
            {
                throw new NotFoundException("Id nao encontrado");
            }

            try
            {
                _context.Departamento.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}