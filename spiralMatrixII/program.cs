public class Solution {
    public int[][] GenerateMatrix(int n) {
        var res = new int[n][];
        for (int i = 0; i < n; i++) res[i] = new int[n];
        int up = 0, down = n - 1, left = 0, right = n - 1, val = 1;;
        while (true) {
            for (int j = left; j <= right; j++) res[up][j] = val++;
            if (++up > down) break;
            for (int i = up; i <= down; i++) res[i][right] = val++;
            if (--right < left) break;
            for (int j = right; j >= left; j--) res[down][j] = val++;
            if (--down < up) break;
            for (int i = down; i >= up; i--) res[i][left] = val++;
            if (++left > right) break;
        }
        return res;
    }
}
