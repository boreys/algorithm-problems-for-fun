public class TicTacToe
{
    int[,] board;
    /** Initialize your data structure here. */
    public TicTacToe(int n)
    {
        board = new int[n, n];
    }

    /** Player {player} makes a move at ({row}, {col}).
        @param row The row of the board.
        @param col The column of the board.
        @param player The player, can be either 1 or 2.
        @return The current winning condition, can be either:
                0: No one wins.
                1: Player 1 wins.
                2: Player 2 wins. */
    public int Move(int row, int col, int player)
    {
        int current = board[row, col];
        if (current != 0 || (player != 1 && player != 2)){
            return 0;
        }
        board[row, col] = player;
        if (Winning(row, col, player))
        {
            return player;
        }
        return 0;
    }
    bool Winning(int row, int col, int player){
        bool result = true;
        if(board[0,0] == player){
            result = true;
            for (int i = 0; i < board.GetLength(0);i++){
                if(board[i,i] != player){
                    result = false;
                    break;
                }
            }
            if(result){
                return true;
            }
        }
        if(board[board.GetLength(0) - 1, 0] == player){
            result = true;
            int k = 0;
            for (int i = board.GetLength(0) - 1; i >= 0;i--){
                if(board[i,k++] != player){
                    result = false;
                    break;
                }
            }
            if (result)
            {
                return true;
            }
        }
        //from left to right
        result = true;
        for (int i = 0; i < board.GetLength(0);i++){
            if(board[row, i] != player){
                result = false;
                break;
            }
        }
        if(result){
            return true;
        }
        //from top to bottom
        result = true;
        for (int i = 0; i < board.GetLength(1); i++)
        {
            if (board[i, col] != player)
            {
                result = false;
                break;
            }
        }
        return result;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */