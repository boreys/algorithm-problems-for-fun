public class Solution {
    public IList<string> FindWords(char[][] board, string[] words) {
        List<string> result = new List<string>();
        if(board == null || board.Length < 1 || words == null || words.Length < 1){
            return result;
        }
        int rowSize = board.Length;
        int colSize = board[0].Length;
        for(int i=0;i<rowSize;i++){
            for(int j = 0;j<colSize;j++){
                char ch = board[i][j];
                for(int k=0;k<words.Length;k++){
                    if(words[k] != "" && ch == words[k][0] && Search(board, words[k], i, j, 0)){
                        result.Add(words[k]);
                        words[k] = "";
                    }
                }
            }
        }
        return result;
    }
    bool Search(char[][] board, string word, int row, int col, int pos){
        if(pos == word.Length){
            return true;
        }
        if(row < 0 || col < 0 || row == board.Length || 
           col == board[0].Length || board[row][col] != word[pos]){
            return false;
        }
        board[row][col] ^= (char)256;
        bool success = Search(board, word, row, col + 1, pos + 1) ||
            Search(board, word, row, col - 1, pos + 1) || 
            Search(board, word, row + 1, col, pos + 1) ||
            Search(board, word, row - 1, col, pos +1);
        board[row][col] ^= (char)256;
        return success;
    }
}