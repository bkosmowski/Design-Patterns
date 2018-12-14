using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Iterator
{
    public class Creature : IEnumerable<int>
    {
        private readonly int[] _stats = new int[3];

        private const int strength = 0;
        private const int agility = 1;
        private const int intelligence = 2;

        public int Strength
        {
            get => _stats[strength];
            set => _stats[strength] = value;
        }

        public int Agility
        {
            get => _stats[agility];
            set => _stats[agility] = value;
        }

        public int Intelligence
        {
            get => _stats[intelligence];
            set => _stats[intelligence] = value;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return _stats.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
