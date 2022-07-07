/*
Smallest greater elements in whole array 
Easy Accuracy: 65.23% Submissions: 2307 Points: 2
Given an array A of N length. We need to calculate the next greater element for each element in a given array. If the next greater element is not available in a given array then we need to fill -10000000 at that index place.

Example 1:

Input : arr[] = {13, 6, 7, 12}
Output : _ 7 12 13 
Explanation:
Here, at index 0, 13 is the greatest value 
in given array and no other array element 
is greater from 13. So at index 0 we fill 
'-10000000'.

Example 2:

Input : arr[] = {6, 3, 9, 8, 10, 2, 1, 15, 7} 
Output :  7 6 10 9 15 3 2 _ 8
Explanation: Here, at index 7, 15 is the greatest
value in given array and no other array element is
greater from 15. So at index 7 we fill '-10000000'.
 

Your Task:
This is a function problem. The input is already taken care of by the driver code. You only need to complete the function greaterElement() that takes an array (arr), sizeOfArray (n), and return an array that displays the next greater element to element at that index. The driver code takes care of the printing.

Expected Time Complexity: O(N*LOG(N)).
Expected Auxiliary Space: O(N).

 

Constraints:
1 ≤ N ≤ 105
-106 ≤ Ai ≤ 106
*/

(function(){
    let inputArr = Array.of(12, 4, 77, 1, 8, 2)
    console.log("input:" + inputArr)
    GetNextGreaterElements(inputArr)
})();


function GetNextGreaterElements(inputArr){
    // 1. Sort the input array and store in seperate memory, 
    // Time: O(nLgn), Space: O(n)
    let sortedInputArr = [...inputArr]
    Sort(sortedInputArr)
    console.log("Sorted:" + sortedInputArr)

    // 2. to reduce the overall access time in step 3, 
    // store the next greatest item for each array in a map (sort of)
    // i.e, inputOutputMap[key] = value, index of this array is the key
    // Time: O(n), Space: O(n)
    let inputOutputMap = []
    for(let index = 0; index < sortedInputArr.length; index++){
        let key = sortedInputArr[index]
        let value = index + 1 < sortedInputArr.length ? sortedInputArr[index + 1] : null
        inputOutputMap[key] = value;        
    }
    
    // 3. Go through each item in inputArr and get its result
    // from the map updated in step 2
    // Time: O(n)
    let result = ''
    inputArr.forEach(function(item){
        result += inputOutputMap[item] + ' '
    })

    // Complexities (overall):
    // Time: O(n*Lg n), Space: O(n)
    console.log("Result:" + result)
}

function Sort(inputArr){
    MergeSort(inputArr, 0, inputArr.length - 1)
}

function MergeSort(inputArr, startIndex, endIndex){
    if(startIndex < endIndex){
        let midIndex = Math.trunc((startIndex + endIndex) / 2)
        MergeSort(inputArr, startIndex, midIndex)
        MergeSort(inputArr, midIndex + 1, endIndex)
        Merge(inputArr, startIndex, midIndex, endIndex)
    }
}

function Merge(inputArr, startIndex, midIndex, endIndex){
    let subArr1 = new Array(midIndex - startIndex + 1)
    let subArr2 = new Array(endIndex - (midIndex + 1) + 1)

    // 1. copy contents to new array 
    let index = 0
    for(let j = startIndex; j <= midIndex; j++){
        subArr1[index++] = inputArr[j]
    }
    index = 0
    for(let j = midIndex + 1; j <= endIndex; j++){
        subArr2[index++] = inputArr[j]
    }

    // 2. Sorted merge
    let arrIndex = startIndex
    let sa1Index = 0, sa2Index = 0
    while(sa1Index < subArr1.length && 
        sa2Index < subArr2.length && 
        arrIndex <= endIndex){
            if(subArr1[sa1Index] < subArr2[sa2Index]){
                inputArr[arrIndex++] = subArr1[sa1Index++]
            } else{
                inputArr[arrIndex++] = subArr2[sa2Index++]
            }
        }
    
    // 3. if there are any remaining items in one of the sub arrays
    // just put them in that order in inputArr
    while(sa1Index < subArr1.length){
        inputArr[arrIndex++] = subArr1[sa1Index++]
    }
    while(sa2Index < subArr2.length){
        inputArr[arrIndex++] = subArr2[sa2Index++]
    }
}