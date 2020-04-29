using System;

namespace FindMaximumSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };

            FindMaxSubarray SubMaxArray = new FindMaxSubarray();

            int[] result = SubMaxArray.FindMaxSubArray(arr, 0, arr.Length - 1);

            for (int i = result[0]; i <= result[1]; i++)
                Console.Write("{0} ", arr[i]);
        }
    }
}
