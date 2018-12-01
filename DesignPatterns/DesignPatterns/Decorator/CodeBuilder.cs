using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DesignPatterns.Decorator
{
    public class CodeBuilder
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ((ISerializable) _stringBuilder).GetObjectData(info, context);
        }

        public CodeBuilder Append(bool value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(byte value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(char value)
        {
            _stringBuilder.Append(value);
            return this;
        }
        
        public CodeBuilder Append(char value, int repeatCount)
        {
            _stringBuilder.Append(value, repeatCount);
            return this;
        }

        public CodeBuilder Append(char[] value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(char[] value, int startIndex, int charCount)
        {
            _stringBuilder.Append(value, startIndex, charCount);
            return this;
        }

        public CodeBuilder Append(decimal value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(double value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(short value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(int value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(long value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(object value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(ReadOnlySpan<char> value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(sbyte value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(float value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(string value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(string value, int startIndex, int count)
        {
            _stringBuilder.Append(value, startIndex, count);
            return this;
        }

        public CodeBuilder Append(CodeBuilder value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(CodeBuilder value, int startIndex, int count)
        {
            _stringBuilder.Append(value._stringBuilder, startIndex, count);
            return this;
        }

        public CodeBuilder Append(ushort value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(uint value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder Append(ulong value)
        {
            _stringBuilder.Append(value);
            return this;
        }

        public CodeBuilder AppendFormat(IFormatProvider provider, string format, object arg0)
        {
            _stringBuilder.AppendFormat(provider, format, arg0);
            return this;
        }

        public CodeBuilder AppendFormat(IFormatProvider provider, string format, object arg0, object arg1)
        {
            _stringBuilder.AppendFormat(provider, format, arg0, arg1);
            return this;
        }

        public CodeBuilder AppendFormat(IFormatProvider provider, string format, object arg0, object arg1, object arg2)
        {
            _stringBuilder.AppendFormat(provider, format, arg0, arg1, arg2);
            return this;
        }

        public CodeBuilder AppendFormat(IFormatProvider provider, string format, params object[] args)
        {
            _stringBuilder.AppendFormat(provider, format, args);
            return this;
        }

        public CodeBuilder AppendFormat(string format, object arg0)
        {
            _stringBuilder.AppendFormat(format, arg0);
            return this;
        }

        public CodeBuilder AppendFormat(string format, object arg0, object arg1)
        {
            _stringBuilder.AppendFormat(format, arg0, arg1);
            return this;
        }

        public CodeBuilder AppendFormat(string format, object arg0, object arg1, object arg2)
        {
            _stringBuilder.AppendFormat(format, arg0, arg1, arg2);
            return this;
        }

        public CodeBuilder AppendFormat(string format, params object[] args)
        {
            _stringBuilder.AppendFormat(format, args);
            return this;
        }

        public CodeBuilder AppendJoin(char separator, params object[] values)
        {
            _stringBuilder.AppendJoin(separator, values);
            return this;
        }

        public CodeBuilder AppendJoin(char separator, params string[] values)
        {
            _stringBuilder.AppendJoin(separator, values);
            return this;
        }

        public CodeBuilder AppendJoin(string separator, params object[] values)
        {
            _stringBuilder.AppendJoin(separator, values);
            return this;
        }

        public CodeBuilder AppendJoin(string separator, params string[] values)
        {
            _stringBuilder.AppendJoin(separator, values);
            return this;
        }

        public CodeBuilder AppendJoin<T>(char separator, IEnumerable<T> values)
        {
            _stringBuilder.AppendJoin(separator, values);
            return this;
        }

        public CodeBuilder AppendJoin<T>(string separator, IEnumerable<T> values)
        {
            _stringBuilder.AppendJoin(separator, values);
            return this;
        }

        public CodeBuilder AppendLine()
        {
            _stringBuilder.AppendLine();
            return this;
        }

        public CodeBuilder AppendLine(string value)
        {
            _stringBuilder.AppendLine(value);
            return this;
        }

        public CodeBuilder Clear()
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

        public bool Equals(CodeBuilder sb)
        {
            return _stringBuilder.Equals(sb._stringBuilder);
        }

        public CodeBuilder Insert(int index, bool value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, byte value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, char value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, char[] value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, char[] value, int startIndex, int charCount)
        {
            _stringBuilder.Insert(index, value, startIndex, charCount);
            return this;
        }

        public CodeBuilder Insert(int index, decimal value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, double value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, short value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, int value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, long value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, object value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, ReadOnlySpan<char> value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, sbyte value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, float value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, string value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, string value, int count)
        {
            _stringBuilder.Insert(index, value, count);
            return this;
        }

        public CodeBuilder Insert(int index, ushort value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, uint value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, ulong value)
        {
            _stringBuilder.Insert(index, value);
            return this;
        }

        public CodeBuilder Remove(int startIndex, int length)
        {
            _stringBuilder.Remove(startIndex, length);
            return this;
        }

        public CodeBuilder Replace(char oldChar, char newChar)
        {
            _stringBuilder.Replace(oldChar, newChar);
            return this;
        }

        public CodeBuilder Replace(char oldChar, char newChar, int startIndex, int count)
        {
            _stringBuilder.Replace(oldChar, newChar, startIndex, count);
            return this;
        }

        public CodeBuilder Replace(string oldValue, string newValue)
        {
            _stringBuilder.Replace(oldValue, newValue);
            return this;
        }

        public CodeBuilder Replace(string oldValue, string newValue, int startIndex, int count)
        {
            _stringBuilder.Replace(oldValue, newValue, startIndex, count);
            return this;
        }

        public string ToString(int startIndex, int length)
        {
            return  _stringBuilder.ToString(startIndex, length);
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
