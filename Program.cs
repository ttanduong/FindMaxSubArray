using System;
using System.Diagnostics;
using System.Linq;

namespace FindMaximumSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = CreateArrayForTest(100);

            Stopwatch st = new Stopwatch();

            FindMaxSubarray SubMaxArray = new FindMaxSubarray();

            long[] A = new long[50];
            long[] B = new long[50];
            long[] C = new long[50];

            for (int i = 0; i < 50; i++)
            {
                st = Stopwatch.StartNew();
                int[] result = SubMaxArray.DivideConquerFindMaxSubArray(arr, 0, arr.Length - 1);
                st.Stop();
                A[i] = st.ElapsedMilliseconds;             

                st = Stopwatch.StartNew();
                int[] result1 = SubMaxArray.BruteForceFindMaxSubArray(arr, 0, arr.Length - 1);
                B[i] = st.ElapsedMilliseconds;

                st = Stopwatch.StartNew();
                int[] result2 = SubMaxArray.LinearFindMaxSubArray(arr);
                C[i] = st.ElapsedMilliseconds;
            }
            Console.WriteLine("DiveConquer time: {0}", A.Average());
            Console.WriteLine("BruteForce time: {0}", B.Average());
            Console.WriteLine("Linear time: {0}", C.Average());

            int[] result3 = SubMaxArray.LinearFindMaxSubArray(arr);
            Console.WriteLine();           
            for (int i = result3[0]; i <= result3[1]; i++)
                Console.Write("{0} ", arr[i]);            
        }

        /* CreateArrayForTest(int size)
         * Description: Create an array
         * Param1 (int size): Size of array need to be created         
         * Return (int[]): an array
         */
        public static int[] CreateArrayForTest(int size)
        {
            int Min = -100;
            int Max = 100;

            Random randNum = new Random();
            return Enumerable.Repeat(0, size).Select(i => randNum.Next(Min, Max)).ToArray();
        }
    }
}
