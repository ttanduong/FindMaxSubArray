# FindMaxSubArray

### Find the maximum contiguous subarray of an input array

## Description 

Using the **divide-and-conquer method** to solve the problem:

Suppose that the input array is A[low..high]:

* Divide the input array into 2 subarrays of as equal size as posible (find midpoint).

* The max contiguous subarray A[i..j] must lie in one of following place:
  
  * Entirely in the subarray A[low..mid], so that low <= i <= j <= mid
  
  * Entirely in the subarray A[mid+1..high], so that mid < i <= j <= high
  
  * Crossing the midpoint, so that low <= i <= mid < j <= high

* So find the maximum subarrays of A[low..mid] and A[mid+1..high] recursively.

* Find the maximum subarray that cross the midpoint.

* Take a subarray with the largest sum of three.

## Pseudocode

   **FIND-MAX-CROSSING-SUBARRAY(A, l, m, h)**
    
    leftSum = -INFINITY
    
    rightSum = -INFINITY
    
    leftIndex = m
    
    sum = 0
    
    for i = m downto l
    
       sum = sum + A[i]
       
       if sum > leftSum
       
          leftSum = sum
          
          leftIndex = i
          
    sum = 0
    
    for i = m + 1 to h
    
       sum = sum + A[i]
       
       if sum > rightSum
       
          rightSum = sum
          
          rightIndex = i
          
    return (leftIndex, rightIndex, leftSum + rightSum)

   **FIND-MAX-SUBARRAY(A, l, h)**
    
    if l = h 
    
       return (l, h, A[l])
    
    m = (l + h) / 2
    
    (leftLow, leftHigh, leftSum) = FIND-MAX-SUBARRAY(A, l, m)
    
    (rightLow, rightHigh, rightSum) = FIND-MAX-SUBARRAY(A, m + 1, h)
    
    (crossLow, crossHigh, crossSum) = FIND-MAX-CROSSING-SUBARRAY(A, l, m, h)
    
    if leftSum >= rightSum AND leftSum >= crossSum
       
       return (leftLow, leftHigh, leftSum)
       
    elseif rightSum >= leftSum AND rightSum >= crossSum
       
       return (rightLow, rightHigh, rightSum)
       
    else
       
       return (crossLow, crossHigh, crossSum)
