using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAdministrativoWebMvc.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage= "{0} é obrigatório")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamento()
        {
        }

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AdicionarVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public void RemoverVendedor(Vendedor vendedor)
        {
            Vendedores.Remove(vendedor);
        }

        public double TotalVendas(DateTime inicio, DateTime fim)
        {
            return Vendedores.Sum(v => v.TotalVendas(inicio, fim));
        }
    }
}