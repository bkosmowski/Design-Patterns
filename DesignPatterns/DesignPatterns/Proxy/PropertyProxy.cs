using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Proxy
{
    public class PropertyProxy
    {
        public void Demo()
        {
            var creature = new Creature();
            creature.Agility = 10;
            creature.Agility = 10;
        }
    }

    public class Property<T> : IEquatable<Property<T>> where T : new()
    {
        public Property() : this(Activator.CreateInstance<T>())
        {
            
        }
        private Property(T value)
        {
            Value = value;
        }

        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if (Equals(_value, value))
                {
                    return;
                }
                Console.WriteLine($"Assign new value {value}");
                _value = value;
            }
        }

        public bool Equals(Property<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || EqualityComparer<T>.Default.Equals(Value, other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Property<T>) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode(); //not readonly reference
        }

        public static bool operator ==(Property<T> left, Property<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Property<T> left, Property<T> right)
        {
            return !Equals(left, right);
        }

        public static implicit operator Property<T>(T value)
        {
            return new Property<T>(value);
        }

        public static implicit operator T(Property<T> property)
        {
            return property.Value;
        }
    }

    public class Creature
    {
        private Property<int> _agility = new Property<int>();

        public int Agility
        {
            get => _agility.Value;
            set => _agility.Value = value;
        }
    }
}
