using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCS.MeuDinheiro.EF.Context;

namespace UCS.MeuDinheiro.Menu
{
    internal class ActionBankAccountClose : IAction
    {
        public void Run()
        {
            Console.WriteLine("# ENCERRAR UMA CONTA #");
            Console.WriteLine("Digite o Código da Conta");
            string? id_string = Console.ReadLine();
            int id = int.Parse(id_string ?? "0");

            var ctx = new MeuDinheiroContext();
            var c = ctx.BankAccount.Where(x => x.Id == id).FirstOrDefault();

            if (c != null)
            {
                ctx.BankAccount.Remove(c);
                ctx.SaveChanges();

                Console.WriteLine("Conta Deletada");
            }
            else
            {
                Console.WriteLine("Conta não encontrado");
            }
        }
    }
}
