using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCS.MeuDinheiro.EF.Context;
using UCS.MeuDinheiro.EF.Models;

namespace UCS.MeuDinheiro.Menu
{
    internal class ActionBankAccountStatementMove : IAction
    {
        public void Run()
        {
            using var ctxAccount = new MeuDinheiroContext();
            using var ctxCustomer = new MeuDinheiroContext();
            using var ctxStatement = new MeuDinheiroContext();
            using var ctxBalance = new MeuDinheiroContext();

            Console.WriteLine($"ESCOLHA A CONTA QUE GOSTARIA DE MOVIMENTAR");

            foreach (var item in ctxAccount.BankAccount)
            {
                var customer = ctxCustomer.Customer.Where(x => x.Id == item.CustomerId).First();

                Console.WriteLine($"Conta: {item.Id}, Cliente: {customer.Name}, Saldo: {item.Balance}");
            }

            Console.WriteLine("Digite o número da conta desejada:");
            string? id_bankAccount_string = Console.ReadLine();

            int id_banckAccount = Convert.ToInt32(id_bankAccount_string);

            Console.WriteLine("Qual operação deseja fazer?");
            Console.WriteLine("[d] Depositar");
            Console.WriteLine("[r] Retirar");

            string? option = Console.ReadLine();

            Console.WriteLine("Qual é o valor a ser movimentado?");
            string? amount_string = Console.ReadLine();
            decimal amount = Convert.ToDecimal(amount_string);

            Console.WriteLine("Qual é o motivo da movimentação?");
            string? reason = Console.ReadLine();


            if (option == "r")
            {
                amount = amount * -1;
            }

            BankAccountStatement bas = new();
            bas.BankAccountId = id_banckAccount;
            bas.Amount = amount;
            bas.Description = reason;

            ctxStatement.BankAccountStatement.Add(bas);
            ctxStatement.SaveChanges();

            var account = ctxBalance.BankAccount.Where(x => x.Id == id_banckAccount).First();

            account.Balance += amount;

            ctxBalance.SaveChanges();

            Console.WriteLine("Conta movimentada com sucesso");
        }
    }
}
