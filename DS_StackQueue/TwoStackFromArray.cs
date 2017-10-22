using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS_StackQueue
{
    public class TwoStackFromArray
    {
        private const int MaxSize = 10;
        private int[] arr = new int[MaxSize];
        private int index1 = -1;
        private int index2 = MaxSize;

        public void Push(int element, string stackNumb) // stack1 or stack2
        {
            if (stackNumb == "stack1")
            {
                if (index1 == index2 - 1)
                    throw new InvalidOperationException("Stack is full");
                arr[++index1] = element;
            }
            else if (stackNumb == "stack2")
            {
                if (index2 == index1 + 1)
                    throw new InvalidOperationException("Stack is full");
                arr[--index2] = element;
            }
            
        }
        public int Pop(string stackNumb)
        {
            int element = -1;
            if (stackNumb == "stack1")
            {
                if (IsEmpty(stackNumb))
                    throw new InvalidOperationException("No elements in stack");
                element = arr[index1];
                arr[index1] = -1;
                index1--;
            }
            else if (stackNumb == "stack2")
            {
                if (IsEmpty(stackNumb))
                    throw new InvalidOperationException("No elements in stack");
                element = arr[index2];
                arr[index2] = -1;
                index2++;
            }         
            
            return element;
        }
        public int Peek(string stackNumb)
        {
            int element = -1;
            if (IsEmpty(stackNumb))
                throw new InvalidOperationException("No elements in stack");
            if (stackNumb == "stack1")
            {
                element = arr[index1];
            }
            else if (stackNumb == "stack2")
            {
                element = arr[index2];
            }
            return element;
        }
        public bool IsEmpty(string stackNumb)
        {
            bool empty = false;
            if (stackNumb == "stack1")
            {
                if (index1 < 0)
                    empty = true;
            }
            else if (stackNumb == "stack2")
            {
                if (index2 == MaxSize)
                    empty =true;
            }

            return empty;
        }
    }
}
