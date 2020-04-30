# FindMaxSubArray

### Find the maximum contiguous subarray of an input array

## Method 1: Devide and conquer

### Description 

Suppose that the input array is A[low..high]:

* Divide the input array into 2 subarrays of as equal size as posible (find midpoint).

* The max contiguous subarray A[i..j] must lie in one of following place:
  
  * Entirely in the subarray A[low..mid], so that low <= i <= j <= mid
  
  * Entirely in the subarray A[mid+1..high], so that mid < i <= j <= high
  
  * Crossing the midpoint, so that low <= i <= mid < j <= high

* So find the maximum subarrays of A[low..mid] and A[mid+1..high] recursively.

* Find the maximum subarray that cross the midpoint.

* Take a subarray with the largest sum of three.

### Pseudocode

   **FIND-MAX-CROSSING-SUBARRAY(A, low, mid, high)**
    
    leftSum = -INFINITY
    
    rightSum = -INFINITY
    
    leftIndex = mid
    
    sum = 0
    
    for i = mid downto l
    
       sum = sum + A[i]
       
       if sum > leftSum
       
          leftSum = sum
          
          leftIndex = i
          
    sum = 0
    
    for i = mid + 1 to high
    
       sum = sum + A[i]
       
       if sum > rightSum
       
          rightSum = sum
          
          rightIndex = i
          
    return (leftIndex, rightIndex, leftSum + rightSum)

   **FIND-MAX-SUBARRAY(A, low, high)**
    
    if low = high 
    
       return (low, high, A[low])
    
    mid = (low + high) / 2
    
    (leftLow, leftHigh, leftSum) = FIND-MAX-SUBARRAY(A, low, mid)
    
    (rightLow, rightHigh, rightSum) = FIND-MAX-SUBARRAY(A, mid + 1, high)
    
    (crossLow, crossHigh, crossSum) = FIND-MAX-CROSSING-SUBARRAY(A, low, mid, high)
    
    if leftSum >= rightSum AND leftSum >= crossSum
       
       return (leftLow, leftHigh, leftSum)
       
    elseif rightSum >= leftSum AND rightSum >= crossSum
       
       return (rightLow, rightHigh, rightSum)
       
    else
       
       return (crossLow, crossHigh, crossSum)
       
### Time Complexity: O(n*lgn) 

## Method 2: Brute force

### Description

### Pseudocode

   **BRUTEFORCE-FIND-MAX-SUBARRAY(A, low, high)**
   
    maxSum = -INFINITY
    
    lowIndex = 0
    
    highIndex = 0

    for i = low to high
    
       sum = 0
       
       for j = i to high
       
          sum = sum + A[j]
          
          if sum > maxSum
             
             maxSum = sum
             
             lowIndex = i
             
             highIndex = j
             
    return (lowIndex, highIndex)
    
### Time Complexity: O(n^2)
