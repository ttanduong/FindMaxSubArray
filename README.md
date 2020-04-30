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

    FIND-MAX-SUBARRAY(A, l, h)
    
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
