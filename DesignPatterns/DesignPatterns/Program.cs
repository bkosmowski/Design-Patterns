using System;
using System.Linq;
using DesignPatterns.Iterator;
using DesignPatterns.Mediator;
using DesignPatterns.Memento;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankAccount = new BankAccount(100);

            var memento1 = bankAccount.Deposit(50);
            var memento2 = bankAccount.Deposit(25);

            Console.WriteLine(bankAccount);
            bankAccount.Restore(memento1);
            Console.WriteLine(bankAccount);
            bankAccount.Restore(memento2);
            Console.WriteLine(bankAccount);

            Console.ReadKey();
        }
    }
}