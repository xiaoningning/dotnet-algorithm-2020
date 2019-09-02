public class Solution {
    public bool ValidTicTacToe(string[] board) {
        bool xwin = false, owin = false;
        int[] rows = new int[3];
        int[] cols = new int[3];
        int diag = 0;
        int antidiag = 0;
        // 0 ->x, 1->o
        int turns = 0; 
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                if (board[i][j] == 'X') {
                    turns++; rows[i]++; cols[j]++;
                    if (i == j) diag++;
                    if (i + j == 2) antidiag++;
                } else if (board[i][j] == 'O') {
                    turns--; rows[i]--; cols[j]--;
                    if (i == j) diag--;
                    if (i + j == 2) antidiag--;
                }
            }
        }
        xwin = rows[0] == 3 || rows[1] == 3 || rows[2] == 3 || 
               cols[0] == 3 || cols[1] == 3 || cols[2] == 3 || 
               diag == 3 || antidiag == 3;
        owin = rows[0] == -3 || rows[1] == -3 || rows[2] == -3 || 
               cols[0] == -3 || cols[1] == -3 || cols[2] == -3 || 
               diag == -3 || antidiag == -3;
        // xwin turns should be o, owin turns should be x
        if (xwin && turns == 0 || owin && turns == 1) return false;
        // if turns is not o or x, then in valid
        // if turn is valid, then only one of x or o wins
        return (turns == 0 || turns == 1) && (!xwin || !owin);
    }
}
