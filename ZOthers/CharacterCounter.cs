using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace UnitTestApplication
{
    public class CharacterCounter
    {
        public Hashtable CountOfEachCharacter(String text)
        {
            if (text == null || text.Length == 0)
                throw new System.ArgumentException("Parameter cannot be empty or null", "text");
            Hashtable ht = new Hashtable();
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                {
                    if (ht.ContainsKey(text[i]))
                        ht[text[i]] = (int)ht[text[i]] + 1;
                    else
                        ht.Add(text[i], 1);
                }
            }
            return ht;
        }
    }
}




