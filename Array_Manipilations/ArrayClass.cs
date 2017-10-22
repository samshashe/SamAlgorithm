using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Array_Manipilations
{
    class ArrayClass
    {
        static void Main(string[] args)
        {

            //removeDuplicate(new int[]{1,1,2,2});
            //Console.WriteLine("Rotation by: "+FindSortedArrayRotation1(new int[] {4,5,3}));
            //int[] x = RotateArray2014(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 2);
            //int[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };
            //RotateArrayRec(x, 2);
            //for (int i = 0; i < x.Length; i++)
            //    Console.WriteLine(x[i]);

            //Console.WriteLine("MappingsCount = " + MappingsCount("1122"));
            //int[] x = MergeSortedArray2015(new int[] { 13, 59 }, new int[] { 2, 4, 8, 10,13 });
            //for (int i = 0; i < x.Length; i++)
            //    Console.WriteLine(x[i]);
            //int[] result = MergeSortedArrayInPlace2015(new int[] { 3, 4, 5, 8, 0, 0, 0 }, new int[] { 1, 2, 97 });
            //for (int i = 0; i < result.Length; i++)
            //    Console.WriteLine("a[" + i + "]=" + result[i]);
            //removeDuplicate2014(new int[] { 1,3,3,3,3, 3, 4, 4, 5,5 });
            //int[,] a=new int[4,4];
            //SpiralDisplay(new int[,]{{1,2,3,4},{5,6,7,8},{9,10,11,12},{13,14,15,16},{17,18,19,20},{21,22,23,24}});
            //Console.WriteLine("4th largest=" + ForthLargest(new int[] { 55, 16, 55, 66, 77,33 }));
            //Console.WriteLine("Closed Doors="+ClosedDoors());
            //DispalyOccurence(new int[]{1,2,1,3,4,2,5,1});
            //Console.WriteLine("True Count = " + CountTrue(new bool[,] {{true,true,true,false,false,false},{true,true,true,false,false,false},{true,true,true,false,false,false},{true,true,false,false,false,false},{true,true,false,false,false,false},{true,false,false,false,false,false},{false,false,false,false,false,false}}));
            //int[,] a = new int[6, 4];
            //for (int i = 0; i < a.GetLength(0); i++)
            //    for (int j = 0; j < a.GetLength(1); j++)
            //        a[i, j] = (i+1) * (j+1);
            //Display2D(a);
            //TenLargest2(new int[]{31,32,63,4,85,6,7,8,9,110,11,12,513,14,15,16,17,18,19,20});
            //TenLargest(new int[] {1, 31, 32, 63, 4, 85, 6, 7, 8, 9 });
            //NumberOfOccurance(new int[] { 1, 1, 3, 3, 5, 8, 8, 8 });
            //SumThreeToZero(new float[] { -4,-3,-2,-1,0,1,2,3 });
            //Console.WriteLine("binary search result index  = " + BinarySearch(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 },0,7,5));
            //Console.WriteLine("rotated bst  = " + SearchRotated(new int[] { 4, 5, 6, 7, 8, 1, 2, 3 }, 3));
            //Console.WriteLine("pivot index  = " + FindPivot(new int[] { 4, 5, 6, 7, 8, 1, 2, 3 }, 0, 7));
            Console.WriteLine("FirstDupicateItem  = " + FirstDupicateItem(new int[] { 1,5,6,7,1,8}));
            Console.ReadKey();
        }

        //inplace remove duplicate sorted
        public static void removeDuplicate2014(int[] input)
        {
            Console.WriteLine(input[0]);
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i + 1] != input[i])
                {
                    Console.WriteLine(input[i + 1]);
                }
            }
        }
        public static void removeDuplicate(int[] input)
        {
            if (input.Length == 0) { return; }
            int k = 0;
            int len = input.Length;

            for (int j = 1; j < len; j++)
            {
                if (input[j] != input[j - 1])
                {
                    input[k++] = input[j - 1];
                }
            }
            input[k] = input[len - 1];

            for (int l = 0; l <= k; l++)
            {
                Console.WriteLine(input[l].ToString());
            }
            //Console.WriteLine("the size of the array is );
        }

        public static int FirstDupicateItem(int[] arr)
        {
            if (arr.Length < 2)
            {
                throw new Exception("invalid array");
            }
            int ret = -1;
            HashSet<int> mySet = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!mySet.Contains(arr[i]))
                {
                    mySet.Add(arr[i]);
                }
                else
                {
                    ret = arr[i];
                    break;
                }
            }

            return ret;

        }
        //find rotation
        public static int FindSortedArrayRotation1(int[] arr)
        {
            int rotation = 0;
            int i = 1;
            for (; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                    break;
            }
            if (i != arr.Length)
                rotation = i;
            return rotation;
        }
        public static int FindSortedArrayRotation2(int[] arr)
        {
            //find the postion of the minimum element in the array
            // postion of the mininimum element equals the rotation factor
            if (arr.Length == 0) return 0; // for empty array
            int min = arr[0];
            int minPos = 0;
            int arrayLength = arr.Length;

            for (int i = 1, j = arrayLength - 1; i <= j; i++, j--)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    minPos = i;
                }
                if (arr[j] < min)
                {
                    min = arr[j];
                    minPos = j;
                }
            }
            return minPos;
        }
        public static int[] RotateArray(int[] arr, int rotation)
        {
            if (arr.Length == 1 || rotation == 0) return arr;
            ////////////////NOT COMPLETE///////////////////////
            for (int i = 0; i < rotation / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[arr.Length - rotation - i];
                arr[arr.Length - rotation - i] = temp;
            }
            for (int i = arr.Length - rotation, m = 1; i < arr.Length - 1 - rotation / 2; m++, i++)
            {
                int temp = arr[i];
                arr[i] = arr[arr.Length - m];
                arr[arr.Length - m] = temp;
            }
            //1...not in place
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    int m = (i + rotation) % arr.Length;
            //    temp[m] = arr[i];
            //}
            //return temp;
            //2
            //int current = 0;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    int m = (i + rotation) % arr.Length;
            //    if (current >= rotation)
            //        current=0;
            //    int temp = arr[m];
            //    arr[m] = arr[current];
            //    arr[current] = temp;
            //    current++;

            //}
            return arr;
        }
        public static int[] RotateArray2(int[] arr, int rot)
        {
            if (rot == 0) return arr;
            rot -= 1;
            ReverseArray(arr, 0, rot);
            ReverseArray(arr, rot + 1, arr.Length - 1);
            ReverseArray(arr, 0, arr.Length - 1);
            return arr;
        }

        public static int[] RotateArray2014(int[] arr, int rot)
        {
            if (arr.Length == 0 || arr.Length == 1) { return arr; }

            // 1,2,3,4,5,6,7,8
            // 6,7,8,1,2,3,4,5
            rot = rot % arr.Length;
            int[] tempArr = new int[rot];
            int count = 0;
            rot = rot % arr.Length;
            for (int i = 0; i < rot; i++)
            {
                tempArr[i] = arr[i];
            }
            for (int k = rot; k < arr.Length; k++)
            {
                arr[count++] = arr[k];
            }
            for (int i = 0; i < tempArr.Length; i++)
            {
                arr[count++] = tempArr[i];
            }

            return arr;
        }

        public static int[] RotateArray20142(int[] arr, int rot)
        {
            if (arr.Length == 0 || arr.Length == 1) { return arr; }

            // 1,2,3,4,5,6,7,8
            // 6,7,8,1,2,3,4,5
            rot = rot % arr.Length;
            int[] resArray = new int[arr.Length];

            for (int i = rot, j = 0; j < arr.Length; i++, j++)
            {
                resArray[i] = arr[j];
                if (i == arr.Length - 1)
                {
                    i = -1;
                }
            }

            return resArray;
        }

        public static void RotateArrayRec(int[] A, int pos)
        {
            pos = pos % A.Length;
            if (pos <= 0) return;
            int len = A.Length - 1;
            int temp = A[len];

            for (int i = len; i > 0; i--)
            {
                A[i] = A[i - 1];
            }

            A[0] = temp;
            pos--;
            if (pos == 0) return;
            RotateArrayRec(A, pos);
        }

        //Implement the method to reverse the array
        private static int[] ReverseArray(int[] a, int lower, int upper)
        {
            for (int i = lower; i < upper; i++, upper--)
            {
                int temp = a[i];
                a[i] = a[upper];
                a[upper] = temp;
            }
            return a;
        }

        public static int MappingsCount(String str)
        {

            char[] arr = str.ToCharArray();

            int lastWays = 1;
            int preLastWays = 1;

            if (arr[arr.Length - 1] == '0')
            {
                preLastWays = 0;
            }

            for (int i = arr.Length - 2; i >= 0; i--)
            {
                int value = arr[i] - '0';
                int curCount = 0;

                if (value != 0)
                {
                    curCount += preLastWays;

                    value = value * 10 + arr[i + 1] - '0';
                    Console.WriteLine("value = " + value);
                    if (value < 27)
                    {
                        curCount += lastWays;
                    }
                }

                lastWays = preLastWays;
                preLastWays = curCount;
            }

            return preLastWays;
        }
        public static int[] MergeSortedArray(int[] first, int[] second)
        {
            int[] big = new int[first.Length + second.Length];
            int fc = 0, sc = 0, bc = 0;
            Console.WriteLine("length of big" + big.Length);
            while (fc < first.Length && sc < second.Length)
            {
                if (first[fc] > second[sc])
                    big[bc++] = second[sc++];
                else
                    big[bc++] = first[fc++];
            }
            //for (int i = 0; i < big.Length; i++)
            //    Console.WriteLine(bc);

            if (sc == second.Length)
                for (int i = fc; i < first.Length; i++)
                    big[bc++] = first[i];
            else
                for (int j = sc; j < second.Length; j++)
                    big[bc++] = first[j];

            return big;

        }

        public static int[] MergeSortedArray2(int[] a, int[] b)
        {
            if (a.Length == 0 && b.Length == 0)
                return new int[] { };
            if (a.Length == 0)
                return b;
            if (b.Length == 0)
                return a;
            int length = a.Length + b.Length;
            int[] c = new int[length];
            int index1 = 0, index2 = 0, index3 = 0;
            bool a_over = false, b_over = false;
            while (index3 < length)
            {
                if (index1 == a.Length)
                    a_over = true;
                if (index2 == b.Length)
                    b_over = true;
                if (!a_over)
                {
                    if (b_over)
                        c[index3++] = a[index1++];
                    else if (b[index1] > a[index2])
                    {
                        c[index3++] = a[index1++];

                    }
                }
                if (!b_over)
                {
                    if (a_over)
                        c[index3++] = a[index2++];
                    else if (b[index2] > a[index1])
                    {
                        c[index3++] = a[index2++];

                    }
                }
            }
            return c;
        }
        public static int[] MergeSortedArray2015(int[] first, int[] second)
        {
            int[] big = new int[first.Length + second.Length];
            int fc = 0, sc = 0, bigIndex = 0;
            for (int k = 0; k < big.Length; k++)
            {
                if (fc > first.Length - 1)
                {
                    big[bigIndex++] = second[sc++];
                    continue;
                }
                if (sc > second.Length - 1)
                {
                    big[bigIndex++] = first[fc++];
                    continue;
                }
                if (first[fc] >= second[sc])
                    big[bigIndex++] = second[sc++];
                else if (first[fc] < second[sc])
                    big[bigIndex++] = first[fc++];
            }

            return big;

        }// working

        public static int[] MergeSortedArrayInPlace2015(int[] first, int[] second)// working
        {
            int fc = first.Length - second.Length - 1, sc = second.Length - 1;
            for (int k = first.Length - 1; k >= 0; k--)
            {
                if (sc < 0)
                {
                    first[k] = first[fc--];
                    continue;
                }
                if (fc < 0)
                {
                    first[k] = second[sc--];
                    continue;
                }
                if (first[fc] >= second[sc])
                    first[k] = first[fc--];
                else if (first[fc] < second[sc])
                    first[k] = second[sc--];
            }

            return first;

        }
        public static int[] MergeSortedInPlace(int[] a, int[] b)
        {
            int len1 = a.Length;
            int len2 = b.Length;

            int m = len1 - len2 - 1, n = len2 - 1, k = 0;
            for (k = len1 - 1; k > 0; k--)
            {
                if (n >= 0 && m >= 0)
                {
                    if (a[m] > b[n])
                    {
                        a[k] = a[m--];
                    }
                    else
                    {
                        a[k] = b[n--];
                    }
                }
                else
                {
                    break;
                }
            }
            if (n >= 0)
            {
                for (int i = k; i >= 0; i--)
                {
                    a[i] = b[n--];
                }
            }
            if (m >= 0)
            {
                for (int i = k; i >= 0; i--)
                {
                    a[i] = a[m--];
                }
            }

            return a;
        }
        public static void SpiralDisplay(int[,] a)
        {
            int col_start = 0, col_end = a.GetLength(0) - 1, row_start = 0, row_end = a.GetLength(1) - 1;

            for (int i = 0; col_start <= col_end && row_start <= row_end; i++)
            {

                for (int k = row_start; k <= row_end; k++)
                    Console.WriteLine(a[col_start, k]);
                col_start++;
                for (int k = col_start; k <= col_end; k++)
                    Console.WriteLine(a[k, row_end]);

                row_end--;
                for (int k = row_end; k >= row_start; k--)
                    Console.WriteLine(a[col_end, k]);

                col_end--;
                for (int k = col_end; k >= col_start; k--)
                    Console.WriteLine(a[k, row_start]);
                row_start++;

            }

        }
        public static int SecondLarge(int[] a)
        {
            int max1 = a[0], max2 = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > max1)
                {
                    max2 = max1;
                    max1 = a[i];
                }
                else if (a[i] > max2 && a[i] != max1)
                    max2 = a[i];
            }
            return max2;
        }
        public static int ForthLargest(int[] a)
        {
            int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue, max4 = int.MinValue;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > max1)
                {
                    max4 = max3;
                    max3 = max2;
                    max2 = max1;
                    max1 = a[i];
                }
                else if (a[i] > max2 && a[i] != max1)
                {
                    max4 = max3;
                    max3 = max2;
                    max2 = a[i];
                }
                else if (a[i] > max3 && a[i] != max2 && a[i] != max1)
                {
                    max4 = max3;
                    max3 = a[i];
                }
                else if (a[i] > max4 && a[i] != max3 && a[i] != max2 && a[i] != max1)
                {
                    max4 = a[i];
                }

            }
            Console.WriteLine("max1=" + max1 + " max2= " + max2 + " max3= " + max3);
            return max4;
        }
        public static int ClosedDoors()
        {
            int[] door = new int[50];
            int closed = 0;
            for (int i = 0; i < door.Length; i++)
            {
                for (int j = i; j < door.Length; j += (i + 1))
                {
                    door[j] = (door[j] == 0) ? 1 : 0;

                }
                if (door[i] == 1)
                    closed++;
                for (int k = 0; k < door.Length; k++)
                    Console.Write(door[k]);
                Console.WriteLine();
            }
            return closed;
        }
        public static int CountTrue(bool[,] arr)
        {
            if (arr.Length == 0) return 0;
            int length = arr.GetLength(0);
            int i = length, y = 0, m = 0, ycount = 0, total = 0;
            while (i > 0 && y < arr.GetLength(1))
            {
                for (m = i; arr[m - 1, y] != true; m--)
                    i--;
                for (int j = 0; arr[m - 1, j] != true; j++)
                {
                    ycount++;
                    y++;
                }
                total += (length - i) * ycount;

                ycount = 0;
            }
            return total;

        }
        public static void Display2D(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("   " + arr[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static void DispalyOccurence(int[] arr)
        {
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            for (int i = 0; i < arr.Length; i++)
            {
                int val;
                if (ht[arr[i]] == null)
                {
                    ht.Add(arr[i], 1);
                }
                else
                {
                    val = (int)ht[arr[i]];
                    ht[arr[i]] = val + 1;
                }

            }
            foreach (System.Collections.DictionaryEntry e in ht)
            {
                Console.WriteLine(e.Key + "---existed----" + e.Value + "  times");
            }
        }
        public static void TenLargest(int[] arr)
        {
            int[] max = new int[10];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max[0])
                {
                    for (int j = 1; j < max.Length; j++)
                    {
                        max[j] = max[j - 1];
                    }
                    max[0] = arr[i];
                }
                else if (arr[i] > max[1])
                {

                    for (int j = 2; j < max.Length; j++)
                    {
                        max[j] = max[j - 1];
                    }
                    max[1] = arr[i];
                }
                else if (arr[i] > max[2])
                {

                    for (int j = 3; j < max.Length; j++)
                    {
                        max[j] = max[j - 1];
                    }
                    max[2] = arr[i];
                }
                else if (arr[i] > max[3])
                {

                    for (int j = 4; j < max.Length; j++)
                    {
                        max[j] = max[j - 1];
                    }
                    max[3] = arr[i];
                }
                else if (arr[i] > max[4])
                {

                    for (int j = 5; j < max.Length; j++)
                    {
                        max[j] = max[j - 1];
                    }
                    max[4] = arr[i];
                }
                else if (arr[i] > max[5])
                {

                    for (int j = 6; j < max.Length; j++)
                    {
                        max[j] = max[j - 1];
                    }
                    max[5] = arr[i];
                }
                else if (arr[i] > max[6])
                {

                    for (int j = 7; j < max.Length; j++)
                    {
                        max[j] = max[j - 1];
                    }
                    max[6] = arr[i];
                }
                else if (arr[i] > max[7])
                {

                    for (int j = 8; j < max.Length; j++)
                    {
                        max[j] = max[j - 1];
                    }
                    max[7] = arr[i];
                }
                else if (arr[i] > max[8])
                {

                    arr[9] = max[8];
                    max[8] = arr[i];
                }
                else if (arr[i] > max[9])
                {
                    max[9] = arr[i];
                }
            }
            for (int i = 0; i < max.Length; i++)
                Console.WriteLine(max[i]);
        }
        public static void TenLargest2(int[] arr)
        {
            int[] max = new int[10];
            for (int i = 0; i < max.Length; i++)
            {
                max[i] = arr[i];
            }
            for (int i = 10; i < arr.Length; i++)
            {
                if (arr[i] > max[min(max)])
                {
                    max[min(max)] = arr[i];
                }
            }
            for (int i = 0; i < max.Length; i++)
                Console.WriteLine(max[i]);

        }
        private static int min(int[] arr)
        {
            int min = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < arr[min])
                    min = i;
            }
            return min;
        }
        //6-this program displays the character or integer and it's number of occurance.
        public static void NumberOfOccurance(int[] arr)
        {
            if (arr == null)
                throw new Exception("Empty array");

            int arrlen = arr.Length;
            for (int i = 0; i < arrlen; i++)
            {
                int count = 0;
                bool done = false;
                for (int j = 0; j < i; j++)
                {
                    if (arr[i].Equals(arr[j]))
                        done = true;
                    break;
                }
                if (!done)
                {
                    for (int k = i + 1; k < arrlen; k++)
                    {
                        if (arr[i].Equals(arr[k]))
                        {
                            count++;
                        }
                    }
                    Console.WriteLine(arr[i] + "=" + ++count);
                    done = false;
                }
            }
        }
        //7-this program finds the sub array from the given array
        public static void FindSubArray(int[] arr1, int[] arr2)
        {
            int len1 = arr1.Length;
            int len2 = arr2.Length;
            if (arr2 == null)
                throw new Exception("Empty sub array");
            else if (len2 > len1)
                Console.WriteLine("the sub array is greater than the original array");
            else if (len1 == len2)
                Console.WriteLine("the two arrays are equal");
            else
            {
                bool found = true;
                for (int i = 0; i < len1 - len2; i++)
                {
                    if (arr1[i].Equals(arr2[0]))
                    {
                        for (int j = 1; j < len2; j++)
                        {
                            if (!arr1[i + j].Equals(arr2[j]))
                            {
                                found = false;
                                break;
                            }
                        }
                    }
                }
                if (found)
                    Console.WriteLine("the subarray is found");
                else
                    Console.WriteLine("the subarray is not found");
            }
        }
        //9- Removes duplicates from unsorted array
        public static void RemoveDuplicate(int[] myarray)
        {
            if (myarray == null)
                throw new Exception("invalid input");
            else
            {
                int temp;
                for (int i = 0; i < myarray.Length; i++)
                {
                    for (int j = i + 1; j < myarray.Length; j++)
                    {
                        if (myarray[i] > myarray[j])
                        {
                            temp = myarray[i];
                            myarray[i] = myarray[j];
                            myarray[j] = temp;
                        }
                    }
                }
            }
            int len = myarray.Length;
            int count = 0;
            int k = 0;
            for (int i = 0; i < len - 1; i++)
            {
                if (myarray[i] != myarray[i + 1])
                {
                    count++;
                }
            }
            count++;
            for (int j = 0; j < len - 1; j++)
            {
                if (myarray[j] != myarray[j + 1])
                    myarray[k++] = myarray[j];
            }
            myarray[k] = myarray[len - 1];
            for (int l = 0; l < count; l++)
            {
                Console.WriteLine(myarray[l].ToString());
            }
            Console.WriteLine("the size of the array is :" + count);
        }
        public static int[] removeDuplicate2(int[] input)
        {
            int[] myarray;
            if (input == null)
                throw new Exception("the array is empty");
            else if (input.Length == 0)
                throw new Exception("0 zize array");
            else if (input.Length == 1)
                return input;
            else
            {
                int len = input.Length;
                int count = 0;
                int k = 0;
                for (int i = 0; i < len - 1; i++)
                {
                    if (input[i] != input[i + 1])
                    {
                        count++;
                    }
                }
                count++;
                myarray = new int[count];
                for (int j = 0; j < len - 1; j++)
                {
                    if (input[j] != input[j + 1])
                        myarray[k++] = input[j];
                }
                myarray[k] = input[len - 1];
            }
            return myarray;
        }
        //22. Merge Arrays
        public static int[] mergeArrays(int[] arr1, int[] arr2)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int[] arr = new int[arr1.Length + arr2.Length];
            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] < arr2[j])
                {
                    arr[k++] = arr1[i];
                    i++;
                }
                else
                {
                    arr[k++] = arr2[j];
                    j++;
                }
                if (i >= arr1.Length && j < arr2.Length)
                {
                    while (j < arr2.Length)
                    {
                        arr[k] = arr2[j];
                        j++;
                        k++;
                    }
                }
                if (j >= arr2.Length && i < arr1.Length)
                {
                    while (i < arr1.Length)
                    {
                        arr[k] = arr1[i];
                        i++;
                        k++;
                    }
                }
            }
            foreach (int n in arr)
                Console.WriteLine(n);
            return arr;
        }
        //23. SECOND MAX
        public static void secondMax(int[] arr)
        {
            if (arr.Equals(null))
            {
                throw new Exception("Null array");
            }
            else if (arr.Length == 0)
            {
                Console.WriteLine("0 elemets");
                return;
            }
            else
            {
                int max1 = arr[0];
                int max2 = -1;
                int counter = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > max1)
                    {
                        max1 = arr[i];
                        counter = i;
                    }
                }
                Console.WriteLine("Max = {0}", max1);
                for (int i = 0; i < arr.Length; i++)
                    if (arr[i] > max2 && i != counter)
                    {
                        max2 = arr[i];
                    }
                Console.WriteLine("Second max ={0}", max2);
                Console.WriteLine("Elements in array: {0} ", counter);
            }
        }
        //30. Identify the number repeated
        public static void findRepeated(int[] arr1, int[] arr2)
        {
            int sum1, sum2;
            sum1 = 0;
            sum2 = 0;
            if (arr1 == null || arr2 == null)
                throw new Exception("Invalid input!");
            else
            {
                for (int i = 0; i < arr1.Length; i++)
                    sum1 += arr1[i];
                for (int j = 0; j < arr2.Length; j++)
                    sum2 += arr2[j];
                int diff = Math.Abs(sum1 - sum2);
                Console.WriteLine(diff);
            }
        }

        public static bool SumThreeToZero(float[] arr)
        {
            if (arr.Length < 3) return false;
            // -3,-2,-1,0,1,2,3,4
            //arr.Sort();//ascending
            //int start = 0, end = arr.Length-1;
            for (int i = 0; i < arr.Length; i++)
            {
                int start = i; int end = arr.Length - 1;
                while (start < end)
                {
                    int ret = Find(-1 * (arr[start] + arr[end]), arr, start, end);
                    if (ret != -1)
                    {
                        Console.WriteLine(arr[start] + "  " + arr[end] + "  " + arr[ret]);
                    }

                    start++;
                }
            }

            return false;
        }

        private static int Find(float num, float[] arr, int start, int end)
        {
            int result = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num && i != start && i != end)
                {
                    result = i;
                }
            }
            return result;
        }

        public static int BinarySearch(int[] arr, int start, int end, int no)
        {
            if (end < start)
                return -1;
            int mid = (start + end) / 2;  /*low + (high - low)/2;*/
            if (no == arr[mid])
                return mid;
            if (no > arr[mid])
                return BinarySearch(arr, (mid + 1), end, no);
            else
                return BinarySearch(arr, start, (mid - 1), no);
        }

        public static int FindSortedArrayRotation(int[] arr) //while loop working
        {
            int L = 0;
            int R = arr.Length - 1;

            while (arr[L] > arr[R])
            {
                int M = (L + R) / 2;
                if (arr[M] > arr[R])
                    L = M + 1;
                else
                    R = M;
            }
            return L;
        }

        public static int SearchRotated(int[] arr, int value) // 4,5,6,7,8,9,1,2,3    // 7,8,1,2,3,4,5,6
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                // Avoid overflow
                int middle = (left + right) / 2;
                if (arr[middle] == value) return middle;

                // the bottom half is sorted
                if (arr[middle] > arr[left])
                {
                    if (value >= arr[left] && value < arr[middle])
                    {
                        right = middle - 1;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
                // the upper half is sorted
                else
                {
                    if (value > arr[middle] && value <= arr[right])
                    {
                        left = middle + 1;
                    }
                    else
                    {
                        right = middle - 1;
                    }
                }
            }

            return -1;

        }

        public static int PivotBST(int[] arr, int no, int start, int end)
        {
            if (end < start)
                return -1;
            int pivot = FindPivot(arr, start, end);
            if (no > arr[0])
                return BinarySearch(arr, start, pivot, no);
            else
                return BinarySearch(arr, pivot + 1, end, no);
        }
        public static int FindPivot(int[] arr, int low, int high)
        {
            // base cases
            if (high < low) return -1;
            if (high == low) return low;

            int mid = (low + high) / 2;   /*low + (high - low)/2;*/
            if (mid < high && arr[mid] > arr[mid + 1])
                return mid;
            if (mid > low && arr[mid] < arr[mid - 1])
                return (mid - 1);
            if (arr[low] >= arr[mid])
                return FindPivot(arr, low, mid - 1);
            else
                return FindPivot(arr, mid + 1, high);
        }

        public static int FindPivot2(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (arr[left] > arr[right])
            {
                int mid = left + (left + right) / 2;
                if (arr[mid] > arr[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return left;
        }
    }
        
}