using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS_StackQueue
{
    class ExpressionValidator
    {
        public bool Validate(string equation)
        {
            Stack stack = new Stack();

            for (int i = 0; i < equation.Length; i++)
            {
                char current = equation[i];
                switch (current)
                {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(current);
                        break;

                    case ')':
                    case ']':
                    case '}':
                        if (stack.IsEmpty())
                        {
                            return false;
                        }
                        char x = (char)stack.Pop();
                        if ((x == '(' && current != ')') ||(x == '[' && current != ']') ||(x == '{' && current != '}'))
                        {
                            return false;
                        }
                        break;
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
