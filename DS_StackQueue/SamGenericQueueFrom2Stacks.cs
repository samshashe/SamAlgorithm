using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS_StackQueue
{
    class SamGenericQueueFrom2Stacks<T>
    {
        GenericStack<T> s1 = new GenericStack<T>();
        GenericStack<T> s2 = new GenericStack<T>();
        public void Enqueue(T element)
        {
            s1.Push(element);
        }
        public T Dequeue()
        {
            if (s2.IsEmpty())
            {
                if (s1.IsEmpty()) { throw new InvalidOperationException("No elements in Queue"); }

                while (!s1.IsEmpty())
                    s2.Push(s1.Pop());
            }
            return s2.Pop();
        }
        public T Peek()
        {
            if (s2.IsEmpty())
            {
                if (s1.IsEmpty()) { throw new InvalidOperationException("No elements in Queue"); }

                while (!s1.IsEmpty())
                    s2.Push(s1.Pop());
            }
            return s2.Peek();
        }
    }
}
