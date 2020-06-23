using System.Collections.Generic;

namespace SistemaAdministrativoWebMvc.Models.ViewModels
{
    public class VendedorFormViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamentos{ get; set; }
    }
}