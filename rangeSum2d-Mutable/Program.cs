public class NumMatrix {
    int[,] colSum;
    int[,] mat;
    public NumMatrix(int[,] matrix) {
        mat = matrix;
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        colSum = new int[n+1,m];
        for (int i = 1; i < n + 1; ++i) {
            for (int j = 0; j < m; ++j) {
                colSum[i,j] = colSum[i - 1,j] + matrix[i - 1,j];
            }
        }
    }
    
    public void Update(int row, int col, int val) {
        for (int i = row + 1; i < n + 1; ++i) {
            colSum[i,col] += val - mat[row,col];
        }
        mat[row,col] = val;
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        int res = 0;
        for (int j = col1; j <= col2; ++j) {
            res += colSum[row2 + 1,j] - colSum[row1,j];
        } 
        return res;
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * obj.Update(row,col,val);
 * int param_2 = obj.SumRegion(row1,col1,row2,col2);
 */
