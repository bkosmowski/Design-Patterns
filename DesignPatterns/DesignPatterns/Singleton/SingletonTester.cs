using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Singleton
{
    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            var firstInstance = func.Invoke();
            var secondInstance = func.Invoke();

            return ReferenceEquals(firstInstance, secondInstance);
        }
    }
}
