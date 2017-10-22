using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS_StackQueue
{
    class GenericStack<T>
    {
        private readonly int MaxSize ;
        private T[] items;
        private int currentIndex = -1;
        public GenericStack(): this(100) { }
        public GenericStack(int size) 
        {
            MaxSize = size;
            items = new T[MaxSize]; 
        }
        public void Push(T element)
        {
            if (IsFull())
                throw new InvalidOperationException("Stack is full");
            currentIndex++;
            items[currentIndex] = element;
        }
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("No elements in stack");
            T element = items[currentIndex];
            items[currentIndex] = default(T);
            currentIndex--;
            return element;
        }
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("No elements in stack");
            return items[currentIndex];
        }
        public bool IsEmpty()
        {
            if (currentIndex < 0)      
                return true;
            else
                return false;
        }
        public bool IsFull()
        {
            if (currentIndex >= MaxSize - 1)
                return true;
            else
                return false;
        }
    }
}
