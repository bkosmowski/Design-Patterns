using System;

namespace DesignPatterns.Observer
{
    public class PersonIllEventArgs
    {
        public PersonIllEventArgs(string address)
        {
            Address = address;
        }

        public string Address { get; }
    }

    public class Person
    {
        public void CatchCold(string address)
        {
            IllnessEventHandler?.Invoke(this, new PersonIllEventArgs(address));
        }

        public event EventHandler<PersonIllEventArgs> IllnessEventHandler;
    }

    public class EventObserver
    {
        public void Demo()
        {
            var person = new Person();

            person.IllnessEventHandler += CallDoctor;

            person.CatchCold("123 London Road");

            person.IllnessEventHandler -= CallDoctor;

            person.CatchCold("124 London Road");
        }

        private void CallDoctor(object sender, PersonIllEventArgs e)
        {
            Console.WriteLine($"Doctor is going on {e.Address}");
        }
    }
}
