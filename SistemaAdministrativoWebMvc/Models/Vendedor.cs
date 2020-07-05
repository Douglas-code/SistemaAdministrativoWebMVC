using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SistemaAdministrativoWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ser entre {2} e {1} caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "{0} obrigatório")]
        [Range(100.0, 50000000.00, ErrorMessage = "{0} deve ser entre {1} e {2}")]
        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]

        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }
        public ICollection<RegistroVendas> Vendas { get; set; } = new List<RegistroVendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionarVenda(RegistroVendas venda)
        {
            Vendas.Add(venda);
        }

        public void RemoverVenda(RegistroVendas venda)
        {
            Vendas.Remove(venda);
        }

        public double TotalVendas(DateTime inicio, DateTime fim)
        {
            return Vendas.Where(v => v.Data >= inicio && v.Data <= fim).Sum(v => v.Valor);
        }

    }
}