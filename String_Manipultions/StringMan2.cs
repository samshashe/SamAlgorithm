using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace String_Manipultions
{
    class StringMan2
    {
        static void Main(string[] args) 
        {
            //Console.WriteLine(findFirstDuplicate2("ldhkashemene"));
            //permutation("abcde");
            //Console.WriteLine(IsPalindrome(""));
            //Console.WriteLine("Longest palindrome= " + LongestPalindrome("forgeeksskeegforabeeddddeabe"));
            //Console.WriteLine("Second most occured character= "+SecondMaxOccurence("abbcadcdbbbc"));
            //CharacterCount2("mississippi");
            //Console.WriteLine(FindPattern("samson", "rson"));
            //Console.WriteLine("cons sum="+GreatestConsecutiveSum(new int[]{1,-2,2,-1,4,-3,4}));
            //countCharsInterview(null);
            //HashtableMethod();
            //Console.WriteLine("filtered string= " + FilterString2014("pppphrhrhr","phr"));
            //Console.WriteLine("filtered string Recurssive= " + FilterStringRecurssive("pppphrhrhr", "phr"));
            //MaxWordCountWithOutHash("abe kebe kebe sam abe sam sam");
            Console.WriteLine("Unuique Char: " + UniqueCharacters2("This is a string."));
            //Permtuation("abc");
            //Combination("abc");

            //GetLongestString(4, new List<string>() { "dddd", "gg", "fff", "gggggggg", "cc"});
            //GetLongestString(10, new List<string>() { "dddd", "hhhh", "fff", "gggggg", "ccc", "kk", "ttt", "l", "rr" });
            Console.ReadKey();
        }
        #region Permituation
        private static void swap(ref char a, ref char b)
        {

            if (a == b) return;

            a ^= b;

            b ^= a;

            a ^= b;

        }
        public static void permutation(string str)
        {
            char[] list = str.ToCharArray();
            int x = list.Length - 1;

            go(list, 0, x);

        }
        private static void go(char[] list, int k, int m)
        {

            int i;

            if (k == m)
            {

                Console.Write(list);

                Console.WriteLine(" ");

            }

            else

                for (i = k; i <= m; i++)
                {

                    swap(ref list[k], ref list[i]);

                    go(list, k + 1, m);

                    swap(ref list[k], ref list[i]);

                }

        }
        #endregion
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
        public static string findFirstDuplicate2(string text)
        {
            Hashtable ht = new Hashtable();
            for (int k = 0; k < text.Length; k++)
            {
                if (ht.ContainsKey(text[k]))
                    return text[k].ToString();
                else
                    ht.Add(text[k], 1);
            }
            return null;
        }
        public static string LongestPalindrome(string str)
        {
            string result="";
            int combination = 0;
            for (int i = 1; i < str.Length; i++)
            {
                for (int j = 0; j <i;j++ )
                {
                    combination++;
                    if (str[i] == str[j])
                    {
                        string check=str.Substring(j,(i-j+1));
                        if(IsPalindrome(check) && check.Length>result.Length)
                        {
                            Console.WriteLine(check);
                            result = check;
                        }
                    }
                }
            }
            
            Console.WriteLine("Length = " + str.Length + " Total tried combination = " +  combination + "   result = " + result);
            return result;
        }
        public static int LongestPalindrome2(string seq)
        {
            int Longest = 0;
            List<int> l = new List<int>();
            int i = 0;
            int palLen = 0;
            int s = 0;
            int e = 0;
            while (i < seq.Length)
            {
                if (i > palLen && seq[i - palLen - 1] == seq[i])
                {
                    palLen += 2;
                    i += 1;
                    continue;
                }
                l.Add(palLen);
                Longest = Math.Max(Longest, palLen);
                s = l.Count - 2;
                e = s - palLen;
                bool found = false;
                for (int j = s; j > e; j--)
                {
                    int d = j - e - 1;
                    if (l[j] == d)
                    {
                        palLen = d;
                        found = true;
                        break;
                    }
                    l.Add(Math.Min(d, l[j]));
                }
                if (!found)
                {
                    palLen = 1;
                    i += 1;
                }
            }
            l.Add(palLen);
            Longest = Math.Max(Longest, palLen);
            return Longest;
        }
        public static bool IsPalindrome(string str)
        {
            int i=0;
            while(i<str.Length/2)
            {
                if (str[i] != str[str.Length - i - 1])
                    return false;
                i++;
            }
            return true;
        }
        public static char SecondMaxOccurence(string str)
        {
            char ch1=str[0],ch2=str[0];
            int[] arr=new int[256];
            for(int i = 0; i < str.Length; i++)
            {
                int index = (int)str[i];
                arr[index]++;
                if (arr[index] > arr[ch1])
                {
                    ch2 = ch1;
                    ch1 = str[i];

                }
                else if (arr[index] > arr[ch2] && arr[index] != arr[ch1])
                {
                    ch2 = str[i];
                }
            }        
            return ch2;
        }
        public static void CharacterCount(string str)
        {
            int[] h = new int[256];
            string unique="";
            for(int i=0;i<str.Length;i++)
                h[str[i]]++;
            for (int i = 0; i < str.Length; i++)
            {
                if(h[str[i]]!=-1)
                {
                    Console.WriteLine(str[i]+" = "+h[str[i]]);
                    h[str[i]]=-1;
                    unique += str[i];
                }
            }
            Console.WriteLine(unique);
        }
        public static void CharacterCount2(String text)
        {
            if (text == null || text == string.Empty)
                return;
            Hashtable ht = new Hashtable();
            for (int i = 0; i < text.Length; i++)
            {
                if (ht.ContainsKey(text[i]))
                    ht[text[i]] = (int)ht[text[i]] + 1;
                else
                    ht.Add(text[i], 1);
            }
            foreach (DictionaryEntry x in ht)
                Console.WriteLine("{0}={1}", x.Key, x.Value);

        }
        public static bool FindPattern(string str1,string str2)
        {
            if (str1 == null || str2 == null)
                throw new Exception("Invalid input----null value");
            if (str1.Length == 0 || str2.Length == 0)
            {
                Console.WriteLine("Empty String");
                return false;
            }
            //check length validity  str2 < str1
            bool found=false;
            for (int i = 0; i <= str1.Length-str2.Length; i++)
            {
                if (str1[i] == str2[0] )
                {
                    found = true;
                    for (int j = 1;j < str2.Length; j++)
                    {
                        if(str1[i+j]!=str2[j])
                            found=false;
                    }
                    if (found == true)
                        return found;
                }
            }
            return false;
        }        
        public static void HashtableMethod()
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < 5; i++)
                ht.Add(i, i*5);
            //for (int i = 0; i < 5; i++)
            //    Console.WriteLine(ht[i]);
            foreach(int a in ht.Values)
                Console.WriteLine(a);
        }
        public static string FilterString(string source,string filter) // doesn't handle recurssive filter
        {
            int len1 = source.Length;
            int len2 = filter.Length;
            string result = "";
            int k = 0;
            for (int i = 0; i <= len1 - len2; i++)
            {
                if (source[i] == filter[0])
                {
                    if (source.Substring(i, len2).Equals(filter))
                    {
                        result += source.Substring(k, i - k);
                        k = i+len2;
                    }
                }
            }
            result += source.Substring(k,len1-k);
            return result;
        }
        public static string FilterString2014(string source, string filter)
        {
            for (int i = 0; i <= source.Length - filter.Length; i++)
            {
                if (source[i] == filter[0])
                {
                    if (source.Substring(i, filter.Length).Equals(filter))
                    {
                        source = source.Substring(0,i) + source.Substring(i+filter.Length);
                        i = 0;
                    }
                }
            }
            return source;
        }
        public static string FilterStringRecurssive(string source, string filter)
        {
            int len1 = source.Length;
            int len2 = filter.Length;
            for (int i = 0; i <= len1 - len2; i++)
                if (source[i] == filter[0])
                    if (source.Substring(i, len2).Equals(filter))
                        return FilterStringRecurssive(source.Substring(0, i) + source.Substring(i + len2 ), filter);
            return source;
        }
        public static void MaxWordCountWithOutHash(string sentences)
        {
            int maxCount = 0;
            string result = null;
            string[] str=sentences.Split(' ');
            for (int i = 0; i < str.Length; i++)
            {
                int count=1;
                for (int j = i+1; j < str.Length; j++)
                {
                    if (str[i] == str[j])
                        count++;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    result = str[i];
                }
            }
            Console.WriteLine("Word= "+result+"    max count= "+maxCount);
        }
        public static string UniqueCharacters(string input)
        {
            if (input == null || input.Length < 2)
                return input;
            StringBuilder t=new StringBuilder();
            byte[] found = new byte[256];
            foreach (char c in input)
            {
                if (found[c] != 1)
                {
                    t.Append(c);
                    found[c] = 1;
                }
            }
            return t.ToString();
        }
        public static string UniqueCharacters2(string input)
        {
            if (input == null || input.Length < 2)
                return input;
            string ret = string.Empty;
            List<char> uniqueList = new List<char>();
            foreach (char ch in input)
            {
                if (!uniqueList.Contains(ch))
                {
                    ret += ch.ToString();
                    uniqueList.Add(ch);
                }
            }
            return ret;

        }

        public static void Permtuation(String s) 
        {
            Permtuation("", s); 
        }
        private static void Permtuation(String prefix, String s) 
        {
            int N = s.Length;
            if (N == 0) 
                Console.WriteLine(prefix);
            else 
            {
                for (int i = 0; i < N; i++)
                    Permtuation(prefix + s[i], s.Substring(0, i) + s.Substring(i + 1));
            }

        }

        public static void Combination(String s) 
        { 
            Combination("", s); 
        }

        // print all subsets of the remaining elements, with given prefix 
        private static void Combination(String prefix, String s) 
        {
            if (s.Length > 0) 
            {
                Console.WriteLine(prefix + s[0]);
                Combination(prefix + s[0], s.Substring(1));
                Combination(prefix, s.Substring(1));
            }
        }


        public static IList<string> GetLongestString(int nTh, List<string> input)
        {            
            if (nTh > input.Count || nTh < 1) 
            { 
                throw new Exception("nTh is not valid") ; 
            }

            IList<string> result = new List<string>();
            List<int> length = new List<int>();

            foreach (string str in input)
            {
                length.Add(str.Length);
            }

            length.Sort();
            int index = length.Count - 1;
            int count = 1;
            while(count < nTh)
            {
                if(length[index] != length[index-1])
                    count++;
                index--;

                // handling cases where there are many duplicates {2, "aaa","ddd", "ccc"} -> returns null as there is no 2nd
                if(index ==0 && count <nTh)
                {
                    throw new Exception("There is no valid nTh longest string in the list");
                }
            }
            
            foreach (string str in input)
            {
                if (str.Length == length[index])
                    result.Add(str);
            }

            return result;
        }

    }
}
