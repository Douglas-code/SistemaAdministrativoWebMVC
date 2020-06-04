using Microsoft.EntityFrameworkCore;

namespace SistemaAdministrativoWebMvc.Models.Data
{
    public class SisAdminMvcContext : DbContext
    {
        public SisAdminMvcContext(DbContextOptions<SisAdminMvcContext> options) : base(options) { }

        public DbSet<SistemaAdministrativoWebMvc.Models.Departamento> Departamento { get; set; }
    }
}