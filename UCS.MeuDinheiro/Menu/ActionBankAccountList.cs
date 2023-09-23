using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCS.MeuDinheiro.EF.Context;
using UCS.MeuDinheiro.EF.Models;

namespace UCS.MeuDinheiro.Menu
{
    internal class ActionBankAccountList : IAction
    {
        public void Run()
        {
            Console.WriteLine("# LISTA DE CONTAS DE UM CLIENTE #");

            Console.WriteLine("Digite o Código do Cliente");
            string? id_string = Console.ReadLine();
            int id = int.Parse(id_string ?? "0");

            var ctx = new MeuDinheiroContext();

            var c = ctx.Customer.Where(x => x.Id == id).FirstOrDefault();
            if (c != null)
            {
                Console.WriteLine($"As contas do Cliente {c.Name} são:");

                foreach (var item in ctx.BankAccount.Where(x => x.CustomerId == id))
                {
                    Console.WriteLine($"Conta: {item.Id} - Saldo: {item.Balance}");
                }
            }
        }
    }
}