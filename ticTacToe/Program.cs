public class TicTacToe {
    int N;
    int[] rows;
    int[] cols;
    int diag;
    int rdiag;
    /** Initialize your data structure here. */
    public TicTacToe(int n) {
        N = n;
        rows = new int[N];
		cols = new int[N];
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
        int add = (player == 1) ? 1 : -1;
        rows[row] += add; 
        cols[col] += add;
        diag += (row == col ? add : 0);
        rdiag += (row == N - col - 1 ? add : 0);
        return (Math.Abs(rows[row]) == N 
                || Math.Abs(cols[col]) == N 
                || Math.Abs(diag) == N 
                || Math.Abs(rdiag) == N) ? player : 0;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */
