using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using ImpromptuInterface;

namespace DesignPatterns.Proxy
{
    public class DynamicProxy
    {
        public void Demo()
        {
            var ba = Log<BankAccount>.As<IBankAccount>();

            ba.Deposit(100);
            ba.Withdraw(50);

            Console.WriteLine(ba);
        }
    }

    public interface IBankAccount
    {
        void Deposit(int amount);
        bool Withdraw(int amount);
        string ToString();
    }

    public class BankAccount : IBankAccount
    {
        private int _balance;
        private readonly int _overdraftLimit = -500;

        public void Deposit(int amount)
        {
            _balance += amount;
            Console.WriteLine($"Deposited ${amount}, balance is now {_balance}");
        }

        public bool Withdraw(int amount)
        {
            if (_balance - amount >= _overdraftLimit)
            {
                _balance -= amount;
                Console.WriteLine($"Withdrew ${amount}, balance is now {_balance}");
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{nameof(_balance)}: {_balance}";
        }
    }

    public class Log<T> : DynamicObject where T : class, new()
    {
        private readonly T _subject;
        private readonly Dictionary<string, int> _methodCallCount = new Dictionary<string, int>();

        public Log(T subject)
        {
            _subject = subject ?? throw new ArgumentNullException(nameof(subject));
        }

        public static I As<I>(T subject) where I : class
        {
            if (typeof(I).IsInterface == false)
            {
                throw new ArgumentException("I must to be an interface type");
            }

            return new Log<T>(subject).ActLike<I>();
        }

        public static I As<I>() where I : class
        {
            if (typeof(I).IsInterface == false)
            {
                throw new ArgumentException("I must to be an interface type");
            }

            return new Log<T>(new T()).ActLike<I>();
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                Console.WriteLine($"Invoking {_subject.GetType().Name}.{binder.Name} with arguments [{string.Join(",", args)}]");
                if (_methodCallCount.ContainsKey(binder.Name))
                {
                    _methodCallCount[binder.Name]++;
                }
                else
                {
                    _methodCallCount.Add(binder.Name, 1);
                }

                result = _subject.GetType().GetMethod(binder.Name).Invoke(_subject, args);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                result = null;
                return false;
            }
        }
        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var keyValuePair in _methodCallCount)
                {
                    sb.AppendLine($"{keyValuePair.Key} called {keyValuePair.Value} time(s)");
                }
                return sb.ToString();
            }
        }

        // will not be proxied automatically
        public override string ToString()
        {
            return $"{Info}{_subject}";
        }
    }
}
