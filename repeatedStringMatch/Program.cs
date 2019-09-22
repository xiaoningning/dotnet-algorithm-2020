public class Solution {
    public int RepeatedStringMatch(string A, string B) {
        int m = A.Length, n = B.Length;
        for (int i = 0; i < m; i++) {
            int j = 0;
            while (j < n && A[(i+j) % m] == B[j]) j++;
            // res: i + (j - 1) b/c j == n
            if (j == n) return ((i + j - 1) / m) + 1;
        }
        return -1;
    }
    public int RepeatedStringMatch1(string A, string B) { 
        string str = A;
        for (int rep = 1; rep <= B.Length / A.Length + 2; rep++, str += A)
            if (str.IndexOf(B) != -1) return rep;
        return -1;
    }
}
