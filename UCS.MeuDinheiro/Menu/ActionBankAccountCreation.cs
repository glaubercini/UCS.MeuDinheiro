using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCS.MeuDinheiro.EF.Context;
using UCS.MeuDinheiro.EF.Models;

namespace UCS.MeuDinheiro.Menu
{
    internal class ActionBankAccountCreation : IAction
    {
        public void Run()
        {
            Console.WriteLine("# CADASTRAR CONTA BANCÁRIA #");
            Console.WriteLine("Digite o Código da Conta");
            string? id_string = Console.ReadLine();
            int id = int.Parse(id_string ?? "0");

            Console.WriteLine("Digite o Código do Cliente");
            string? id_customer_string = Console.ReadLine();
            int id_customer = int.Parse(id_customer_string ?? "0");

            using var ctx = new MeuDinheiroContext();
            ctx.BankAccount.Add(new BankAccount
            {
                Id = id,
                CustomerId = id_customer,
                Balance = 0
            });

            ctx.SaveChanges();

            Console.WriteLine("Conta Cadastrada com Sucesso");
        }
    }
}
