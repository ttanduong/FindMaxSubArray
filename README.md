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

   **DIVIDECONQUER-FIND-MAX-SUBARRAY(A, low, high)**
    
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

## Method 3: Linear

### Description

Loop for each element of the input array:

* Update the value of the current sum whenever encouter a new element.

* If the current sum is bigger than the max sum, update the max subarray contains that new element.

* If the current sum is negative, reset current sum and mark the next element as the start of a new possible max subarray.

### Pseudocode

   **LINEAR-FIND-MAX-SUBARRAY(A)**
   
    currentSum = 0
    
    low = 0
    
    high = 0
    
    maxSum = A[0]
    
    i = 1
    
    for j = 1 to A.Length
    
       currentSum = currentSum + A[j]
       
       if currentSum > maxSum
       
          maxSum = currentSum
          
          low = i
          
          high = j
          
       if currentSum < 0
          
          currentSum = 0
          
          i = j + 1
          
    return (low, high, maxSum)
    
### Time Complexity: O(n) 

## Method 4: Mix Brute force and Divide-and-Conquer methods

### Description

CROSS_THRESHOLD gives the crossover point at which the recursive algorithm beats the brute-force algorithm.

### Pseudocode

   **MIX-FIND-MAX-SUBARRAY(A, low, high)**
   
    CONST CROSS_THRESHOLD = 37
   
    if (high - low) < CROSS_THRESHOLD
    
       return BRUTEFORCE-FIND-MAX-SUBARRAY(A, low, high)
       
    else
       
       mid = (low + high) / 2
       
       (leftLow, leftHigh, leftSum) = MIX-FIND-MAX-SUBARRAY(A, low, mid)
    
       (rightLow, rightHigh, rightSum) = MIX-FIND-MAX-SUBARRAY(A, mid + 1, high)

       (crossLow, crossHigh, crossSum) = FIND-MAX-CROSSING-SUBARRAY(A, low, mid, high)

       if leftSum >= rightSum AND leftSum >= crossSum

          return (leftLow, leftHigh, leftSum)

       elseif rightSum >= leftSum AND rightSum >= crossSum

          return (rightLow, rightHigh, rightSum)

       else

          return (crossLow, crossHigh, crossSum)
