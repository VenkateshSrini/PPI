using System;
using System.Collections.Generic;
using System.Text;

namespace PPILib
{
    class Node<T>
    {
        public T Value { get; private set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T TValue, Node<T> next, Node<T> previous)
        {
            Value = TValue;
            Next = next;
            Previous = previous;
        }
        public Node(T TValue)
        {
            Value = TValue;
            Next = null;
            Previous = null;
        }
    }
}
