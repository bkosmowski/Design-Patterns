﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Iterator
{
    public class ExerciseNode
    {
        public class Node<T>
        {
            public T Value;
            public Node<T> Left, Right;
            public Node<T> Parent;

            public Node(T value)
            {
                Value = value;
            }

            public Node(T value, Node<T> left, Node<T> right)
            {
                Value = value;
                Left = left;
                Right = right;

                left.Parent = right.Parent = this;
            }

            public IEnumerable<T> PreOrder
            {
                get
                {
                    foreach (var root in TraversePreOrder(this))
                    {
                        yield return root.Value;
                    }
                }
            }

            private IEnumerable<Node<T>> TraversePreOrder(Node<T> current)
            {
                yield return current;
                if (current.Left != null)
                {
                    foreach (var left in TraversePreOrder(current.Left))
                    {
                        yield return left;
                    }
                }

                if (current.Right != null)
                {
                    foreach (var right in TraversePreOrder(current.Right))
                    {
                        yield return right;
                    }
                }
            }
        }
    }
}
