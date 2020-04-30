using System;
using System.Collections.Generic;
using System.Text;

namespace FindMaximumSubarray
{
    class FindMaxSubarray
    {
        /* FindMaxSubArray(int[] A, int low, int high)
         * Description: Find the maximum contiguous subarray of A[low...high]
         *              Method: Divide and conquer
         * Param1 (int[] A): Array which have some nagative integer elements
         * Param2 (int low): low index of A[]	
         * Param3 (int hight): high index of A[]
         * Return (int[3]): {low index, high index, sum} of the maximum contiguous subarray
         */
        public int[] FindMaxSubArray(int[] A, int low, int high)
        {
            //In case A[] has one element:
            if (high == low) return new int[] { low, high, A[low] };

            int mid = (high + low) / 2;

            //Find the maximum subarray of left part:
            int[] leftCheck = FindMaxSubArray(A, low, mid);

            //Find the maximum subarray of right part:
            int[] rightCheck = FindMaxSubArray(A, mid + 1, high);

            //Find the maximum crossing subarray of left part:
            int[] crossCheck = FindMaxCrossingSubArray(A, low, mid, high);

            //Choose the maximum subarray:
            if ((leftCheck[2] >= rightCheck[2]) && (leftCheck[2] >= crossCheck[2]))
                return leftCheck;
            else if ((rightCheck[2] >= leftCheck[2]) && (rightCheck[2] >= crossCheck[2]))
                return rightCheck;
            else return crossCheck;
        }

        /* FindMaxCrossingSubArray(int[] A, int low, int mid, int high)
         * Description: Find the maximum crossing subarray F[i..j] of A[low...high]
         *              where: low <= i <= mid < j <= high
         * Param1 (int[] A): Array which have some nagative integer elements
         * Param2 (int low): low index of A[]	
         * Param3 (int mid): middle index of A[]
         * Param4 (int hight): high index of A[]
         * Return (int[3]): {low index, high index, sum} of the maximum crossing contiguous subarray
         */
        public int[] FindMaxCrossingSubArray(int[] A, int low, int mid, int high)
        {
            int leftSum = int.MinValue;
            int rightSum = int.MinValue;

            
            
            int leftIndex = mid;      
            int rightIndex = mid + 1; 
            int sum = 0;

            //Start from mid point and find the left part of the maximum subarray
            for (int i = mid; i >= 0; i--)
            {
                sum += A[i];

                if (sum >= leftSum) 
                {
                    leftSum = sum;
                    leftIndex = i;
                }
            }


            sum = 0;
            //Start from mid point + 1 and find the right part of the maximum subarray
            for (int i = mid + 1; i <= high; i++)
            {
                sum += A[i];

                if (sum >= rightSum)
                {
                    rightSum = sum;
                    rightIndex = i;
                }
            }

            return new int[] { leftIndex, rightIndex, leftSum + rightSum };
        }

        /* BruteForceFindMaxSubArray(int[] A, int low, int high)
         * Description: Find the maximum contiguous subarray of A[low...high]
         *              Method: Brute Force
         * Param1 (int[] A): Array which have some nagative integer elements
         * Param2 (int low): low index of A[]	
         * Param3 (int hight): high index of A[]
         * Return (int[2]): {low index, high index} of the maximum contiguous subarray
         */
        public int[] BruteForceFindMaxSubArray(int[] A, int low, int high)
        {
            int maxSum = int.MinValue;
            int lowIndex = 0;
            int highIndex = 0;

            for (int i = low; i <= high; i++)
            {
                int sum = 0;

                for (int j = i; j <= high; j++)
                {
                    sum += A[j];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        lowIndex = i;
                        highIndex = j;
                    }
                }
            }

            return new int[] { lowIndex, highIndex, maxSum };
        }
    }
}
