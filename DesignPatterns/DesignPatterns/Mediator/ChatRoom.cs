using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Mediator
{
    public class Person
    {
        private readonly IList<string> _chatLog = new List<string>();

        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public ChatRoom ChatRoom { get; set; }
        
        public void Receive(string sender, string message)
        {
            var info = $"{sender}: {message}";
            Console.WriteLine($"[{Name}'s chat session]: {info}");
            _chatLog.Add(info);
        }

        public void Say(string message)
        {
            ChatRoom.Broadcast(Name, message);
        }

        public void PrivateMessage(string who, string message)
        {
            ChatRoom.Message(Name, who, message);
        }
    }

    public class ChatRoom
    {
        private readonly IList<Person> _people = new List<Person>();

        public void Join(Person person)
        {
            string joinMsg = $"{person.Name} joins the chat";
            Broadcast("room", joinMsg);

            person.ChatRoom = this;
            _people.Add(person);
        }

        public void Broadcast(string source, string message)
        {
            foreach (var person in _people)
            {
                if (person.Name != source)
                {
                    person.Receive(source, message);
                }
            }
        }

        public void Message(string source, string destination, string message)
        {
            _people.FirstOrDefault(x=>x.Name == destination)?.Receive(source, message);
        }
    }
}
