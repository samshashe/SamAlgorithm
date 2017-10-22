using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS_StackQueue
{
    class GenericQueue<T>
    {
        private int maxsize;
        private T[] items;

        private int front = -1;
        private int rear = 0;

        private int count = 0;

        public GenericQueue() 
            : this(100)
        {

        }
        public GenericQueue(int size)
        {
            maxsize = size;
            items = new T[size];
        }
        public void Enque(T element)
        {
            if (IsFull())
                throw new InvalidOperationException("Queue is full");
            count++;
            items[rear++ % maxsize] = element;
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");
            count--;
            T ret = items[++front % maxsize];
            items[front] = default(T);
            return ret;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");
            return items[(front + 1) % maxsize];
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public bool IsFull()
        {
            return count == maxsize;
        }

    }
}
