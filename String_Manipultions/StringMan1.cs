using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace String_Manipultions
{
    class StringMan1
    {
        static void Main1(string[] args)
        {
            //Console.WriteLine("reverse of samson---->"+reverseString1("kibur"));
            //Console.WriteLine("reverse of samson---->" + reverseString2("abc"));
            //Console.WriteLine((int)('a'));
            //mysplit("the .better the,fox c.sam");
            //mysplit("one two,three:four.");
            //Console.WriteLine(ReverseString("this is seattle"));
            //mysplit("th,is is sea:tt.le");
            //Console.WriteLine(ReversePhrase2("this is      samson why"));
            //Console.WriteLine(FindCount2014("sam is the man he is sure the man the she", "is"));
            //Console.WriteLine(FrequentWord("Look mom, the pretty bird! Come bird! Little blue bird don't fly away!"));
            //Console.WriteLine(Substitute2014("ramronrrr",'r','s'));
            //Console.WriteLine(SubString("MynameisChris",4));
            //Console.WriteLine("Inte value = "+GetIntValue("233"));
            //Console.WriteLine((new DateTime(234)).Equals(new DateTime(234)));
            //Console.WriteLine("---->"+multiplyByShift(5,3));
            //Console.WriteLine("int value of 334---->" + GetIntValue2("+384"));
            //Console.WriteLine("string intersection="+StringIntersection("shashemene","samson"));
            //Console.WriteLine("min window---->" + MinWindow("axbyzcffb","fzca"));
            Console.WriteLine("isnumber = " + IsNumber("-44.8"));
            Console.ReadKey();
        }
        // method to reverse a given string using StringBuilder
        public static string reverseString1(string s)
        {
            
            StringBuilder str =new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                str.Append(s[i]);
            }
            return str.ToString();
        }
        // method to reverse a string in place
        public static string reverseString2(string str)
        {
            //
            int last = str.Length-1;
            char[] data = str.ToCharArray();
            
            for (int first = 0; first < last; first++, last--)
            {
                char temp = data[first];
                data[first] = data[last];
                data[last] = temp;
            }

            return new string(data);
        }
        // removing characters from one string that are found in another string in m + n operation
        public static string removeChars1(string orig, string rem)
        {
            int[] h = getBucket(rem);
            StringBuilder res = new StringBuilder();
            for (int k = 0; k < orig.Length; k++)
            {
                if (h[(int)orig[k]] != 1)
                    res.Append(orig[k]);
            }
            return res.ToString();
        }
        private static int[] getBucket(string str)
        {
            int[] h = new int[256];
            for (int k = 0; k < str.Length; k++)
            {
                int ch = (int)str[k];
                h[ch] = 1;
            }
            return h;
        }
        // m * n operation
        public static string removeChars2(string orig, string rem)
        {
            StringBuilder res = new StringBuilder();
            for (int k = 0; k < orig.Length; k++)
            {
                for (int j = 0; j < rem.Length; j++)
                {
                    if (orig[k] == rem[j])
                        break;
                    if (j == rem.Length - 1)
                        res.Append(orig[k]);
                }
            }
            return res.ToString();
        }
        //split with library function
        public static void mysplit(string words)
        {
            string delimStr = " ,.:";
            char[] delimiter = delimStr.ToCharArray();
            //string words = "one two,three:four.";
            string[] split = null;
            Console.WriteLine("The delimiters are -{0}-", delimStr);
            for (int x = 1; x <= 5; x++)
            {
                split = words.Split(delimiter, x);
                Console.WriteLine("\ncount = {0,2} ..............", x);
                foreach (string s in split)
                {
                    Console.WriteLine("-{0}-", s);
                }
            }

        }
        //reverse string using substring function
        public static string ReversePhrase(string str)
        {
            if (str == null)
                throw new Exception("invalid input");
            int strlen = str.Length;
            for (int i = strlen - 1; i > 0; i--)
            {
                if (str[i].Equals(' '))
                {
                    return str.Substring(i + 1) + " " + ReversePhrase(str.Substring(0, i));                      
                }
            }
            return str;
        }
        public static string ReversePhrase2(string input)
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
        public static string FindString(string sentence, string filter)
        {
            int numRep = 0;
            int pos = 0;
            do
            {
                // look for the first occurence of filter from pos   
                for (; pos < (sentence.Length - filter.Length) && (sentence[pos] != filter[0]); pos++) ;
                if (pos < (sentence.Length - filter.Length))
                {
                    // check if match is found
                    if (sentence.Substring(pos, filter.Length).Equals(filter))
                        numRep++;
                }
                pos += filter.Length;

            } while (pos < sentence.Length);

            return filter + "," + numRep;

        }

        public static int FindCount2014(string str, string fil)
        {

            // abc def hac daf def hhh def     // def
            int count = 0;
            for (int i = 0; i < str.Length - fil.Length; i++)
            {
                if (str[i] == fil[0])
                {
                    bool found = true;
                    for (int j = 1; j < fil.Length; j++)
                    {
                        if (str[i + j] != fil[j])
                        {
                            found = false;
                        }
                    }
                    if (found)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static string FrequentWord(string str)
        {
            Hashtable hashtable = new Hashtable();
            int intgr=0;
            string temp=null;
            int mostRepeatedCount = 0;
            string wordMostRepeated= null;
            // Scan str, building hash table with key being a string and value an integer
            for (int i = 0; i < str.Length; i++) 
            {
                if (str[i] != ' ')
                {
                    if ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z'))
                        temp += str[i];
                }
                if (temp != null && (str[i] == ' ' || i == str.Length - 1))
                {
                    
                        if (hashtable.ContainsKey(temp))
                            intgr = (int)hashtable[temp];

                        if (intgr == 0 && temp != null)
                        {
                            hashtable.Add(temp, 1);
                        }
                        else
                        {
                            // Increment count corresponding to temp
                            if (hashtable.ContainsKey(temp))
                            {
                                hashtable[temp] = (int)hashtable[temp] + 1;

                            }
                        }
                        //compare with the current max and set as max if greater
                        if (hashtable.ContainsKey(temp))
                        {
                            if ((int)hashtable[temp] > mostRepeatedCount)
                            {
                                mostRepeatedCount = (int)hashtable[temp];
                                wordMostRepeated = temp;
                            }
                        }

                        temp = null;
                }
                
            }
            return wordMostRepeated + "," + mostRepeatedCount; 
        }
        public static string Substitute(string str,char a,char b)
        {
            if (str == null || str =="") return str;
            StringBuilder output = new StringBuilder(str);
            for (int i = 0; i < output.Length; i++)
            {
                if (output[i] == a)
                {
                    output[i] = b;
                    //if (b == ' ')
                    //    output.Remove(i, 1);
                }

            }
            //output.Replace(" ", null);
            return output.ToString();
        }   
    
        public static string Substitute2014(string str, char old, char neww)
        {
            if(str==null || str==" ") { return str;}
            for(int i=0;i<str.Length;i++)
            {
                if(str[i] == old)
                {
                    str = str.Substring(0,i) + neww + str.Substring(i+1);
                }
            }
            return str;
        }
        public static string SubString(string input, int index)
        {
            if (index == 0)
                return input;
            string temp = null;
            for (int i = index; i < input.Length; i++)
            {
                temp += input[i];
            }
            return temp;
        }    
        public static int GetIntValue(string input)
        {
            int output = 0;
            int factor = 1;
            int i = 0;
            for (i = input.Length - 1; i >= 0; i--)
            {
                if ((input[i] - '0' >= 0) && (input[i] - '0' <= 9))
                    output += (input[i] - '0') * factor;
                else
                {
                    Console.WriteLine("Invalid Input at index location " + (input.Length-1-i));
                    return -1;
                }
                factor *= 10;
            }
            if (i == -1)
                return output;
            return 0;
        }
        public static int GetIntValueWithSign(string input)
        {
            int zero = '0';
            int sum=0;
            // unnessassary step
            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0)
                {
                    if ((input[0] != '-' && input[0] != '+') && (input[i] > '9' || input[i] < '0'))
                        throw new Exception("non digit value in input string");
                   
                }
                else
                {
                     if (input[i] > '9' || input[i] < '0')
                        throw new Exception("non digit value in input string");
                }
            }
            char sign = ' ';
            if (input[0] == '-' || input[0] == '+')
            {
                sign = input[0];
                input = input.Substring(1);
            }
            for (int i = 0; i < input.Length;i++)
            {
                    int number = input[i] - zero;
                    sum = sum * 10 + number;
            }
            if(sign=='-')
                sum = sum-2*sum;
            return sum;
        }
        public static string StringIntersection(string s1, string s2)
        {
            int[] m = new int[256];
            StringBuilder str=new StringBuilder();
            for (int i = 0; i < s1.Length; i++)
            {
                m[s1[i]] = 1;
            }
            for (int j = 0; j < s2.Length; j++)
            {
                if (m[s2[j]]== 1 )
                {
                    str.Append(s2[j]);
                    m[s2[j]] = 2;
                }

            }
            return str.ToString();
        }

        //smallest window in a string containing all characters of another string
        public static string MinWindow(string source, string target)
        {
            if (source == null || target == null)
                throw new Exception("Empty source string");

            int targetMax = 0;
            for (int i = 0; i < target.Length; i++)
            {
                int index = source.IndexOf(target[i]);

                if (index == -1)
                    throw new Exception("All target characters don't exist in source");
                if (index > targetMax)
                {
                    targetMax = index;
                }
            }

            return source.Substring(0, targetMax+1);
        }

        public static bool IsNumber(String input)
        {
            int dotCount = 0;
            for(int i=0; i< input.Length;i++)
            {
                if(input[i] == '.' ) 
                {
                    dotCount++;
                    if(i == input.Length -1 || i==0 || dotCount > 1)
                    {
                        return false;
                    }
                }

                else if(input[i] == '-' )
                {
                    if (i != 0)
                        return false;
                }
                else if (input[i] - '0' < 0 || input[i] - '0' > 9)
                {
                    return false;
                }
            }
            return true;
        }
        
    }
}
