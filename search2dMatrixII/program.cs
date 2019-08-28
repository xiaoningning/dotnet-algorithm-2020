public class Solution {
    public bool SearchMatrix(int[,] matrix, int target) {
        if (matrix.Length == 0) return false;
        int m = matrix.GetLength(0), n = matrix.GetLength(1);
        if (target < matrix[0,0] || target > matrix[m-1,n-1]) return false;
        int x = matrix.GetLength(0) - 1, y = 0;
        while (true) {
            if (matrix[x,y] > target) --x;
            else if (matrix[x,y] < target) ++y;
            else return true;
            if (x < 0 || y >= matrix.GetLength(1)) break;
        }
        return false;
    }
}
