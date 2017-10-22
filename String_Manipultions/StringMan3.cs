using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STFromTheWordDocumentd
{
    class Program
    {
        static void Main1(string[] args)
        {
            //Console.WriteLine(removeString("she is themanmog hdks mmogog","mog"));
            Console.WriteLine("Reversed phrase: "+ReversePhrase("s am is the man"));
            //Console.WriteLine("Int convert"+IntConverter(34));
            //NumberOfOccurance(new int[]{1,2,3,2,4,3,5,6,2});
            //FindSubArray(new int[]{1,2,3,4,5,6},new int[]{5});
            //int[] a = removeDuplicate(new int[]{1,1,1,2,3,4,5});
            //Console.WriteLine("converter intvalue="+Converter("34"));
            //Console.WriteLine("converter floatvalue=" + FloatConverter("0.5687"));
            //Console.WriteLine("");
            Console.ReadKey();
        }
        public static string removeString(string source, string filter)
        {
            if (source == null || filter == null)
                throw new Exception("Empty source string");
            else if (filter == "")
                return source;
            int lens = source.Length;
            int lenf = filter.Length;
            if (lens < lenf)
                return source;
            else
                for (int i = 0; i <= lens - lenf; i++)
                {
                    if (source.Substring(i, lenf).Equals(filter))
                        //return source.Substring(0, i) + removeString(source.Substring(i + lenf), filter);
                        return removeString(source.Substring(0, i) + source.Substring(i + lenf), filter);
                }
            return source;
        }
        //4-this program accepts a line of word and reverses and displays
        public static string ReversePhrase(string str)
        {
            int strlen = str.Length;
            if (str == null)
                throw new Exception("invalid input");
            else
            {
                for (int i = strlen - 1; i > 0; i--)
                {
                    if (str[i].Equals(' '))
                    {
                        return str.Substring(i + 1) + " " + ReversePhrase(str.Substring(0, i));
                    }
                }
                
            }
            return str;
        }
        //another implementation of the above program
        public static string ReversePhrase2(string str)
        {
            int index = str.LastIndexOf(' ');
            if (index != -1)
                return str.Substring(index + 1) + " " + ReversePhrase2(str.Substring(0, index));
            return str;
        }
        //8-this program implements the split method with big 0(n).
        public static string[] split(string source, string delimiter)
        {
            if (source == null)
                throw new Exception("invalid input");
            else if (delimiter == null)
                throw new Exception("invalid delimiter");
            int sourcelen = source.Length;
            int count = 0;
            for (int i = 0; i < sourcelen; i++)
            {
                if (source[i].ToString() == delimiter)
                {
                    count++;//count the number of words
                }
            }
            string[] mystringarray = new string[count + 1];
            StringBuilder sb = new StringBuilder();
            int k = 0;
            for (int j = 0; j < sourcelen; j++)
            {
                if (source[j].ToString() != delimiter)
                    sb.Append(source[j]);
                else
                {
                    mystringarray[k] = sb.ToString();
                    sb = new StringBuilder();
                    k++;
                }
            }
            mystringarray[k] = sb.ToString();
            return mystringarray;
        }
        //10-this program removes duplicate items and displays non duplicates only
        public static void RemoveDupString(string[] str)
        {
            int len = str.Length;
            if (str == null)
                throw new Exception("invalid input");
            for (int i = 0; i < len - 1; i++)
            {
                //bool repeated = false;
                for (int j = i + 1; j < len; j++)
                {
                    if (str[i].Equals(str[j]))
                    {
                        //repeated = true;
                        str[j] = " ";
                    }
                }
                //if (repeated)
                //{
                // str[i] = " ";
                //}
                //else
                Console.Write(str[i].ToString() + " ");
            }
            Console.Write(str[len - 1]);
        }
        //11-this program displays the first repeated word from a given line of words
        public static string FirstRepeated(string str)
        {
            if (str == null)
                throw new Exception("invalid input");
            else if (str.IndexOf(" ") == -1)
                return str;
            else
            {
                int strlen = str.Length;
                int firstwordindex = str.IndexOf(" ");
                string firstword = str.Substring(0, firstwordindex);
                int firstwordlen = firstword.Length;
                for (int i = firstwordindex + 1; i < strlen - firstwordindex; i++)
                {
                    if (str.Substring(i, firstwordlen) == firstword)
                        return firstword;
                }
                return FirstRepeated(str.Substring(firstwordindex + 1));
            }
        }
        //15-a program which finds the palendrem in a word with a given phrase
        public static string FindPalendrem(string str)
        {
            if (str == null)
                throw new Exception("invalid input");
            int strlen = str.Length;
            int count;
            for (int i = 1; i < strlen - 1; i++)
            {
                count = 0;
                if (!str[i].Equals(' '))
                {
                    for (int j = 1; j <= i && j <= strlen - i; j++)
                    {
                        if (!(str[i - j].Equals(str[i + j])))
                        {
                            break;
                        }
                        else
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                        return (str.Substring(i - count, 2 * count + 1));
                }
            }
            return " ";
        }
        //16-this program finds the sum of two largest numbers in a given array

        //24.REVERSE STRING
        public static void reverseString(String text)
        {
            String rev = "";
            int l = text.Length - 1;
            for (int i = l; i >= 0; i--)
            {
                rev = rev + text[i];
            }
            Console.WriteLine(rev);
        }
        //25. Reverse phrase
        public static void reversePhrase(String s)
        {
            String[] str = s.Split(' ');
            for (int i = str.Length - 1; i >= 0; i--)
            {
                Console.Write(str[i] + " ");
            }
        }
        //26.IS PALINDROM
        public static bool isPalindrome2(String strParam)
        {
            int iLength, iHalfLen;
            iLength = strParam.Length - 1;
            iHalfLen = iLength / 2;
            for (int iIndex = 0; iIndex <= iHalfLen; iIndex++)
            {
                if (strParam.Substring(iIndex, 1) != strParam.Substring(iLength - iIndex, 1))
                {
                    return false;
                }
            }
            return true;
        }
        //27. Count Chars
        public static void countChars(String text)
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < text.Length; i++)
            {
                if (ht.ContainsKey(text[i]))
                    ht[text[i]] = (int)ht[text[i]] + 1;
                else
                    ht.Add(text[i], 1);
            }
            foreach (DictionaryEntry x in ht)
                Console.WriteLine("{0},{1}", x.Key, x.Value);
        }
        //28. Remove Duplicate Words
        public static void removeDuplicatedWords(String text)
        {
            String[] arrStrings = text.Split(' ');
            Hashtable h = new Hashtable();
            for (int i = 0; i < arrStrings.Length; i++)
            {
                if (h.ContainsKey(arrStrings[i]))
                    h[arrStrings[i]] = (int)h[arrStrings[i]] + 1;
                else
                    h.Add(arrStrings[i], 1);
            }
            foreach (DictionaryEntry word in h)
            {
                if (word.Value.Equals(1))
                    Console.WriteLine("{0}", word.Key);
            }
        }
        //29. Return max repeated word
        public static void getMaxChar(String text)
        {
            if (text == null)
                throw new Exception("Null input!");
            else if (text.Length == 0)
            {
                Console.WriteLine("zero size input!");
                return;
            }
            Hashtable ht = new Hashtable();
            for (int i = 0; i < text.Length; i++)
            {
                if (ht.ContainsKey(text[i]))
                    ht[text[i]] = (int)ht[text[i]] + 1;
                else
                    ht.Add(text[i], 1);
            }
            int max = 0;
            foreach (DictionaryEntry x in ht)
            {
                if ((int)x.Value > max)
                    max = (int)x.Value;
            }
            foreach (DictionaryEntry y in ht)
            {
                if (y.Value.Equals(max))
                    Console.WriteLine("{0},{1}", y.Key, y.Value);
            }
        }
    }
}
