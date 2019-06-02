public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        List<IList<string>> result = new List<IList<string>>();
        if (n < 1)
        {
            return result;
        }
        bool[,] board = new bool[n, n];
        Solve(n, result, board,0, 0);
        return result;
    }
    void Solve(int n, List<IList<string>> result, bool[,] board, int chosen,int row)
    {
        if(chosen == n)
        {
            result.Add(createStr(board));
            return;
        }
        for(int col = 0; col < n; col++)
        {
            if(IsSafe(board, row, col))
            {
                //choose
                board[row, col] = true;
                chosen++;

                //explore
                Solve(n, result, board, chosen, row + 1);

                //un-choose
                board[row, col] = false;
                chosen--;
            }
        }
    }
    bool IsSafe(bool[,] board, int row, int col)
    {
        int rowSize = board.GetLength(0);
        int colSize = board.GetLength(1);
        //vertical up
        for(int i=row-1; i >= 0; i--)
        {
            if(board[i, col])
            {
                return false;
            }
        }
        int right = col;
        //+45 degree angle
        for(int i = row - 1; i >= 0; i--)
        {
            right++;
            if(right < colSize && board[i, right])
            {
                return false;
            }
        }
        int left = col;
        //-45 degree angle
        for(int i = row - 1; i >= 0; i--)
        {
            left--;
            if (left >= 0 && board[i, left])
            {
                return false;
            }
        }
        return true;
    }
    List<string> createStr(bool[,] board)
    {
        List<string> list = new List<string>();
        int rowSize = board.GetLength(0);
        int colSize = board.GetLength(1);
        for(int row = 0; row < rowSize; row++)
        {
            string str = "";
            for (int col = 0; col < colSize; col++)
            {
                if (board[row, col])
                {
                    str += "Q";
                }
                else
                {
                    str += ".";
                }
            }
            list.Add(str);
        }
        return list;
    }
}