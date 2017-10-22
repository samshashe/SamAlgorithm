using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class BitWiseOperators
    {
        static void Main1(string[] args)
        {

            //Console.WriteLine("DivideBy7= " + DivideBy7(1000));
            ////int i = 1;
            Console.WriteLine("setbit = " + CountSetBit2(99));
            Console.WriteLine("to binary = " + ToBinary(99));
            //Console.WriteLine("Half= " + Half(33));
            //Console.WriteLine("Double= " + Double(33));
            Console.WriteLine("Divided by 7= " + DivideBy7(33));
            Console.WriteLine("multiply by shift = " + MultiplyByShift(33, 2));
            //Console.WriteLine("IsPowerOfTwo = " + IsPowerOfTwo2(8));
            //Console.WriteLine( 10 << 2);
            Console.ReadKey();
        }
        public static bool isEven(int Number)
        {
            return (Number & 1) == 0;
        }
        public static int CountSetBit1(int Number)
        {
            int count = 0;
            while (Number != 0)
            {
                count += (Number & 1);
                Number >>= 1;
            }
            return count;
        }
        public static int CountSetBit2(int num)
        {
            int count = 0;
            while (num > 0)
            {
                if (num % 2 == 1)
                {
                    count++;
                }
                num /= 2;
            }
            return count;
        }
        public static string ToBinary(int num)
        {
            StringBuilder sb = new StringBuilder();
            while (num > 0)
            {
                if (num % 2 == 1)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }
                num /= 2;
            }
            return sb.ToString();// Need to reverse this string
        }
        public static int Double(int Number)
        {
            return (Number << 1);
        }
        public static int Half(int Number)
        {
            return (Number >> 1);
        }
        public static int Zerros(int Number)
        {
            int count = 0;
            while (Number != 0)
            {
                if((Number & 1)==0)
                    count++;
                Number >>= 1;
            }
            return count;
        }
        public static int DivideBy7(int Number)
        {
            int value = 0;
            while (Number > 7)
            {
                int temp = (Number >> 3);
                value += temp;
                Number = (Number % 8) + temp;
            }
            if (Number == 7) value++;
            return value;
        }
        public static int MultiplyByShift(int number, int multiplier)
        {
            return (number << multiplier) - number;
        }
        public static bool IsPowerOfTwo(int number)
        {
            while(number > 1)
            {
                if (number % 2 == 1)
                    return false;
                number /= 2;
            }
            return true;
        }
        public static bool IsPowerOfTwo2(ulong x)
        {
            return (x & (x - 1)) == 0;
        }
    }
}
