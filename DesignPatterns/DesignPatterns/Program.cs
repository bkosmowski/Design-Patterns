using System;
using System.Collections.Generic;
using DesignPatterns.Command;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankAccount = new BankAccount();

            var bankAccountCommands = new List<BankAccountCommand>
            {
                new BankAccountCommand(Argument.Deposit, 100, bankAccount),
                new BankAccountCommand(Argument.Withdraw, 50, bankAccount)
            };

            Console.WriteLine(bankAccount);

            bankAccountCommands.ForEach(c => c.Call());

            Console.WriteLine(bankAccount);

            Console.ReadKey();
        }
    }
}