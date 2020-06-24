using System;
namespace SistemaAdministrativoWebMvc.Models.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string msg) : base(msg) { }
    }
}