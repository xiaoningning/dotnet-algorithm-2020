public class Solution {
    public int CountBattleships(char[][] board) {
        if (!board.Any() || !board[0].Any()) return 0;
        int res = 0, m = board.Length, n = board[0].Length;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                // check vertical or horizaontal cell
                if (board[i][j] == '.' 
                    || (i > 0 && board[i - 1][j] == 'X') 
                    || (j > 0 && board[i][j - 1] == 'X')) continue;
                ++res;
            }
        }
        return res;
    }
}
