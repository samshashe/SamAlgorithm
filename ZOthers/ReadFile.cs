using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZOthers
{
    class ReadFile
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string line;
            double sum = 0;
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Administrator\Desktop\billionaires.txt");
            while ((line = file.ReadLine()) != null)
            {
                bool moneyStart = false;
                //Console.WriteLine(line);
                string dollarPart = "";
                for (int i = 0; i < line.Length; i++)
                {                    
                    if(line[i] == '$')
                    {
                        moneyStart = true;
                        continue;
                    }

                    if (moneyStart == true)
                    {
                        if(line[i] == ' ')
                        {
                            //Console.WriteLine(dollarPart);
                            sum += Convert.ToDouble(dollarPart);
                            moneyStart = false;
                            break;
                        }
                        dollarPart += line[i];
                    }
                }
                counter++;
            }

            file.Close();
            Console.WriteLine("Total count = " + counter + "     TotalSum = " + sum);
            // Suspend the screen.
            Console.ReadLine();
        }
    }
}
