using System;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Command;
using DesignPatterns.Interpreter;
using DesignPatterns.Iterator;
using MoreLinq;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int>(new Node<int>(1, new Node<int>(2), new Node<int>(3)));

            Console.WriteLine(string.Join(',', binaryTree.InOrder.Select(x => x.Value)));

            Console.ReadKey();
        }
    }
}