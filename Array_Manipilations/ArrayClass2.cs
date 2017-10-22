using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Array_Manipilations
{
    class ArrayClass2
    {
        static void Main1(string[] args)
        {
            //TriangleTriplet(new int[]{9,8,7,10});
            //TriangleTriplet2(new int[] { 9, 8, 7, 10 });
            //Console.WriteLine("Maximum consicutive sum = " + MaxConsicutiveSum(new int[] { -2, -3, 4, -1, -2, 1, 5, -3 }));
            //Console.WriteLine("missing number = " + MissingNumber(new int[] { 8,6,7,10  }));

            //Intersection(new int[] { 1,3,4,5,6 }, new int[] { 2,3,5,6 });
            //Union(new int[] { 1, 3, 4, 5, 6, 7}, new int[] { 2, 3, 5, 6 });
            //TwoPairSorted(new int[] { 1, 3, 4, 5, 6, 7}, 8);
            //TwoPairNotSortedHash(new int[] { 6, 3, 1, 5, 2, 7 }, 8);
            //ProductOfRest(new int[] { 1,2,3  });
            Display100();
            Console.ReadKey();
        }
        public static void TriangleTriplet(int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; j < n; j++)
                    {
                        if (i != j && j != k && i != k)
                            if (a[i] + a[j] > a[k] && a[j] + a[k] > a[i] && a[i] + a[k] > a[j])
                            {
                                Console.WriteLine(a[i] + " " + a[j] + " " + a[k]);
                            }
                    }
                }
            }
        }

        public static void TriangleTriplet2(int[] A) // no duplicates.....linked in
        {
            //sort(A.begin(), A.end());
            for (int c = A.Length - 1; c != -1; c--)
            {
                bool found_b = false;
                for (int b = c - 1; b != -1; b--)
                {
                    bool found_a = false;
                    for (int a = b - 1; a != -1; a--)
                    {
                        if (A[c] >= (A[a] + A[b])) break;
                        found_a = true;
                        Console.WriteLine(A[a] + " " + A[b] + " " + A[c]);
                    }
                    if (!found_a) break;
                    found_b = true;
                }
                if (!found_b) break;
            }
        }

        public static int MaxConsicutiveSum(int[] a)
        {
            int max = a[0], curr = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] + curr < a[i])
                    curr = a[i];
                else
                    curr = curr + a[i];

                if (curr > max)
                {
                    max = curr;
                }
            }
            return max;
        }

        public static int MissingNumber(int[] arr)
        {
            if (arr.Length < 3) { throw new Exception("invalid array"); }
            int sum = arr[0];
            int max = arr[0];
            int min = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                sum += arr[i];
                if (arr[i] > max)
                    max = arr[i];
                if (arr[i] < min)
                    min = arr[i];
            }

            // the total sum of numbers between min and max.
            int total = (min + max) * (arr.Length+1) / 2;

            return total - sum;
        }

        public static void Intersection(int[] arr1, int[] arr2)
        {
            int min = arr1.Length > arr2.Length ? arr2.Length : arr1.Length;
            int index1 = 0, index2 = 0;
            while(index1<arr1.Length && index2 < arr2.Length)
            {
                if(arr1[index1] < arr2[index2])
                    index1++;
                else if (arr1[index1] > arr2[index2])
                    index2++;
                else
                {
                    Console.WriteLine(arr1[index1++]);
                    index2++;
                }
            }           
        }

        public static void Union(int[] arr1, int[] arr2)
        {
            int min = arr1.Length > arr2.Length ? arr2.Length : arr1.Length;
            int index1 = 0, index2 = 0;
            while (index1 < arr1.Length && index2 < arr2.Length)
            {
                if (arr1[index1] < arr2[index2])
                    Console.WriteLine(arr1[index1++]);
                else if (arr1[index1] > arr2[index2])
                    Console.WriteLine(arr2[index2++]);
                else
                {
                    Console.WriteLine(arr1[index1++]);
                    index2++;
                }
            }
            while (index1 < arr1.Length)
                Console.WriteLine(arr1[index1++]);
            while (index2 < arr2.Length)
                Console.WriteLine(arr2[index2++]);
        }

        public static void TwoPairSorted(int[] a, int target)
        {
            int i = 0, j = a.Length - 1;
            while (i < j)
            {
                if (a[i] + a[j] == target)
                {
                    Console.WriteLine(a[i] + "   " + a[j]);
                    i++;
                }
                else if (a[i] + a[j] < target) i++;
                else if (a[i] + a[j] > target) j--;
            }
        }

        public static void TwoPairNotSorted(int[] a, int target) //  order of n^2
        {
            for (int i = 0; i < a.Length-1; i++)
            {
                for (int j = i  + 1; j < a.Length; j++)
                {
                    if((target - a[i]) == a[j])
                        Console.WriteLine(a[i] + "   " + a[j]);
                }
            }
        }

        public static void TwoPairNotSortedHash(int[] a, int target) //  order of n
        {
            Hashtable set = new Hashtable();
            for (int i = 0; i < a.Length; i++)
            {

                if (!set.Contains(target - a[i]))
                {
                    set.Add(a[i], 1);
                }
                else
                {
                    Console.WriteLine(a[i] + "   " + (target - a[i]));
                }
            }
        }

        public static void ProductOfRest(int[] arr)
        {
            int multiply = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                multiply *= arr[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(multiply / arr[i] + "  ");
            }
        }

        public static void Display100()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("foobar");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("foo");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("bar");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    
    }
}
