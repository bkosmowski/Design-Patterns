using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters;

namespace DesignPatterns.Composite
{
    public static class NeuronExtensions
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
        {
            if(ReferenceEquals(self, other)) return;

            foreach (var from in self)
            {
                foreach (var to in other)
                {
                    from.Out.Add(to);
                    to.In.Add(from);
                }
            }
        }
    }

    public class Neuron : IEnumerable<Neuron>
    {
        public float Value { get; set; }
        public List<Neuron> In { get; } = new List<Neuron>();
        public List<Neuron> Out { get; } = new List<Neuron>();


        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class NeuronLayer : Collection<Neuron>
    {

    }
}
