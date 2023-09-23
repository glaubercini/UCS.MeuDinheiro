using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCS.MeuDinheiro.EF.Context;
using UCS.MeuDinheiro.EF.Models;

namespace UCS.MeuDinheiro.Menu
{
    internal class ActionCustomerDelete : IAction
    {
        public void Run()
        {
            Console.WriteLine("# DELETAR CLIENTE #");
            Console.WriteLine("Digite o Código");
            string? id_string = Console.ReadLine();
            int id = int.Parse(id_string ?? "0");

            using var ctx = new MeuDinheiroContext();
            var c = ctx.Customer.Where(x => x.Id == id).FirstOrDefault();

            if (c != null)
            {
                ctx.Customer.Remove(c);
                ctx.SaveChanges();

                Console.WriteLine("Cliente Deletado");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado");
            }
        }
    }
}
