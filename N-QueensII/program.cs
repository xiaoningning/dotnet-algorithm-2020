public class Solution {
    int res = 0;
    public int TotalNQueens(int n) {
        var queens = new string[n];
        for (int i = 0; i < n; i++) queens[i] = new string('.', n);
        helper(0, queens);
        return res;
    }
    void helper(int curRow, string[] queens) {
        int n = queens.Length;
        if (curRow == n) {
            res++;
            return;
        }
        for (int i = 0; i < n; i++) {
            if (isValid(queens, curRow, i)) {
                var t = queens[curRow].ToCharArray();
                t[i] = 'Q';
                queens[curRow] = new string(t);
                helper(curRow + 1, queens);
                t[i] = '.';
                queens[curRow] = new string(t);
            }
        }
    }
    bool isValid(string[] queens, int row, int col) {
        for (int i = 0; i < row; i++) if (queens[i][col] == 'Q') return false;
        for (int i = row -1, j = col - 1; i >= 0 && j >= 0; i--,j--) if (queens[i][j] == 'Q') return false;
        for (int i = row -1, j = col + 1; i >= 0 && j < queens.Length; i--,j++) if (queens[i][j] == 'Q') return false;
        return true;
    }
}
