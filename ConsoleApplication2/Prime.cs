using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maths
{
    class Prime
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("prime=" + CountPrimes(4));
           // int[] x = MergeSortedArray(new int[]{1,3,5},new int[]{2,4,8,10});
            //for (int i = 0; i <x.Length; i++)
             //   Console.WriteLine(x[i]);
            //Console.WriteLine("Nth fibo is = " + NthFibonacci(8));
            Console.WriteLine("Fibonacci no. = {0}", Fibonacci1(10));
            Console.WriteLine("nth value=" + NthFibonacci(4));
            //Console.WriteLine("GreatestConsecutiveSum= "+GreatestConsecutiveSum2014(new int[]{-2,1,-3,4,-1,2,1,-5,4}));
            //Console.WriteLine("Float value=  "+floatConverter("316.134"));
            //Console.WriteLine(CheckMachingBracket("[()]"));
            //PossibleSumsSorted(new int[] { 1, 2, 3, 4, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 16);
            //PossibleSumsNonSorted(new int[] { 6, 12, 11, 14, 5, 1, 7, 10, 9, 8, 3, 2 }, 16);
            //Console.WriteLine("mintime=" + minWaitingTime(new int[] { 2,4,6,3,5}, 3, 10));
            //Console.WriteLine("set bit numbers= "+CountSetBit(7));
            //int[] rgNum = new int[100];
            //for (int i = 1; i <= 5; i++)
            //{
            //    rgNum[i] = i;
            //}
            //permut(1, 5, rgNum);
            //Console.WriteLine("Count= " + NumberOfCombination(new int[] { 5,5,5,5,5 }));
            //NumberOfCombinationDisplay(new int[]{7,8,9,3,4,2,14,7,11,6,5},16);
            //Console.WriteLine("H M Angle = " + HourMinuteAngle(5, 24));
            //Console.WriteLine("NumberOfCombination = "+Choose(5,2));
            //int i = 1;
            //Console.WriteLine( 10 << 2);
            //MyCutiePie(new char[] {'a','b','c','d','e','f','g'},3);
            //Console.WriteLine("GCD = " + GCDRecursive(1440, 408));
            //IntegerToBinaryRecirssive(5);
            Console.ReadKey();
        }
        //count the total primes below a given number
        public static int CountPrimes(int N)
        {
            if (N <= 1) return 0;
            //if (N == 2) return 1;
            int count = 0;
            for (int i = 2; i <= N; i++)
            {
                if (IsPrime(i))
                    count++;
            }
            return count;
            
                
        }
        public static bool IsPrime(int number)
        {
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        public static int Fibonacci1(int n)
        {
            if (n <= 1)
                return n;
            int current = 1, prev = 0, next = 1, count= 0;
            while (count < n)
            {
                Console.WriteLine(current);
                next = current + prev;
                prev = current;
                current = next;
                count++;
            }
            return count;
        }
        public static int NthFibonacci(int n)
        {
            // Console.WriteLine("x = {0}", n);
            if (n < 0) { throw new ArgumentException(); }
            if (n == 0 || n == 1)
                return n;
            //Console.WriteLine(NthFibonacci(n - 1) + NthFibonacci(n - 2));
            return NthFibonacci(n - 1) + NthFibonacci(n - 2);
        }
        public static long FactorialWithLowerBound(long x, long lowerBound)
        {
            long fact = 1;
            while (x >= 1 && x > lowerBound)
            {
                fact *= x;
                x--;
            }
            return fact;
        }
        public static int GreatestConsecutiveSum(int[] numbers)
        {
            int sum = numbers[0];
            int temp = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                temp += numbers[i];
                if (temp <= 0)
                {
                    temp = 0;
                    if (sum < 0 && numbers[i] > sum)
                        sum = numbers[i];
                }
                if (temp > sum && temp != 0)
                    sum = temp;
            }
            return sum;
        }
        public static int GreatestConsecutiveSum2014(int[] numbers)
        {
            int max_so_far = numbers[0], max_ending_here = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (max_ending_here < 0)
                {
                    max_ending_here = numbers[i];

                    // begin_temp = i;
                }
                else
                {
                    max_ending_here += numbers[i];
                }

                if (max_ending_here >= max_so_far)
                {
                    max_so_far = max_ending_here;

                    // begin = begin_temp;
                    // end = i;
                }
            }
            return max_so_far;
        }
        public static float floatConverter(string str)
        {
            const int zero = 48;
            int len = str.Length, i = 0;
            float sum = 0, k = 1; bool beforedot = true;
            for (i = 0; i < len; i++)
            {
                if (str[i] == '.')
                {
                    beforedot = false;
                    continue;
                }

                if (beforedot)
                {
                    int val = (int)str[i];
                    val = val - zero;  
                    Console.WriteLine(val);
                    sum = sum * 10 + val;
                }
                else
                {
                    float val = (int)str[i];
                    val = val - zero;
                    val = k / 10 * val;
                    Console.WriteLine(val);
                    sum += val;
                    k /= 10;
                }
            }
            return sum;
        }
        public static void PossibleSumsNonSorted(int[] a,int x)
        {
            int[] mark = new int[x];
            for (int i = 0 ; i < x ; i++) 
                mark[i] = 0; 

            for (int i = 0 ; i < a.Length ;i++) 
            {
                if (a[i] < x)
                {
                    if (mark[x - a[i]] == 0 && mark[a[i]] == 0)
                        mark[a[i]] = 1;
                    else if (mark[x - a[i]] != 0)
                    {
                        Console.WriteLine(a[i] + " and " + (x - a[i]));
                    }
                }
            } 
        }
        public static void PossibleSumsSorted(int[] a, int x)
        {
            int first = 0;
            int last = a.Length - 1;
            int sum;
            for (int i = 0; i < a.Length; i++)
            {
               // Console.WriteLine(a[first] +" and " + a[last]);
                if (first == last)
                    return;
                sum=a[first] + a[last];
                if (sum > x)
                    last--; 
                else
                {
                    if (sum == x)
                    {
                        Console.WriteLine(a[first] + " , " + a[last]);
                        //Console.WriteLine(a[last] + " , " + a[first]);
                    }
                    first++;
                }
            }
        }
        public static int minWaitingTime(int[] clientArrivals, int tellerCount, int serviceTime)
        {
            int len = clientArrivals.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                    if (clientArrivals[i] < clientArrivals[j])
                    {
                        int temp = clientArrivals[i];
                        clientArrivals[i] = clientArrivals[j];
                        clientArrivals[j] = temp;
                    }
            }
            for (int i = 0; i < len; i++)
                Console.WriteLine(clientArrivals[i]);
            int result = 0;
            int current = 0;
            for (int i = 0; i < len; i++)
            {
                int st = serviceTime * (1 + i / tellerCount);
                current = clientArrivals[len- i - 1]+ st;
                if (current > result)
                    result = current; 
                Console.WriteLine(clientArrivals[i]+"="+result);
            }
            return result;
        }
        public static void permut(int k, int n, int[] nums)
        {
            int i, j, tmp;
            /* when k > n we are done and should print */
            if (k <= n)
            {
                for (i = k; i <= n; i++)
                {
                    tmp = nums[i];
                    for (j = i; j > k; j--)
                    {
                        nums[j] = nums[j - 1];

                    }

                    nums[k] = tmp;

                    /* recurse on k+1 to n */
                    permut(k + 1, n, nums);
                    for (j = k; j < i; j++)
                    {
                        nums[j] = nums[j + 1];
                    }
                    nums[i] = tmp;
                }
            }
            else
            {
                for (i = 1; i <= n; i++)
                {
                    Console.Write("{0} ", nums[i]);
                }
                Console.WriteLine();

            }
        }
        public static int Sum15(int[] arr)
        {
            int count = 0;
            int target=0,temp=0;
            List<int> values = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                target = arr[i];
                temp = target;
                values.Clear();
                values.Add(temp);
                for (int j = 0; j < arr.Length; j++)
                {
                    //Console.WriteLine("target = " + target + "     a[" + j + "]=" + arr[j] + "    temp= " + temp);
                    //Console.WriteLine("temp b4: " +temp+"    j="+j);
                    if (i == j) continue;
                    if (temp < 6)
                    {
                        temp += arr[j];
                        values.Add(arr[j]);
                        Console.WriteLine("added" + arr[j]);
                    }
                    else
                    {
                        //Console.WriteLine("exeeded" + temp);
                        temp = target;
                        values.Clear();
                        values.Add(target);
                    }
                    //Console.WriteLine("temp after: " + temp + "    j=" + j);
                    if (temp == 6)
                    {
                        Console.Write("values:");
                        for (int k = 0; k < values.Count; k++)
                            Console.Write(values[k] + " ");
                        Console.WriteLine();
                        values.Clear();
                        values.Add(target);
                        temp = target;
                        count++;
                        //Console.WriteLine("temp =6");
                        //Console.WriteLine(" = " + target);
                    }
                }
            }
            return count;
        }
        public static int NumberOfCombination(int[] numbers)
        {
            int counter = 0,sum;
            //We only have a combination of 31 for input of 5 elements
            for (int i = 1; i < 32; i++)
            {
                sum = 0;
                //string s="";
                for (int j = 0; j < 5; j++)
                {
                    //only the Jth element that has ((i >> j) & 1) == 1 will add up to sum
                    //Console.WriteLine(i +">>"+ j+" : " + (i >> j) + "        ((i >> j) & 1) : " + ((i >> j) & 1));
                    //s =  ((i >> j) & 1)+s;
                    sum += ((i >> j) & 1) * numbers[j];
                }
                //Console.WriteLine(s);
                
                if (sum == 15)
                    counter++;
            }
            return counter;
        }
        public static void NumberOfCombinationDisplay(int[] numbers,int value)
        {
            int sum; long total=0;
            List<int> temp = new List<int>();
            for (int x = 1; x <= numbers.Length; x++)
            {
                total += Combo((long)numbers.Length, (long)x);
            }
            for (int i = 1; i < total+1; i++)
            {
                sum = 0; temp.Clear();
                for (int j = 0; j < numbers.Length; j++)
                {
                    sum += ((i >> j) & 1) * numbers[j];
                    if (((i >> j) & 1) !=0)
                        temp.Add(((i >> j) & 1) * numbers[j]);
                }
                if (sum == value)
                {
                    foreach(int elem in temp)
                        Console.Write(elem+ " ");
                    Console.WriteLine();
                }
            }
        }
        public static long Combo(long n, long r)
        {
            return (facto(n) / facto(n - r) / facto(r));
        }

        public static List<T[]> CreateSubsets<T>(T[] originalArray)
        {
            List<T[]> subsets = new List<T[]>();
            for (int i = 0; i < originalArray.Length; i++)
            {
                int subsetCount = subsets.Count;
                subsets.Add(new T[] { originalArray[i] });
                for (int j = 0; j < subsetCount; j++)
                {
                    T[] newSubset = new T[subsets[j].Length + 1];
                    subsets[j].CopyTo(newSubset, 0);
                    newSubset[newSubset.Length - 1] = originalArray[i];
                    subsets.Add(newSubset);
                }
            }
            return subsets;
        }
        public static void MyCutiePie(char[] inp, int level)
        {
            if (level == inp.Length)
            {
                Console.WriteLine(inp);
                return;
            }
            for (int j = 0; j < 3; j++)
            {
                char temp = inp[level];
                inp[level] = (char)((temp + j)%inp.Length);//getNextLetter(temp, j);
                MyCutiePie(inp, level + 1);
                inp[level] = temp;
            }
        }
        //14-this program converts from int to string
        public static string IntConverter(int myint)
        {
            StringBuilder sb = new StringBuilder();
            Console.Write(myint.ToString().Length);
            for (int i = myint.ToString().Length - 1; i >= 0; i--)
                sb.Append(i.ToString());

            if (myint.ToString().Length == 1)
                return myint.ToString();
            else if (myint.ToString().Length == 2)
            {
                int num1 = myint / 10;
                int num2 = myint % 10;
                return num2.ToString() + num1.ToString();
            }
            else
            {
                int Quetiont = myint / 10;
                int remainder = myint % 10;
                while (Quetiont >= 10)
                {
                    sb.Append(remainder);
                    remainder = Quetiont % 10;
                    Quetiont = Quetiont / 10;
                    sb.Append(remainder);
                    if (Quetiont < 10)
                    {
                        sb.Append(Quetiont);
                        break;
                    }
                    else
                    {
                    }
                }
                return sb.ToString();
            }
        }
        //13-this program converts from string into int
        public static int Converter(string str)
        {
            const int zero = 48;
            int len = str.Length;
            int sum = 0;
            for (int i = 0; i < len; i++)
            {
                int val = (int)str[i];
                Console.WriteLine(val);
                val = val - zero;
                sum = sum * 10 + val;
            }
            return sum;
        }
        //for floot numbers
        public static float FloatConverter(string str)
        {
            const int zero = 48;
            int len = str.Length;
            int sum1 = 0;
            float sum2 = 0;
            int i = 0;
            for (; i < len; i++)
            {
                if (str[i] == '.')
                {
                    i++;
                    break;
                }
                if (str[i] != '.')
                {
                    int val = (int)str[i];
                    //Console.WriteLine(val);
                    val = val - zero;
                    sum1 = sum1 * 10 + val;
                }

            }
            Console.WriteLine("sum1=" + sum1);
            for (int k = len - 1; k >= i; k--)
            {
                int val = (int)str[k];
                //Console.WriteLine(val);
                val = val - zero;
                sum2 = sum2 / 10 + val;
            }
            sum2 /= 10;
            Console.WriteLine("sum2=" + sum2);
            return sum1 + sum2;
        }
        public static int SumTwoLargest(int[] arr)
        {
            int firstmax;
            int secondmax;
            if (arr == null)
                throw new Exception("invalid input");
            else if (arr.Length == 1)
            {
                Console.Write("the length of the array is one");
                return arr[0];
            }
            else
            {
                int arrlen = arr.Length;
                if (arr[0] > arr[1])
                {
                    firstmax = arr[0];
                    secondmax = arr[1];
                }
                else if (arr[0] < arr[1])
                {
                    firstmax = arr[1];
                    secondmax = arr[0];
                }
                else
                {
                    firstmax = secondmax = arr[0];
                }
                for (int i = 2; i < arr.Length; i++)
                {
                    if (arr[i] > firstmax)
                    {
                        secondmax = firstmax;
                        firstmax = arr[i];
                    }
                    else if (arr[i] > secondmax && arr[i] < firstmax)
                    {
                        secondmax = arr[i];
                    }
                }
            }
            return firstmax + secondmax;
        }
        //17- this program displays the largest consecutive sum in a given array of integers(not sure implimentation)
        public static int LargestConsecutiveSum(int[] arr)
        {
            int count = 0;
            int sum = arr[0];
            int oldsum = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] + sum > sum)
                {
                    sum += arr[i];
                }
                else
                {
                    if (sum > 0 && sum > oldsum)
                    {
                        oldsum = sum;
                    }
                    i++;
                }
            }
            return Math.Max(sum, oldsum);
        }
        //18.1 IS PRIME
        public static bool isPrime2(int n)
        {
            if (n == 2)
            {
                //Console.WriteLine("Not prime");
                return true;
            }
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    //Console.WriteLine("Not prime{0} ", n);
                    return false;
                }
            }
            //Console.WriteLine(" prime {0} ", n);
            return true;
        }
        //18.2 PRIME GENERATOR Generates n prime numbers.
        public static void countPrimes(int n)
        {
            int count = 0;
            int num = 2;
            while (count < n)
            {
                if (isPrime2(num))
                {
                    Console.Write(num + ",");
                    count++;
                }
                num++;
            }
        }
        // 19 Fibonacci 
        public static void fibon(int n)
        {
            int[] fibs = new int[n];
            fibs[0] = 0;
            fibs[1] = 1;
            for (int i = 2; i < n; i++)
            {
                fibs[i] = fibs[i - 1] + fibs[i - 2];
            }
            foreach (int c in fibs)
            {
                Console.Write(",{0}", c);
            }
        }
        //20. Factorial
        public static long facto(long n)
        {
            long f = 1;
            for (long i = n; i > 1; i--)
                f = f * i;
            //Console.WriteLine(f);
            //Console.ReadLine();
            return f;
        }
        //ANGLE = 30H - (11/2)M
        public static double HourMinuteAngle(int h, int m)
        {
            double hAngle = 0.5D * (h * 60 + m);
            double mAngle = 6 * m;
            double angle = Math.Abs(hAngle - mAngle);
            angle = Math.Min(angle, 360 - angle);
            return angle;
        }

        public static int Pow(int n, int i)
        {
            if (i == 0)
                return 1;
            else if (i == 1)
                return n;
            else
            {
                int partial = Pow(n, i / 2);

                if (i % 2 == 0)
                    return partial * partial;
                else
                    return partial * partial * n;
            }
        }

        public static int Pow2(int n, int i)
        {
            if (i == 0)
                return 1;
            if (i == 1)
                return n;
            int result = 1;
            for (int x = i; x > 0; x--)
                result *= n;

            return result;
        }

        public static int GCDRecursive(int p, int q)
        {
            if (p == 0)
                return q;
            if (q == 0)
                return p;
            if (p > q)
            {
                return GCDRecursive(q, p % q);
            }
            else
            {
                return GCDRecursive(p, q % p);
            }
        }

        public static void IntegerToBinaryRecirssive(int n)
        {
            if (n == 0) return;
            IntegerToBinaryRecirssive(n / 2);
            Console.Write(n % 2);
        }
    }

}
