using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetStuffOOP
{
    class Threading
    {
        static bool _done;
        static readonly object _locker = new object();
        static void Main1(string[] args)
        {
            Thread thrd = Thread.CurrentThread;

            thrd.Name = "Main Thread"; 
            //Thread t = new Thread(WriteY); // Kick off a new thread
            //t.Start(); // running WriteY()
            //// Simultaneously, do something on the main thread.
            //for (int i = 0; i < 1000; i++)                
            //    Console.Write("x");
            //Thread t = new Thread(Go);
            //t.Name = "working thread";
            //t.Start();
            //Go();

            //try
            //{
            //    Thread t = new Thread(Go);
            //    t.IsBackground = true;
            //    t.Start();
            //}
            //catch (Exception ex)
            //{
            //    // We'll never get here!
            //    Console.WriteLine("Exception!");
            //}

            //using (Process p = Process.GetCurrentProcess())
            //    p.PriorityClass = ProcessPriorityClass.High;

            //var signal = new ManualResetEvent(false);
            //new Thread(() =>
            //{
            //    Console.WriteLine("Waiting for signal...");
            //    signal.WaitOne();
            //    signal.Dispose();
            //    Console.WriteLine("Got signal!");
            //}).Start();

            //Thread.Sleep(2000);
            //signal.Set(); // "Open" the signal

            //thread pool threads r backgroung
            //Task.Run(() => Console.WriteLine("Hello from the thread pool"));
            //ThreadPool.QueueUserWorkItem(notUsed => Console.WriteLine("Hello from the thread pool. Oldies..."));
            
            //Task task = Task.Run(() =>
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine("Foo");
            //});
            //Console.WriteLine(task.IsCompleted); // False
            //task.Wait(); // Blocks until task is complete

            //Task<int> primeNumberTask = Task.Run(() =>
            //    Enumerable.Range(2, 3000000).Count(n =>
            //        Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
            //Console.WriteLine("Task running...");
            //Console.WriteLine("The answer is " + primeNumberTask.Result); // you can catch exception here

            ////continuation...lets task do more when it's done
            //Task<int> primeNumberTask = Task.Run(() =>
            //    Enumerable.Range(2, 3000000).Count(n =>
            //    Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
            //var awaiter = primeNumberTask.GetAwaiter();
            //awaiter.OnCompleted(() =>
            //{
            //    int result = awaiter.GetResult();
            //    Console.WriteLine(result); // Writes result
            //    Console.WriteLine("more work...It’s valid to attach a continuation to an already-completed task");
            //});

            ////TaskCompletionSource -> Ability to propagate return values, exceptions, and continuations
            //var tcs = new TaskCompletionSource<int>();
            //new Thread(() => { Thread.Sleep(5000); tcs.SetResult(42); })
            //.Start();
            //Task<int> task = tcs.Task; // Our "slave" task.
            //Console.WriteLine(task.Result); // 42

            //The real power of TaskCompletionSource is in creating tasks that don’t tie up threads.
            //Delay(3000).GetAwaiter().OnCompleted(() => Console.WriteLine(42));
            // Task.Delay (5000).GetAwaiter().OnCompleted (() => Console.WriteLine (42)); --> A static method on task.Task.Delay is the asynchronous equivalent of Thread.Sleep.

            //Async await 
            var contentLength = AccessTheWebAsync();

            string str = String.Format("\r\nLength of the downloaded string: {0}.\r\n", contentLength.Result);
            //resultsTextBox.Text += str;
            Console.WriteLine(str);
            
            //bool addData = true;
            //Task task1 = Task.Run(() =>
            //    {
            //        while (true)
            //        {
            //            if (addData)
            //            {
            //                Console.WriteLine("data produced");
            //                addData = false; 
            //            }
                        
            //        }
            //    });
            //Task task2 = Task.Run(() =>
            //{

            //    while (true)
            //    {
            //        if (!addData)
            //        {
            //            Console.WriteLine("data consumed..........");
            //            addData = true; 
            //        }
                    
            //    }
            //});


            Console.WriteLine("Task running...");

            Console.ReadKey();
        }
        static async Task<int> AccessTheWebAsync()
        {
            // You need to add a reference to System.Net.Http to declare client.
            HttpClient client = new HttpClient();

            // GetStringAsync returns a Task<string>. That means that when you await the 
            // task you'll get a string (urlContents).
            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");

            // You can do work here that doesn't rely on the string from GetStringAsync.
            DoIndependentWork();

            // The await operator suspends AccessTheWebAsync. 
            //  - AccessTheWebAsync can't continue until getStringTask is complete. 
            //  - Meanwhile, control returns to the caller of AccessTheWebAsync. 
            //  - Control resumes here when getStringTask is complete.  
            //  - The await operator then retrieves the string result from getStringTask. 
            string urlContents = await getStringTask;

            // The return statement specifies an integer result. 
            // Any methods that are awaiting AccessTheWebAsync retrieve the length value. 
            return urlContents.Length;
        }

        static void DoIndependentWork()
        {
            //resultsTextBox.Text += "Working . . . . . . .\r\n";
            Console.WriteLine("Working...");
        }
        static Task Delay(int milliseconds)
        {
            var tcs = new TaskCompletionSource<object>();
            var timer = new System.Timers.Timer(milliseconds) { AutoReset = false };
            timer.Elapsed += delegate { timer.Dispose(); tcs.SetResult(null); };
            timer.Start();
            return tcs.Task;
        }
        static void WriteY()
        {

            for (int i = 0; i < 1000; i++)
            {                
                Console.Write("y");
            }
        }
        static void Go()
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            int x = 10;
            int y;
            Thread.Sleep(5000);
            y = x;
            lock (_locker)
            {
                if (!_done) { Console.WriteLine("Done"); _done = true; }
            }
        }
    }
}
