using System;
namespace SistemaAdministrativoWebMvc.Models.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string message) : base(message)
        {
        }

    }
}