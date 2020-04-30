# FindMaxSubArray

### Find the maximum contiguous subarray of an input array

### Description 

Using the **divide-and-conquer method** to solve the problem

### Pseudocode

    FIND-MAX-CROSSING-SUBARRAY(A, l, m, h)
    
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
