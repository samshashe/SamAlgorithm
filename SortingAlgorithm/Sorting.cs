using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingAlgorithm
{
    class Sorting
    {
        static void Main(string[] args)
        {
            
            Random rnd = new Random();
            int[] a=new int[10];
            for (int i = 0; i < 10; i++)
                a[i] = i+1;
            for (int i = 0; i < 10; i++)
                Console.Write(a[i] + " ");
            for (int i = 1; i <= 10; i++)
            {
                int k = rnd.Next(0,10);
                int l = rnd.Next(0, 10);
                int temp = a[k];
                a[k] = a[l];
                a[l] = temp;
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
                Console.Write(a[i] + " ");

            BubbleSort(a);
            //QSort(a);
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
                Console.Write(a[i] + " ");
            //QuickSort qs = new QuickSort(ref a);
            //qs.sortArray();
            //qs.Display();
            Console.ReadKey();
        }
        static void BubbleSort(int[] ar)
        {
            for (int i = ar.Length - 1; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (ar[j - 1] > ar[j])
                    {
                        int temp = ar[j - 1];
                        ar[j - 1] = ar[j];
                        ar[j] = temp;
                    }
                }
            }
        }
        static void SelectionSort(int[] ar)
        {
            for (int i = 0; i < ar.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < ar.Length; j++)
                    if (ar[j] < ar[min]) min = j;
                int temp = ar[i];
                ar[i] = ar[min];
                ar[min] = temp;
            }
        }
        static void InsertionSort(int[] ar)
        {
            for (int i = 1; i < ar.Length; i++)
            {
                int index = ar[i]; int j = i;
                while (j > 0 && ar[j - 1] > index)
                {
                    ar[j] = ar[j - 1];
                    j--;
                }
                ar[j] = index;
            }
        }
        public static void QSort(int[] input)
        {
            QuickSort(input,0, input.Length - 1);
        }
        public static int getPivotPoint(int[] input,int begPoint, int endPoint)
        {
            int pivot = begPoint;
            int m = begPoint + 1;
            int n = endPoint;
            while ((m < endPoint) && (input[pivot].CompareTo(input[m]) >= 0))
                m++;
            while ((n > begPoint) && (input[pivot].CompareTo(input[n]) <= 0))
                n--;
            while (m < n)
            {
                int temp = input[m];
                input[m] = input[n];
                input[n] = temp;

                while ((m < endPoint) &&(input[pivot].CompareTo(input[m]) >= 0))
                    m++;

                while ((n > begPoint) && (input[pivot].CompareTo(input[n]) <= 0))
                    n--;
            }
            if (pivot != n)
            {
                int temp2 = input[n];
                input[n] = input[pivot];
                input[pivot] = temp2;

            }
            return n;

        }
        public static void QuickSort(int[] input, int beg, int end)
        {
            if (end == beg)
            {
                return;
            }
            else
            {
                int pivot = getPivotPoint(input,beg, end);
                if (pivot > beg)
                    QuickSort(input, beg, pivot - 1);
                if (pivot < end)
                    QuickSort(input, pivot + 1, end);
            }
        }

    }
    public class QuickSort
    {
        // array of integers to hold values
        private int[] a = new int[10];
        // number of elements in array
        private int x;
        public QuickSort(ref int[] a) { this.a = a; }
        // Quick Sort Algorithm
        public void sortArray()
        {
            q_sort(0, x - 1);
        }
        public int[] A
        {
            get { return a; }
        }
        public void q_sort(int left, int right)
        {
            int pivot, l_hold, r_hold;

            l_hold = left;
            r_hold = right;
            pivot = a[left];

            while (left < right)
            {
                while ((a[right] >= pivot) && (left < right))
                {
                    right--;
                }
                if (left != right)
                {
                    a[left] = a[right];
                    left++;
                }
                while ((a[left] <= pivot) && (left < right))
                    left++;               
                if (left != right)
                {
                    a[right] = a[left];
                    right--;
                }
            }
            a[left] = pivot;
            pivot = left;
            left = l_hold;
            right = r_hold;
            if (left < pivot)
                q_sort(left, pivot - 1);
            if (right > pivot)
                q_sort(pivot + 1, right);
        }
        public void Display()
        {
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
                Console.Write(a[i] + " ");

        }
    }

}
