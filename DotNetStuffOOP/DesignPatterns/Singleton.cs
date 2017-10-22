using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStuffOOP.DesignPatterns
{
    // Ensure a class has only one instance and provide a global point of access to it. This is useful when exactly one object is needed to coordinate actions across the system.
    class SingletonMainApp
    {
        static void Main1()
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            // Confirm these are the same instance
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            // Next, load balance 15 requests for a server
            
            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();

            for (int i = 0; i < 15; i++)
            {
                string serverName = balancer.NextServer.Name;
                Console.WriteLine("Dispatch request to: " + serverName);
            }

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>

    /// The 'Singleton' class

    /// </summary>

    sealed class LoadBalancer
    {
        // Static members are 'eagerly initialized', that is,
        // immediately when class is loaded for the first time.
        // .NET guarantees thread safety for static initialization

        private static LoadBalancer _instance;
        // Type-safe generic list of servers
        private List<Server> _servers;
        private Random _random = new Random();

        private static object syncLock = new object();

        // Note: constructor is 'private'
        private LoadBalancer()
        {
            // Load list of available servers

            _servers = new List<Server>
            {
                 new Server{ Name = "ServerI", IP = "120.14.220.18" },
                 new Server{ Name = "ServerII", IP = "120.14.220.19" },
                 new Server{ Name = "ServerIII", IP = "120.14.220.20" },
                 new Server{ Name = "ServerIV", IP = "120.14.220.21" },
                 new Server{ Name = "ServerV", IP = "120.14.220.22" },
            };
        }
        //Lazy initialization
        public static LoadBalancer GetLoadBalancer()
        {
            // Support multithreaded applications through double checked locking' pattern which (once the instance exists) avoids locking each time the method is invoked
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new LoadBalancer();
                    }
                }
            }
            return _instance;
        }

        public Server NextServer
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r];
            }
        }
    }

    class Server
    {
        public string Name { get; set; }
        public string IP { get; set; }
    }
}
