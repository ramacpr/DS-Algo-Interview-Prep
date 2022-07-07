/*
Adventure in a Maze 
Hard Accuracy: 46.36% Submissions: 1552 Points: 8
You have got a maze, which is a n*n Grid. Every cell of the maze contains these numbers 1, 2 or 3. 
If it contains 1 : means we can go Right from that cell only.
If it contains 2 : means we can go Down from that cell only.
If it contains 3 : means we can go Right and Down to both paths from that cell.
We cant go out of the maze at any time.
Initially, You are on the Top Left Corner of The maze(Entry). And, You need to go to the Bottom Right Corner of the Maze(Exit).
You need to find the total number of paths from Entry to Exit Point.
There may be many paths but you need to select that path which contains the maximum number of Adventure.
The Adventure on a path is calculated by taking the sum of all the cell values thatlies in the path.
 

Example 1:

Input: matrix = {{1,1,3,2,1},{3,2,2,1,2},
{1,3,3,1,3},{1,2,3,1,2},{1,1,1,3,1}}
Output: {4,18}
Explanation: There are total 4 Paths Available 
out of which The Max Adventure is 18. Total 
possible Adventures are 18,17,17,16. Of these 
18 is the maximum.
 

Your Task:
You don't need to read or print anything. Your task is to complete the function FindWays() which takes matrix as input parameter and returns a list containg total number of ways to reach at (n, n) modulo 109 + 7 and maximum number of Adventure.
 

Expected Time Complexity: O(n2)
Expected Space Complexity: O(n2)
 

Constraints:
1 <= n <= 100 
*/


let maxRowCount = 5, maxColCount = 5
let stack = new Array()
let matrix = [
    [1, 1, 3, 2, 1],
    [3, 2, 2, 1, 2],
    [1, 3, 3, 1, 3],
    [1, 2, 3, 1, 2],
    [1, 1, 1, 3, 1]
]
let sumMatrix = [
    [0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0]
]

console.log('Adventure in a maze')
console.log(FindPathCount())

function FindPathCount(){
    let numberOfPaths = 0
    stack.push([0,0])
    // the sum at first cell is its own value
    sumMatrix[0][0] = matrix[0][0]
    while(stack.length > 0){
        let cell = stack.pop()
        if(cell[0] == maxRowCount - 1 &&
            cell[1] == maxColCount - 1){
                numberOfPaths++;
        }
        let nextCells = GetNeighbourCell(cell[0], cell[1])
        for(let index in nextCells){
            let nextCell = nextCells[index]
            let cellSum = matrix[nextCell[0]][nextCell[1]]
            cellSum += sumMatrix[cell[0]][cell[1]]
            
            // we have reached our destination, 
            // only new sum value if and only if the 
            // value at sumMatrix[4][4] is lesser
            if(nextCell[0] == maxRowCount - 1 &&
                nextCell[1] == maxColCount - 1){
                    if(sumMatrix[nextCell[0]][nextCell[1]] < cellSum){
                        sumMatrix[nextCell[0]][nextCell[1]] = cellSum
                    }
                console.log('path sum: ' + cellSum)
            } else {
                sumMatrix[nextCell[0]][nextCell[1]] = cellSum
            }
            stack.push(nextCells[index])
        }
    }
    return [numberOfPaths, sumMatrix[maxRowCount - 1][maxColCount - 1]]
}

function IsValidIndex(row, col){
    if(row >= maxRowCount ||
        row < 0 || 
        col >= maxColCount ||
        col < 0){
        return false
    } else {
        return true
    }
}

// returns false in case of error 
// null in case of end of path 
// array of next cell row,col if path exists
function GetNeighbourCell(row, col){
    if(!IsValidIndex(row, col)){
        return false
    }

    let result = new Array()
    let cellValue = matrix[row][col]
    switch(cellValue){
        case 1: // right move only 
        if(IsValidIndex(row, col + 1)){
            result.push([row, col + 1])
        } else {
            result = null // reached the end of path
        }
        break
        case 2: // down move only 
        if(IsValidIndex(row + 1, col)){
            result.push([row + 1, col])
        } else {
            result = null // reached end of path
        }
        break 
        case 3: // right and down move
        if(IsValidIndex(row, col + 1)){
            result.push([row, col + 1])
        }
        if(IsValidIndex(row + 1, col)){
            result.push([row + 1, col])
        }
        if(result.length == 0){
            result = null // end of path reached
        }
        break
        default: // invalid data in matrix, error!
        return false
    }
    return result
}