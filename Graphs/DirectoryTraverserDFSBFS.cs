using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Graphs
{
    class DirectoryTraverserDFSBFS
    {
        static void Main1()
        {

            TraverseDirDFS(@"C:\Users\Administrator\Desktop\Traversal");
            TraverseDirBFS(@"C:\Users\Administrator\Desktop\Traversal");
            Console.ReadKey();
        }

        //Traverses and prints given directory recursively
        private static void TraverseDirDFS(DirectoryInfo dir, string spaces)
        {
            // Visit the current directory
            Console.WriteLine(spaces + dir.FullName);            
            DirectoryInfo[] children = dir.GetDirectories();
            // For each child go and visit its sub-tree
            foreach (DirectoryInfo child in children)
            {
                TraverseDirDFS(child, spaces + "  ");
            }

        }
        static void TraverseDirDFS(string directoryPath)
        {
            TraverseDirDFS(new DirectoryInfo(directoryPath), string.Empty);
        }
        
        static void TraverseDirBFS(string directoryPath)
        {
            Queue<DirectoryInfo> visitedDirsQueue = new Queue<DirectoryInfo>();

            visitedDirsQueue.Enqueue(new DirectoryInfo(directoryPath));

            while (visitedDirsQueue.Count > 0)
            {

                DirectoryInfo currentDir = visitedDirsQueue.Dequeue();
                Console.WriteLine(currentDir.FullName);
                DirectoryInfo[] children = currentDir.GetDirectories();

                foreach (DirectoryInfo child in children)
                {
                    visitedDirsQueue.Enqueue(child);
                }
            }
        }
        
    }
}
