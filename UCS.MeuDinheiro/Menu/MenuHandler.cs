﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCS.MeuDinheiro.Menu
{
    internal class MenuHandler
    {
        public List<MenuItem> MenuItems { get; set; } = new();

        public MenuHandler()
        {
            MenuItems.Add(new MenuItem
            {
                Option = 0,
                Description = "Sair do Sistema",
                Action = new ActionExit()
            });

            MenuItems.Add(new MenuItem
            {
                Option = 1,
                Description = "Cadastrar Cliente",
                Action = new ActionCustomerInsert()
            });

            MenuItems.Add(new MenuItem
            {
                Option = 2,
                Description = "Listar Clientes",
                Action = new ActionCustomerList()
            });

            MenuItems.Add(new MenuItem
            {
                Option = 3,
                Description = "Deletar Cliente",
                Action = new ActionCustomerDelete()
            });

            MenuItems.Add(new MenuItem
            {
                Option = 4,
                Description = "Atualizar Cliente",
                Action = new ActionCustomerUpdate()
            });

            MenuItems.Add(new MenuItem
            {
                Option = 5,
                Description = "Cadastrar Conta",
                Action = new ActionBankAccountCreation()
            });

            MenuItems.Add(new MenuItem
            {
                Option = 6,
                Description = "Listar Contas de um Cliente",
                Action = new ActionBankAccountList()
            });

            MenuItems.Add(new MenuItem
            {
                Option = 7,
                Description = "Encerrar a Conta de um Cliente",
                Action = new ActionBankAccountClose()
            });

            MenuItems.Add(new MenuItem
            {
                Option = 8,
                Description = "Movimentar uma conta Bancária",
                Action = new ActionBankAccountStatementMove()
            });
        }

        public void Interact()
        {
            while (true)
            {
                foreach (var item in MenuItems)
                {
                    Console.Write($"{item.Option}) ");
                    Console.WriteLine(item.Description);
                }

                try
                {
                    string? option_string = Console.ReadLine();
                    int option = Convert.ToInt32(option_string);

                    var menu = MenuItems.Where(x => x.Option == option).FirstOrDefault();
                    if (menu == null)
                    {
                        throw new Exception("Opção inválida");
                    }

                    menu.Action?.Run();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }
    }
}
