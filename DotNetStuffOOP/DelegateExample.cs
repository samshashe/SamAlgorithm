    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStuffOOP
{
    // A delegate instance literally acts as a delegate for the caller: the caller invokes the
    // delegate, and then the delegate calls the target method. This indirection decouples
    // the caller from the target method.

    public delegate bool FilterDelegate(Student p);
    public delegate void ProgressReporter (int percentComplete);
    public delegate int SamLambdaDelegate (int i);
    public delegate int Transformer(int i);

    static class DelegateExample
    {
        static void Main1()
        {

            #region Delegate Example
            ////Create 4 Person objects
            //Student p1 = new Student() { Name = "John", Age = 41 };
            //Student p2 = new Student() { Name = "Jane", Age = 69 };
            //Student p3 = new Student() { Name = "Jake", Age = 12 };
            //Student p4 = new Student() { Name = "Jessie", Age = 25 };

            ////Create a list of Person objects and fill it
            //List<Student> students = new List<Student>() { p1, p2, p3, p4 };
            //DisplayPeople("Children:", students, IsChild);
            //DisplayPeople("Adults:", students, IsAdult);
            //DisplayPeople("Seniors:", students, IsSenior);


            // A muticast delegate with return type returns the result from the last added function
            //FilterDelegate mydel = IsChild;
            //mydel += IsAdult;
            //mydel += IsSenior;

            //foreach (Student p in students)
            //{
            //    if (mydel(p))
            //    {
            //        Console.WriteLine("{0}, {1} years old", p.Name, p.Age);
            //    }
            //}

            //ProgressReporter p = WriteProgressToConsole;
            //p += WriteProgressToFile;
            //HardWork(p);
            //Console.WriteLine(p.Method); 
            #endregion

            #region Lambda Example
            /////////////////////////////LAMBDA EXPRESSIONS///////////////////////////////
            //A lambda expression is an unnamed method written in place of a delegate instance
            //(parameters) => expression-or-statement-block
            //SamLambdaDelegate sqrt = x => x * x;
            //Console.WriteLine(sqrt(5)); //25

            //Func<int, int, int> product = (x, y) => x * y;
            //Console.WriteLine(product(3, 4)); //12
            ////Outer variables referenced by a lambda expression are called captured variables. 
            ////A lambda expression that captures variables is called a closure.
            //int factor = 2;
            //Func<int, int> multiplier = n => n * factor;
            //factor = 10;
            //Console.WriteLine(multiplier(3)); //30

            //int seed = 0;
            //Func<int> natural = () => seed++;
            //Console.WriteLine(natural()); // 0
            //Console.WriteLine(natural()); // 1
            //Console.WriteLine(seed); // 2

            //Action[] actions = new Action[3];
            
            //for (int i = 0; i < 3; i++)
            //{                
            //    actions[i] = () => Console.Write(i);
            //}
            
            //foreach (Action a in actions) a(); // 333

            //Action[] actions2 = new Action[3];
            //int j = 0;
            //actions2[0] = () => Console.Write(j);
            //j = 1;
            //actions2[1] = () => Console.Write(j);
            //j = 2;
            //actions2[2] = () => Console.Write(j);
            //j = 3;
            //foreach (Action a in actions2) a(); // 333

            //Action[] actions3 = new Action[3];
            //for (int i = 0; i < 3; i++)
            //{
            //    int loopScopedi = i;
            //    actions3[i] = () => Console.Write(loopScopedi);
            //}
            //foreach (Action a in actions3) a();  
            #endregion

            #region Anonymous Method Example
            //An anonymous method is like a lambda expression, but it lacks features
            //Transformer sqr = delegate(int x) { return x * x; };
            //Console.WriteLine(sqr(3));
            #endregion
            //Student p1 = new Student() { Name = "John", Age = 41 };
            //Modify(ref p1);
            //Console.WriteLine(p1.Age);

            //foreach (int fib in Fibs(6))
            //    Console.Write(fib + " ");

            int Age = 23;
            
            var dude = new { Name = "Bob", Age, IsEven = Age.IsEven(Age) };

            var dudes = new[]
            {
                new { Name = "Bob", Age = 30 },
                new { Name = "Tom", Age = 40 }
            };

            
            Console.Read();
        }
        public static bool IsEven(this int s, int age)
        {
            if (age % 2 == 0)
                return true;
            else
                return false;
        }


        static void Modify(ref Student s)
        {
            s = new Student() { Name = "John", Age = 77 };
        }
        static void DisplayPeople(string title, List<Student> students, FilterDelegate filter)
        {
            Console.WriteLine(title);

            foreach (Student p in students)
            {
                if (filter(p))
                {
                    Console.WriteLine("{0}, {1} years old", p.Name, p.Age);
                }
            }

            Console.Write("\n\n");
        }
        //==========FILTERS===================
        static bool IsChild(Student p)
        {
            return p.Age <= 18;
        }

        static bool IsAdult(Student p)
        {
            return p.Age >= 18;
        }

        static bool IsSenior(Student p)
        {
            return p.Age >= 65;
        }

        // This can be in another class
        public static void HardWork(ProgressReporter p)
        {
            for (int i = 0; i < 10; i++)
            {
                p(i * 10 ); // Invoke delegate
                System.Threading.Thread.Sleep(100); // Simulate hard work
            }
        }
        
        static void WriteProgressToConsole(int percentComplete)
        {
            Console.WriteLine(percentComplete + "%");
        }
        static void WriteProgressToFile(int percentComplete)
        {
            System.IO.File.WriteAllText("progress.txt",
            percentComplete.ToString());
        }


        //EXCEPTIONS
        public static int Parse(string input)
        {
            int returnValue;
            if (!TryParse(input, out returnValue))
                throw new Exception("Failed when parse is called");
            return returnValue;
        }


        public static bool TryParse(string input, out int returnValue)
        {
            returnValue =1;
            if (input.Contains('$'))
            {
                returnValue = -1;
                return false;
            }
            return true;
        }

        static IEnumerable<int> Fibs (int fibCount)
        {
            for (int i = 0, prevFib = 1, curFib = 1; i < fibCount; i++)
            {
                yield return prevFib;
                int newFib = prevFib+curFib;
                prevFib = curFib;
                curFib = newFib;
            }
        }
        

    }
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    
}
