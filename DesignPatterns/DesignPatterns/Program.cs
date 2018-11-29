using System;
using DesignPatterns.Bridge;
using DesignPatterns.Composite;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();
            var layer1 = new NeuronLayer();
            var layer2 = new NeuronLayer();

            neuron1.ConnectTo(neuron2);
            neuron1.ConnectTo(layer1);
            layer1.ConnectTo(layer2);

            Console.ReadKey();
        }
    }
}