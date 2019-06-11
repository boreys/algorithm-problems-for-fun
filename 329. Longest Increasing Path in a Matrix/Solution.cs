public class Solution {
    public int LongestIncreasingPath(int[][] matrix) {
        if(matrix == null || matrix.Length < 1){
            return 0;
        }
        int rowSize = matrix.Length;
        int colSize = matrix[0].Length;
        int[,] cache = new int[rowSize,colSize];
        
        int max = 1;
        for(int row = 0;row<rowSize;row++){
            for(int col = 0;col<colSize;col++){
                int count = FindPath(matrix, row, col, matrix[row][col]-1, cache);
                max = Math.Max(max, count);
            }
        }
        return max;
    }
    
    int FindPath(int[][] matrix, int row, int col, int prevVal, int[,] cache)
    {
        if (row < 0 || col < 0 || row == matrix.Length ||
           col == matrix[0].Length || prevVal >= matrix[row][col])
        {
            return 0;
        }
        int cacheVal = cache[row,col];
        if(cacheVal > 0){
            return cacheVal;
        }
        int currentVal = matrix[row][col];

        int rightCount = FindPath(matrix, row, col + 1, currentVal, cache) + 1;
        int leftCount = FindPath(matrix, row, col - 1, currentVal, cache) + 1;
        int max = Math.Max(rightCount, leftCount);

        int topCount = FindPath(matrix, row - 1, col, currentVal, cache) + 1;
        max = Math.Max(max, topCount);

        int bottomCount = FindPath(matrix, row + 1, col, currentVal, cache) + 1;
        max = Math.Max(max, bottomCount);
        cache[row,col] = max;
        return max;
    }
}