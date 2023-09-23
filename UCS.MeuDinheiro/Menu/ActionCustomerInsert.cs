using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCS.MeuDinheiro.EF.Context;
using UCS.MeuDinheiro.EF.Models;

namespace UCS.MeuDinheiro.Menu
{
    internal class ActionCustomerInsert : IAction
    {
        public void Run()
        {
            Console.WriteLine("# CADASTRAR CLIENTE #");
            Console.WriteLine("Digite o Código");
            string? id_string = Console.ReadLine();
            int id = int.Parse(id_string ?? "0");

            Console.WriteLine("Digite o Nome");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("O nome estava em branco");
            }

            using var ctx = new MeuDinheiroContext();
            ctx.Customer.Add(new Customer
            {
                Id = id,
                Name = name
            });

            ctx.SaveChanges();

            Console.WriteLine("Cliente Cadastrado com Sucesso");
        }
    }
}
