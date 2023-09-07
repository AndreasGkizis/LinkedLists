﻿using System.Collections;
using System.Text;

namespace DataStructures.SinglyLinkedLists
{
    /// <summary>
    /// A singly linked list with only the bare essentials
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PureSinglyLinkedList<T> : IEnumerable
    {
        public PureSinglyLinkedList()
        {
            _head = null;
            _tail = null;
        }
        public T Head { get { return _head.Value; } }
        public T Tail { get { return _tail.Value; } }
        private SinglyLinkedListNode<T> _head { get; set; }
        private SinglyLinkedListNode<T> _tail { get; set; }
       
        public void AddHead(T value)
        {
            AddHead(new SinglyLinkedListNode<T>(value));
        }
        public void AddHead(SinglyLinkedListNode<T> node)
        {
            node.Next = _head;
            _head = node;
            if (_tail == null)
            {
                _tail = node;
            }
        }
        public void AddTail(T value)
        {
            AddTail(new SinglyLinkedListNode<T>(value));
        }
        public void AddTail(SinglyLinkedListNode<T> node)
        {
            _tail.Next = node;
            _tail = node;

        }
        public SinglyLinkedListNode<T>? Find(T value)
        {
            SinglyLinkedListNode<T> current = _head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }
                else
                {
                    current = current.Next;
                }
            }
            return null;
        }
        public bool Contains(T value)
        {
            return Find(value) != null;
        }
        public bool RemoveHead()
        {
            if (_head != null)
            {
                _head = _head.Next;
                return true;
            }
            return false;
        }
        public bool RemoveTail()
        {
            if (_tail != null)
            {
                var current = _head;
                while (current.Next != _tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                _tail = current;
                return true;
            }
            return false;
        }
        public bool Remove(T value)
        {
            if (_head.Value.Equals(value))
            {
                return RemoveHead();
            }

            if (_tail.Value.Equals(value))
            {
                return RemoveTail();
            }
            SinglyLinkedListNode<T> previous = null;
            SinglyLinkedListNode<T> current = _head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else
                    {
                        RemoveHead();
                    }
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        public override string? ToString()
        {
            var sb = new StringBuilder();
            var currentNode = _head;

            while (currentNode != null)
            {
                sb.Append(currentNode.Value);
                if (currentNode.Next != null)
                {
                    sb.Append(" -> ");
                }
                currentNode = currentNode.Next;
            }
            return sb.ToString();
        }
        public IEnumerator GetEnumerator()
        {
            SinglyLinkedListNode<T> current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }
}
