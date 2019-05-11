public class Solution {
    public bool Exist(char[][] board, string word) {
        if(board == null || board.Length < 1 || string.IsNullOrEmpty(word)){
            return false;
        }
        int rowSize = board.Length;
        int colSize = board[0].Length;
        bool[,] visited = new bool[rowSize,colSize];
        for(int i=0;i<rowSize;i++){
            for(int j=0;j<colSize;j++){
                if(board[i][j] == word[0]){
                    visited = new bool[rowSize, colSize];
                    if(Search(board, word, visited, i, j, 0)){
                        return true;
                    }
                }
            }
        }
        return false;
    }
    bool Search(char[][] board, string word, bool[,] visited, int row, int col, int pos){
        if(pos == word.Length){
            return true;
        }
        if(row <0 || col < 0 || row == visited.GetLength(0) || 
           col == visited.GetLength(1) || visited[row,col] == true || 
           board[row][col] != word[pos]){
            return false;
        }
        visited[row,col] = true;
        bool success = Search(board, word, visited, row, col + 1, pos + 1) ||
            Search(board, word, visited, row, col - 1, pos + 1) || 
            Search(board, word, visited, row + 1, col, pos + 1) ||
            Search(board, word, visited, row - 1, col, pos + 1);
        visited[row,col] = false;
        return success;
    }
}