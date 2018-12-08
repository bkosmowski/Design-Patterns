using System;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Command;
using MoreLinq;

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
                new BankAccountCommand(Argument.Withdraw, 1000, bankAccount)
            };

            Console.WriteLine(bankAccount);

            bankAccountCommands.ForEach(c => c.Call());

            Console.WriteLine(bankAccount);

            Enumerable.Reverse(bankAccountCommands).ForEach(c => c.Undo());

            Console.ReadKey();
        }
    }
}