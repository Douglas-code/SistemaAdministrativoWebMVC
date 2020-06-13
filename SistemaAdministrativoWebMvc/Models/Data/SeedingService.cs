using System.Linq;
using System;
using SistemaAdministrativoWebMvc.Models.Enums;

namespace SistemaAdministrativoWebMvc.Models.Data
{
    public class SeedingService
    {
        private SisAdminMvcContext _context;

        public SeedingService(SisAdminMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departamento.Any() || _context.Vendedor.Any() || _context.RegistroVendas.Any())
            {
                return;
            }

            Departamento d1 = new Departamento(1, "Computadores");
            Departamento d2 = new Departamento(2, "Eletronicos");
            Departamento d3 = new Departamento(3, "Moda");
            Departamento d4 = new Departamento(4, "Livros");

            Vendedor v1 = new Vendedor(1, "Alex Alves", "alxalv@gmail.com", new DateTime(1998, 04, 21), 1000.00, d1);
            Vendedor v2 = new Vendedor(2, "Maria Jose", "mj@gmail.com", new DateTime(1979, 11, 13), 2500.00, d2);
            Vendedor v3 = new Vendedor(3, "Antonio Matos", "antmat@gmail.com", new DateTime(1988, 10, 12), 2505.00, d3);
            Vendedor v4 = new Vendedor(4, "Marcos Paulo", "mcpa@gmail.com", new DateTime(1999, 11, 11), 2000.00, d4);
            Vendedor v5 = new Vendedor(5, "Vitoria Taveira", "vitoriatav@gmail.com", new DateTime(2000, 07, 20), 12000.00, d3);
            Vendedor v6 = new Vendedor(6, "Eduardo Ramos", "eduramos@gmail.com", new DateTime(1996, 10, 25), 1568.00, d1);

            RegistroVendas r1 = new RegistroVendas(1, new DateTime(2018, 09, 25), 1100.00, StatusVendas.Faturado, v1);
            RegistroVendas r2 = new RegistroVendas(2, new DateTime(2018, 09, 26), 2000.00, StatusVendas.Faturado, v2);
            RegistroVendas r3 = new RegistroVendas(3, new DateTime(2018, 09, 30), 250.25, StatusVendas.Faturado, v5);
            RegistroVendas r4 = new RegistroVendas(4, new DateTime(2018, 10, 01), 500.50, StatusVendas.Faturado, v3);
            RegistroVendas r5 = new RegistroVendas(5, new DateTime(2018, 10, 02), 950.5, StatusVendas.Faturado, v4);
            RegistroVendas r6 = new RegistroVendas(6, new DateTime(2018, 10, 25), 1212, StatusVendas.Faturado, v6);
            RegistroVendas r7 = new RegistroVendas(7, new DateTime(2018, 11, 25), 1100.00, StatusVendas.Faturado, v1);
            RegistroVendas r8 = new RegistroVendas(8, new DateTime(2018, 11, 26), 2000.00, StatusVendas.Faturado, v2);
            RegistroVendas r9 = new RegistroVendas(9, new DateTime(2018, 11, 30), 250.25, StatusVendas.Faturado, v5);
            RegistroVendas r10 = new RegistroVendas(10, new DateTime(2018, 12, 01), 500.50, StatusVendas.Faturado, v3);
            RegistroVendas r11 = new RegistroVendas(11, new DateTime(2018, 12, 02), 950.5, StatusVendas.Faturado, v4);
            RegistroVendas r12 = new RegistroVendas(12, new DateTime(2018, 12, 25), 1212, StatusVendas.Faturado, v6);
            RegistroVendas r13 = new RegistroVendas(13, new DateTime(2019, 01, 25), 1100.00, StatusVendas.Faturado, v1);
            RegistroVendas r14 = new RegistroVendas(14, new DateTime(2019, 01, 26), 2000.00, StatusVendas.Faturado, v2);
            RegistroVendas r15 = new RegistroVendas(15, new DateTime(2019, 01, 30), 250.25, StatusVendas.Faturado, v5);
            RegistroVendas r16 = new RegistroVendas(16, new DateTime(2019, 03, 01), 500.50, StatusVendas.Faturado, v3);
            RegistroVendas r17 = new RegistroVendas(17, new DateTime(2019, 03, 02), 950.5, StatusVendas.Faturado, v4);
            RegistroVendas r18 = new RegistroVendas(18, new DateTime(2019, 10, 25), 1212, StatusVendas.Faturado, v6);
            RegistroVendas r19 = new RegistroVendas(19, new DateTime(2019, 11, 25), 1100.00, StatusVendas.Faturado, v1);
            RegistroVendas r20 = new RegistroVendas(20, new DateTime(2019, 11, 26), 2000.00, StatusVendas.Faturado, v2);
            RegistroVendas r21 = new RegistroVendas(21, new DateTime(2019, 11, 30), 250.25, StatusVendas.Faturado, v5);
            RegistroVendas r22 = new RegistroVendas(22, new DateTime(2019, 12, 01), 500.50, StatusVendas.Faturado, v3);
            RegistroVendas r23 = new RegistroVendas(23, new DateTime(2019, 12, 02), 950.5, StatusVendas.Faturado, v4);
            RegistroVendas r24 = new RegistroVendas(24, new DateTime(2019, 12, 25), 1212, StatusVendas.Faturado, v6);
            RegistroVendas r25 = new RegistroVendas(25, new DateTime(2020, 01, 05), 2515.00, StatusVendas.Pendente, v1);
            RegistroVendas r26 = new RegistroVendas(26, new DateTime(2020, 01, 05), 2515.00, StatusVendas.Pendente, v1);
            RegistroVendas r27 = new RegistroVendas(27, new DateTime(2020, 01, 05), 2515.00, StatusVendas.Pendente, v1);
            RegistroVendas r28 = new RegistroVendas(28, new DateTime(2020, 02, 05), 2515.00, StatusVendas.Pendente, v1);
            RegistroVendas r29 = new RegistroVendas(29, new DateTime(2020, 03, 05), 2515.00, StatusVendas.Pendente, v1);
            RegistroVendas r30 = new RegistroVendas(30, new DateTime(2020, 03, 05), 2515.00, StatusVendas.Pendente, v1);

            _context.Departamento.AddRange(d1, d2, d3, d4);
            _context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6);
            _context.RegistroVendas.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19, r20, r21, r22, r23, r24, r25, r26, r27, r28, r29, r30);
            _context.SaveChanges();


        }
    }
}