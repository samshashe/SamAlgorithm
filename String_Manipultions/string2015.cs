using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace String_Manipultions
{
    class string2015
    {
        static void Main1(string[] args)
        {
            //Console.WriteLine("ReverseWordsInString = " + ReverseWordsInString("a cat goes to the market"));
            //Console.WriteLine("MinDistance = " + MinDistance("samsonjefnabce", 'n', 'a'));
            //Console.WriteLine("CheckAnagram = " + CheckAnagram("sam^", "^asm"));
            Console.WriteLine("LongestSubString = " + LongestSubString2("samosn", "samsonabcsamso"));
            Console.ReadKey();
        }
        // method to reverse a given string using StringBuilder
        public static string ReverseWordsInString(string str)
        {
            if (str == null || str == string.Empty)
                return str;
            string temp = string.Empty;
            string result = string.Empty;

            for (int i=0;i<str.Length;i++)
            {
                if(str[i] != ' ')
                {
                    temp = str[i] + temp;
                }
                else
                {
                    result = result + temp + " ";
                    temp = string.Empty;
                }
                
            }
            result += temp;
            return result;
        }

        public static int MinDistance(string str,char a,char b)
        {
            int aIndex = -1;
            int bIndex = -1;
            int minDistance = int.MaxValue;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == a)
                {
                    aIndex = i;
                }
                if (str[i] == b)
                {
                    bIndex = i;
                }
                if (aIndex != -1 && bIndex != -1)
                {
                    int distance = Math.Abs(bIndex - aIndex);
                    minDistance = minDistance > distance ? distance : minDistance;
                }
         
            }
            if (aIndex == -1 || bIndex == -1)
                return -1;

            return minDistance;
        }

        public static bool CheckAnagram(string str1, string str2)
        {
            
            int sum1 = 0, sum2 = 0;
            if (str1.Length != str2.Length) 
                return false;
            for (int i = 0; i < str1.Length; i++)
            {                
                sum1 += str1[i];
                sum2 += str2[i];
            }
            Console.WriteLine("sum1 = " + sum1 + "   sum2 = " + sum2);
            return sum1 == sum2 ? true : false;           
        }

        public static int LongestSubString(string str1, string str2)
        {
            int[,] LCSuff = new int[str1.Length + 1, str2.Length + 1];
            int result = 0;
            
            for (int i = 0; i <= str1.Length; i++)
            {
                for (int j = 0; j <= str2.Length; j++)
                {
                    if (i == 0 || j == 0)
                        LCSuff[i,j] = 0;

                    else if (str1[i - 1] == str2[j - 1])
                    {
                        LCSuff[i,j] = LCSuff[i - 1,j - 1] + 1;
                        result = Math.Max(result, LCSuff[i,j]);
                    }
                    else LCSuff[i,j] = 0;
                }
            }
           
            return result;

        }

        public static string LongestSubString2(string str1, string str2)
        {
            string longest = string.Empty;
            string templong = string.Empty;
            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] == str2[j])
                    {
                        templong +=  str1[i];
                        int k = i+1, m=j+1;
                        while (k < str1.Length && m < str2.Length && str1[k] == str2[m] ) 
                        {
                            templong += str1[k];
                            k++;
                            m++;
                        }
                        if (templong.Length > longest.Length)
                        {
                            longest = templong;
                        }
                        templong = string.Empty;
                    }
                    
                }
            }

            return longest;

        }

    }
}
