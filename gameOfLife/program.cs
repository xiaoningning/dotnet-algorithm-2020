public class Solution {
    public void GameOfLife(int[][] board) {
        int m = board.Length, n = m > 0 ? board[0].Length : 0;
        int[] dx = new int[] {-1, -1, -1, 0, 1, 1, 1, 0};
        int[] dy = new int[] {-1, 0, 1, 1, 1, 0, -1, -1};
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                int cnt = 0;
                for (int k = 0; k < 8; ++k) {
                    int x = i + dx[k], y = j + dy[k];
                    // 0 dead,  2 live but overpopulation
                    // 1 live,  3 dead but reproduction
                    if (x >= 0 && x < m && y >= 0 && y < n 
                        && (board[x][y] == 1 || board[x][y] == 2)) ++cnt;
                }
                if (board[i][j] != 0 && (cnt < 2 || cnt > 3)) board[i][j] = 2;
                else if (board[i][j] == 0 && cnt == 3) board[i][j] = 3;
            }
        }
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                board[i][j] %= 2; // 0/2 dead; 1/3 live
            }
        }
    }
}
