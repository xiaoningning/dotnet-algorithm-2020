public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        int m = matrix.Length;
        if ( m == 0 || matrix[0].Length == 0) return 0;
        int n = matrix[0].Length, res = 0;
        int[] height = new int[n], left = new int[n], right = new int[n];
        Array.Fill(right, n);
        for(int i = 0; i < m; i++) {
            int curLeft = 0, curRight = n;
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] == '1') {
                    height[j]++;
                    left[j] = Math.Max(left[j],curLeft);
                }
                else {
                    height[j] = 0;
                    left[j] = 0;
                    curLeft = j + 1;
                }
            }
            for (int j = n - 1; j >= 0; j--) {
                if (matrix[i][j] == '1') right[j] = Math.Min(right[j], curRight); 
                else {
                    curRight = j;
                    right[j] = n;
                }
                res = Math.Max(res, (right[j] - left[j]) * height[j]);
            }
        }
        return res;
    }
    public int MaximalRectangle1(char[,] matrix) {
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);
        int[] heights = new int[n+1];
        int res = 0;
        for(int i = 0; i < m; i++){
            Stack<int> st = new Stack<int>();
            for(int j = 0; j <= n; j++){
                heights[j] = j < n && matrix[i,j] == '1' ? heights[j] + 1 : 0;    
                while(st.Count != 0 && heights[st.Peek()] >= heights[j]){
                    int cur = st.Pop();
                    res = Math.Max(res, heights[cur] * (st.Count == 0 ? j : j - st.Peek() - 1));
                }
                st.Push(j);
            }            
        }
        return res;
    }
}
