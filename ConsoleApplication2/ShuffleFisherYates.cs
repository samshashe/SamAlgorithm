﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class ShuffleFisherYates
    {
        public static void Main1()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Shuffle(array);
            foreach (int value in array)
            {
                Console.WriteLine(value);
            }

            string[] array2 = { "dot", "net", "perls" };
            Shuffle(array2);
            foreach (string value in array2)
            {
                Console.WriteLine(value);
            }

            Console.ReadKey();
        }
        /// <summary>
        /// Used in Shuffle(T).
        /// </summary>
        static Random _random = new Random();

        /// <summary>
        /// Shuffle the array.
        /// </summary>
        /// <typeparam name="T">Array element type.</typeparam>
        /// <param name="array">Array to shuffle.</param>
        public static void Shuffle<T>(T[] array)
        {
            var random = _random;
            for (int i = array.Length; i > 1; i--)
            {
                // Pick random element to swap.
                int j = random.Next(i); // 0 <= j < i
                // Swap.
                T tmp = array[j];
                array[j] = array[i - 1];
                array[i - 1] = tmp;
            }
        }

    }
}
