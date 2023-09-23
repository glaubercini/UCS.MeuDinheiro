using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCS.MeuDinheiro.EF.Context;
using UCS.MeuDinheiro.EF.Models;

namespace UCS.MeuDinheiro.Menu
{
    internal class ActionCustomerList : IAction
    {
        public void Run()
        {
            Console.WriteLine("# LISTA DE CLIENTES #");

            using var ctx = new MeuDinheiroContext();
            foreach (var item in ctx.Customer)
            {
                Console.WriteLine($"Código {item.Id} - Nome: {item.Name}");
            }
        }
    }
}
