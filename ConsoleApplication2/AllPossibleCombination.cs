using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    

public class Partition 
{

    private static void printPartition(int[] p, int n)
    {

        for (int i = 0; i < n; i++)
            Console.Write(p[i] + " ");
        Console.WriteLine();
    }

    private static void partition(int[] p, int n, int m, int i)
    {

        if (n == 0)
            printPartition(p, i);
        else
            for (int k = m; k > 0; k--)
            {
                p[i] = k;
                //partition(p, n - k, n - k, i + 1);
                partition(p, n - k, Math.Min(n - k, k), i + 1);
            }
    }

    public static void Main1(String[] args)
    {
        //partition(p, n-k, Math.min(n-k, k), i+1);
        partition(new int[6], 6, 6, 0);
        Console.ReadKey();
    }
}


}
