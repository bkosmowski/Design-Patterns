using System;
using System.Collections.Generic;

namespace DesignPatterns.Iterator
{
    public class Node<T>
    {
        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
            left.Parent = right.Parent = this;
        }

        public T Value { get; }

        public Node<T> Parent { get; set; }

        public Node<T> Left { get; }

        public Node<T> Right { get; }

        public Node(T value)
        {
            Value = value;
        }
    }

    public class BinaryTree<T>
    {
        public BinaryTree(Node<T> root)
        {
            Root = root;
        }

        public Node<T> Root { get; }

        public IEnumerable<Node<T>> InOrder
        {
            get
            {
                foreach (var node in TraverseInOrder(Root))
                {
                    yield return node;
                }
            }
        }


        private IEnumerable<Node<T>> TraverseInOrder(Node<T> current)
        {
            if (current.Left != null)
            {
                foreach (var left in TraverseInOrder(current.Left))
                {
                    yield return left;
                }
            }

            yield return current;

            if (current.Right != null)
            {
                foreach (var right in TraverseInOrder(current.Right))
                {
                    yield return right;
                }
            }
        }
    }
}
