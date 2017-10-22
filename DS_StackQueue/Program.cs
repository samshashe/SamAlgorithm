using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS_StackQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericQueue<int> intQueue = new GenericQueue<int>(5);
            intQueue.Enque(5);
            intQueue.Enque(6);
            intQueue.Enque(7);
            intQueue.Enque(8);
            Console.WriteLine(intQueue.Dequeue());
            Console.WriteLine(intQueue.Dequeue());
            Console.WriteLine(intQueue.Dequeue());
            intQueue.Enque(44);
            intQueue.Enque(77);
            Console.WriteLine(intQueue.Dequeue());

            //SamGenericQueueFrom2Stacks<int> q = new SamGenericQueueFrom2Stacks<int>();
            //q.Enqueue(2);
            //q.Enqueue(3);
            //q.Enqueue(4);
            //Console.WriteLine(q.Peek());

            //Stack stack = new Stack();
            //int x = 9;
            //string y = "foo";
            //Console.WriteLine("Push 9");
            //stack.Push(x);
            //Console.WriteLine(stack.Peek().ToString());
            //Console.WriteLine("Push foo");
            //stack.Push(y);
            //Console.WriteLine(stack.Peek().ToString());
            //Console.WriteLine("Pop -> foo, 9 is at the top now.");
            //stack.Pop();
            //Console.WriteLine(stack.Peek().ToString());

            //Console.WriteLine("Maching bracket result = " + CheckMachingBracket("{}}{"));

            //TwoStackFromArray twoStack = new TwoStackFromArray();
            //twoStack.Push(1, "stack1");
            //twoStack.Push(2, "stack1");
            //twoStack.Push(3, "stack1");
            //twoStack.Push(4, "stack1");

            //twoStack.Push(11, "stack2");
            //twoStack.Push(21, "stack2");
            //twoStack.Push(31, "stack2");
            //twoStack.Push(41, "stack2");           

            //twoStack.Peek("stack1");
            /*
            //Expression validator
            ExpressionValidator eval = new ExpressionValidator();
            string input = "";
            do
            {
                //Console.Clear();
                Console.WriteLine("Write an equation.");
                bool result = eval.Validate(Console.ReadLine());
                if (result)
                    Console.WriteLine("Valid");
                else
                    Console.WriteLine("Invalid");
                Console.WriteLine("WANNA CONTINUE(Y?N)?: ");
                input=Console.ReadLine();

            } while (input.Equals("Y") || input.Equals("y"));

             */
            //GenericStack<int> intstack = new GenericStack<int>();
            //intstack.Push(4);
            //intstack.Push(8);
            Console.ReadKey();
        }
        public static bool CheckMachingBracket(string input)
        {
            GenericStack<char> stack = new GenericStack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                if (current == '[' || current == '{' || current == '(')
                {
                    stack.Push(current);
                }
                else if (current == ']' || current == '}' || current == ')')
                {
                    if (stack.IsEmpty())
                    {
                        return false;
                    }
                    char x = stack.Pop();
                    if ((x == '(' && current != ')') || (x == '[' && current != ']') || (x == '{' && current != '}'))
                    {
                        return false;
                    }
                }
            }
            if (stack.IsEmpty())
            {
                return true;
            }

            return false;
        }

    }
}
