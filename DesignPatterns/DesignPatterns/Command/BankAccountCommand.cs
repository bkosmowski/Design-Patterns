using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DesignPatterns.Command
{
    public class BankAccount
    {
        private int _balance;
        private const int WithdrawLimit = -500;

        internal void Deposit(int amount)
        {
            _balance += amount;
            Console.WriteLine($"Deposit {amount}. Current balance on account: {_balance}");
        }

        internal void Withdraw(int amount)
        {
            if (_balance - amount > WithdrawLimit)
            {
                _balance -= amount;
                Console.WriteLine($"Withdrew {amount}. Current balance on amount: {_balance}");
            }
            else
            {
                Console.WriteLine($"Can't withdrew {amount}. Current balance on account: {_balance}");
            }
        }

        public override string ToString()
        {
            return $"{nameof(_balance)}: {_balance}";
        }
    }

    public interface IBankAccountCommand
    {
        void Call();
    }

    public enum Argument
    {
        Deposit,
        Withdraw
    }

    public class BankAccountCommand : IBankAccountCommand
    {
        private readonly Argument _argument;
        private readonly int _amount;
        private readonly BankAccount _bankAccount;

        public BankAccountCommand(Argument argument, int amount, BankAccount bankAccount)
        {
            _argument = argument;
            _amount = amount;
            _bankAccount = bankAccount ?? throw new ArgumentNullException(nameof(bankAccount));
        }

        public void Call()
        {
            switch (_argument)
            {
                case Argument.Deposit:
                    _bankAccount.Deposit(_amount);
                    break;
                case Argument.Withdraw:
                    _bankAccount.Withdraw(_amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }


}
