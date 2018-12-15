using System;
using System.Collections.Generic;

namespace DesignPatterns.Memento
{
    public class Memento
    {
        public Memento(int balance)
        {
            Balance = balance;
        }

        public int Balance { get; }
    }

    public class BankAccount
    {
        private int _balance;
        private int _current;

        private readonly List<Memento> _changes = new List<Memento>();

        public BankAccount(int balance)
        {
            _balance = balance;
        }

        public Memento Deposit(int amount)
        {
            _balance += amount;
            var memento = new Memento(_balance);
            _changes.Add(memento);
            ++_current;
            return memento;
        }

        public Memento Restore(Memento memento)
        {
            if (memento == null) return null;

            _balance = memento.Balance;
            _changes.Add(memento);
            ++_current;
            return memento;
        }

        public Memento Undo()
        {
            if (_current > 0)
            {
                var memento = _changes[--_current];
                _balance = memento.Balance;
                return memento;
            }

            return null;
        }

        public Memento Redo()
        {
            if (_current < _changes.Count)
            {
                var memento = _changes[++_current];
                _balance = memento.Balance;
                return memento;
            }

            return null;
        }

        public override string ToString()
        {
            return $"{nameof(_balance)}: {_balance}";
        }
    }
}
