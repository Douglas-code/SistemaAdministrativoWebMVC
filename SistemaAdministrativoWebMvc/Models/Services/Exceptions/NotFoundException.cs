using System;

namespace SistemaAdministrativoWebMvc.Models.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string msg) : base(msg) { }
    }
}