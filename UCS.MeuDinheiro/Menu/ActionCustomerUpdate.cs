using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCS.MeuDinheiro.EF.Context;
using UCS.MeuDinheiro.EF.Models;

namespace UCS.MeuDinheiro.Menu
{
    internal class ActionCustomerUpdate : IAction
    {
        public void Run()
        {
            Console.WriteLine("# Atualizar CLIENTE #");
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
            var c = ctx.Customer.Where(x => x.Id == id).FirstOrDefault();

            if (c != null)
            {
                c.Name = name;
                ctx.SaveChanges();

                Console.WriteLine("Cliente Atualizado");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado");
            }
        }
    }
}
