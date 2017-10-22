using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ZOthers
{
    class Program
    {
        static void Main1(string[] args)
        {
            //System.Diagnostics.Process p = new System.Diagnostics.Process();
            //p.StartInfo.FileName = "ping.exe";
            //p.StartInfo.RedirectStandardOutput = true;
            //p.StartInfo.Arguments = " -a www.google.com";
            //p.StartInfo.UseShellExecute = false;
            //p.Start();
            ////p.WaitForExit();
            //string output = p.StandardOutput.ReadToEnd();
            //Console.WriteLine(output);
            //Console.ReadKey();
            System.Reflection.MemberInfo info = typeof(Process);
            object[] attributes = info.GetCustomAttributes(false);
            for (int i =0 ;i<attributes.Length;i++)
            {
                Console.WriteLine(attributes[i]);
            }
            String str = new String(new char[]{'a','b'});
            //str = null;
            Console.WriteLine("gen = "+GC.GetGeneration(str));
            Console.ReadKey();
        }
    }
}
