public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        List<int> res = new List<int>();
        if(matrix.GetLength(0) == 0 || matrix[0].GetLength(0) == 0) return res;
        int m = matrix.GetLength(0);
        int n = matrix[0].GetLength(0);
        int up = 0, down = m -1;
        int left = 0, right = n-1;
        while(true){
            for (int j = left; j <= right; j++) res.Add(matrix[up][j]);
            if (++up > down) break;
            for (int i = up; i <= down; i++) res.Add(matrix[i][right]);
            if (--right < left) break;
            for (int j = right; j >= left; j--) res.Add(matrix[down][j]);
            if (--down < up) break;
            for (int i = down; i >= up; i--) res.Add(matrix[i][left]);
            if (++left > right) break;
        }
        return res;
    }
}
