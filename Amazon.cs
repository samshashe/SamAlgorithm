using System;

public class Class1
{
        public static string findFirstDuplicate(string text)
        {
            int[] h = new int[256];
            for (int k = 0; k < text.Length; k++)
            {
                char ch = text[k];
                if (h[ch] > 0)
                {
                    return "" + ch;
                }
                h[ch]++;
            }
            return null;
        }
        public static void PossibleSums(int[] a, int x)
        {
            int first = 0;
            int last = a.Length - 1;
            int sum;
            for (int i = 0; i < a.Length; i++)
            {
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
                        Console.WriteLine(a[last] + " , " + a[first]);
                    }
                    first++;
                }
            }
        }
        public static string ReverseString(string input)
        {
            string temp = null;
            string[] output = new string[input.Length];
            int j = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                    temp += input[i];
                else
                {
                    output[j++] = temp;
                    temp = null;
                }
                if (i == input.Length - 1)
                    output[j++] = temp;
            }
            temp = null;
            while (j > 0)
                temp += output[--j] + " ";
            return temp;

        }
        
	}

