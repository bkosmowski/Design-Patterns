using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DesignPatterns.Decorator
{
    public class MyStringBuilder
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public static implicit operator MyStringBuilder(string s)
        {
            return new MyStringBuilder().Append(s);
        }

        public static MyStringBuilder operator +(MyStringBuilder myStringBuilder, string s)
        {
            return myStringBuilder.Append(s);
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ((ISerializable)_stringBuilder).GetObjectData(info, context);
        }

        public MyStringBuilder Append(bool value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(byte value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(char value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(char value, int repeatCount)
        {
            _stringBuilder.Append(value, repeatCount);
            return this;
        }

        public MyStringBuilder Append(char[] value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(char[] value, int startIndex, int charCount)
        {
            _stringBuilder.Append(value, startIndex, charCount);
            return this;
        }

        public MyStringBuilder Append(decimal value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(double value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(short value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(int value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(long value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(object value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(ReadOnlySpan<char> value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(sbyte value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(float value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(string value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(string value, int startIndex, int count)
        {
            _stringBuilder.Append(value, startIndex, count);
            return this;
        }

        public MyStringBuilder Append(MyStringBuilder value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(MyStringBuilder value, int startIndex, int count)
        {
            _stringBuilder.Append(value._stringBuilder, startIndex, count);
            return this;
        }

        public MyStringBuilder Append(ushort value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(uint value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder Append(ulong value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public MyStringBuilder AppendFormat(IFormatProvider provider, string format, object arg0)
        {
            _stringBuilder.AppendFormat(provider, format, arg0);
            return this;
        }

        public MyStringBuilder AppendFormat(IFormatProvider provider, string format, object arg0, object arg1)
        {
            _stringBuilder.AppendFormat(provider, format, arg0, arg1);
            return this;
        }

        public MyStringBuilder AppendFormat(IFormatProvider provider, string format, object arg0, object arg1, object arg2)
        {
            _stringBuilder.AppendFormat(provider, format, arg0, arg1, arg2);
            return this;
        }

        public MyStringBuilder AppendFormat(IFormatProvider provider, string format, params object[] args)
        {
            _stringBuilder.AppendFormat(provider, format, args);
            return this;
        }

        public MyStringBuilder AppendFormat(string format, object arg0)
        {
            _stringBuilder.AppendFormat(format, arg0);
            return this;
        }

        public MyStringBuilder AppendFormat(string format, object arg0, object arg1)
        {
            _stringBuilder.AppendFormat(format, arg0, arg1);
            return this;
        }

        public MyStringBuilder AppendFormat(string format, object arg0, object arg1, object arg2)
        {
            _stringBuilder.AppendFormat(format, arg0, arg1, arg2);
            return this;
        }

        public MyStringBuilder AppendFormat(string format, params object[] args)
        {
            _stringBuilder.AppendFormat(format, args);
            return this;
        }

        public MyStringBuilder AppendJoin(char separator, params object[] values)
        {
            _stringBuilder.AppendJoin(separator, values);
            return this;
        }

        public MyStringBuilder AppendJoin(char separator, params string[] values)
        {
            _stringBuilder.AppendJoin(separator, values);
            return this;
        }

        public MyStringBuilder AppendJoin(string separator, params object[] values)
        {
            _stringBuilder.AppendJoin(separator, values);
            return this;
        }

        public MyStringBuilder AppendJoin(string separator, params string[] values)
        {
            _stringBuilder.AppendJoin(separator, values);
            return this;
        }

        public MyStringBuilder AppendJoin<T>(char separator, IEnumerable<T> values)
        {
            _stringBuilder.AppendJoin(separator, values);
            return this;
        }

        public MyStringBuilder AppendJoin<T>(string separator, IEnumerable<T> values)
        {
            _stringBuilder.AppendJoin(separator, values);
            return this;
        }

        public MyStringBuilder AppendLine()
        {
            _stringBuilder.AppendLine();
            return this;
        }

        public MyStringBuilder AppendLine(string value)
        {
            _stringBuilder.AppendLine(value);
            return this;
        }

        public MyStringBuilder Clear()
        {
            _stringBuilder.Clear();
            return this;
        }

        public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
        {
            _stringBuilder.CopyTo(sourceIndex, destination, destinationIndex, count);
        }

        public void CopyTo(int sourceIndex, Span<char> destination, int count)
        {
            _stringBuilder.CopyTo(sourceIndex, destination, count);
        }

        public int EnsureCapacity(int capacity)
        {
            return _stringBuilder.EnsureCapacity(capacity);
        }

        public bool Equals(ReadOnlySpan<char> span)
        {
            return _stringBuilder.Equals(span);
        }

        public bool Equals(MyStringBuilder sb)
        {
            return _stringBuilder.Equals(sb._stringBuilder);
        }

        public MyStringBuilder Insert(int index, bool value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, byte value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, char value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, char[] value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, char[] value, int startIndex, int charCount)
        {
            _stringBuilder.Insert(index, value, startIndex, charCount);
            return this;
        }

        public MyStringBuilder Insert(int index, decimal value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, double value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, short value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, int value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, long value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, object value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, ReadOnlySpan<char> value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, sbyte value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, float value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, string value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, string value, int count)
        {
            _stringBuilder.Insert(index, value, count);
            return this;
        }

        public MyStringBuilder Insert(int index, ushort value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, uint value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, ulong value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public MyStringBuilder Remove(int startIndex, int length)
        {
            _stringBuilder.Remove(startIndex, length);
            return this;
        }

        public MyStringBuilder Replace(char oldChar, char newChar)
        {
            _stringBuilder.Replace(oldChar, newChar);
            return this;
        }

        public MyStringBuilder Replace(char oldChar, char newChar, int startIndex, int count)
        {
            _stringBuilder.Replace(oldChar, newChar, startIndex, count);
            return this;
        }

        public MyStringBuilder Replace(string oldValue, string newValue)
        {
            _stringBuilder.Replace(oldValue, newValue);
            return this;
        }

        public MyStringBuilder Replace(string oldValue, string newValue, int startIndex, int count)
        {
            _stringBuilder.Replace(oldValue, newValue, startIndex, count);
            return this;
        }

        public string ToString(int startIndex, int length)
        {
            return _stringBuilder.ToString(startIndex, length);
        }

        public int Capacity
        {
            get => _stringBuilder.Capacity;
            set => _stringBuilder.Capacity = value;
        }

        public char this[int index]
        {
            get => _stringBuilder[index];
            set => _stringBuilder[index] = value;
        }

        public int Length
        {
            get => _stringBuilder.Length;
            set => _stringBuilder.Length = value;
        }

        public int MaxCapacity => _stringBuilder.MaxCapacity;
    }
}