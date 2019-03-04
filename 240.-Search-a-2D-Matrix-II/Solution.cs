public class Solution {
    //runtime: O(logn), space complexity: O(1)
    public bool SearchMatrix(int[,] matrix, int target) {
        if(matrix == null || matrix.GetLength(0) < 1 || matrix.GetLength(1) < 1){
            return false;
        }
        int lastCol = matrix.GetLength(1), lastRow = matrix.GetLength(0);
        if(target < matrix[0,0] || target > matrix[lastRow-1,lastCol-1]){
            return false;
        }
        int nextRow = 0, nextCol = 0;
        while(nextRow < lastRow && nextCol < lastCol){

            if(FindInRow(matrix, nextRow, nextCol, target)){
                return true;
            }
            if(FindInCol(matrix, nextRow, nextCol, target)){
                return true;
            }
            nextRow++;
            nextCol++;
        }
        return false;
    }
    bool FindInCol(int[,] matrix, int startRow, int startCol, int target){
        int start = startRow;
        int stop = matrix.GetLength(0);
        int mid, val;
        while(start < stop){
            mid = (stop - start)/2 + start;
            val = matrix[mid, startCol];
            if(target == val){
                return true;
            }
            if(target < val){
                stop = mid;
            }else{
                start = mid + 1;
            }
        }
        return false;
    }
    bool FindInRow(int[,] matrix, int startRow, int startCol, int target){
        int start = startCol;
        int stop = matrix.GetLength(1);
        int mid, val;
        while(start < stop){
            mid = (stop - start) / 2 + start;
            val = matrix[startRow, mid];
            if(val == target){
                return true;
            }
            if(target < val){
                stop = mid;
            }else{
                start = mid + 1;
            }
        }
        return false;
    }
}