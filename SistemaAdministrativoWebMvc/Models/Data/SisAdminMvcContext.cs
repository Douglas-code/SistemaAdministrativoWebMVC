using Microsoft.EntityFrameworkCore;

namespace SistemaAdministrativoWebMvc.Models.Data
{
    public class SisAdminMvcContext : DbContext
    {
        public SisAdminMvcContext(DbContextOptions<SisAdminMvcContext> options) : base(options) { }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Vendedor> Vendedor{get; set;}
        public DbSet<RegistroVendas> RegistroVendas {get; set;}
    }
}
