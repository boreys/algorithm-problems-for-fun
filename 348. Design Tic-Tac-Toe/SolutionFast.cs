public class TicTacToe {

    int[,] board;
    int size;
    Dictionary<int,int[]> scoreRow;
    Dictionary<int,int[]> scoreCol;
    public TicTacToe(int n) {
        size = n;
        board = new int[n,n];
        scoreRow = new Dictionary<int,int[]>();
        scoreCol = new Dictionary<int,int[]>();
    }
    
    /** Player {player} makes a move at ({row}, {col}).
        @param row The row of the board.
        @param col The column of the board.
        @param player The player, can be either 1 or 2.
        @return The current winning condition, can be either:
                0: No one wins.
                1: Player 1 wins.
                2: Player 2 wins. */
    public int Move(int row, int col, int player) {
        if(row < 0 || col < 0 || row >= size || col >= size){
            return 0;
        }
        board[row,col] = player;
        
        //update score for both col and row
        if(!scoreRow.ContainsKey(player)){
            scoreRow[player] = new int[size];
        }
        if(!scoreCol.ContainsKey(player)){
            scoreCol[player] = new int[size];
        }
        int[] scoreX = scoreRow[player];
        scoreX[row] = scoreX[row] + 1;
        int[] scoreY = scoreCol[player];
        scoreY[col] = scoreY[col] + 1;
        if(scoreX[row] == size || scoreY[col] == size){
            return player;
        }
        if(CheckDiagonal(player)){
            return player;
        }
        return 0;
    }
    bool CheckDiagonal(int player){
        int count = 0;
        int stop = board.GetLength(0);
        for(int i=0;i<stop;i++){
            if(board[i,i] == player){
                count++;
            }else{
                break;
            }
        }
        if(count == size){
            return true;
        }
        count = 0;
        int n = size - 1;
        for(int i=0;i<stop;i++){
            if(board[i,n] == player){
                count++;
            }else{
                break;
            }
            n--;
        }
        return count == size;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */