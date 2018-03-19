using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using PPILib;

namespace PPILib
{
    public class PPIStack<T>
    {
        private Node<T> head;
        private int size = 0;
        private ILogger<PPIStack<T>> logger;
        public PPIStack (ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<PPIStack<T>>();
        }
        public bool Empty
        {
            private set { }
            get
            {
                return (head == null);
            }
        }
        public int SizeOf
        {
            get
            {
                return size;
            }
        }
        public bool Push(T Tvalue)
        {
            try
            {
                Node<T> node = new Node<T>(Tvalue);
                if (head == null)
                    head = node;
                else
                {
                    node.Next = head;
                    head = node;
                }
                size++;
                return true;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error during Push");
                throw ex;
            }
        }
        public T Pop()
        {
            try
            {
                if (Empty)
                    return default(T);
                else
                {
                    var returnVal = head.Value;
                    head = head.Next;
                    size--;
                    return returnVal;
                }
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error inpop");
                throw ex;
            }
        }
        public bool Contains(T tSearch)
        {
            try
            {
                var searchNode = head;
                while (searchNode != null)
                {
                    if (searchNode.Value.Equals(tSearch))
                        return true;
                    else
                        searchNode = head.Next;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error in contains");
                throw ex;

            }
        }
        public T Peek()
        {
            try
            {
                if (Empty)
                    return default(T);
                else
                    return head.Value;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in Peek");
                throw ex;
            }
        }
        public T PeekN( int depth)
        {
            try
            {
                T result = default(T);
                if (depth > size)
                    return result;
                else if (depth == size)
                    return head.Value;
                else
                {
                    Node<T> node = head;
                    for (int counter = 0; counter < depth; counter++)
                    {
                        node = head.Next;
                    }
                    result = node.Value;
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in PeekN");
                throw ex;
            }

        }
    }
}
