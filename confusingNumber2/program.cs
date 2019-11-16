public class Solution {
    int[] v = new int[] {0,1,6,8,9};
    int cnt = 0;
    Dictionary<char, char> m = new Dictionary<char, char>();
    
    public int ConfusingNumberII(int N) {
        m.Add('0','0');
        m.Add('1','1');
        m.Add('8','8');
        m.Add('6','9');
        m.Add('9','6');
        return Dfs(0,0,1, N);
    }
    int Dfs(int num, int rotation, int digit, int N){
        int res = 0;
        if (num != rotation) res++;    
        // add one more digit
        foreach (int d in v){
            if (d == 0 && num == 0) continue;
            if (num * 10 + d <= N)
                res += Dfs(num*10 + d, m[(char)(d + '0')]*digit + rotation, digit*10, N);   
        }
        return res;
    }
            
    //TLE
    public int ConfusingNumberII1(int N) {
        m.Add('0','0');
        m.Add('1','1');
        m.Add('8','8');
        m.Add('6','9');
        m.Add('9','6');
        foreach (int x in new int[]{1, 6, 8, 9}) Dfs(x, N);
        return cnt;   
    }
    void Dfs(int x, int N) {
        if (x > N) return;
        if (ConfusingNumber(x)) cnt++;
        foreach (int y in v) { 
            Dfs(x * 10 + y, N);
        }
    }
    bool ConfusingNumber(int N) {
        string num = N.ToString(), res = "";
        foreach (var c in num) {
            if (!m.ContainsKey(c)) return false;
            res = m[c] + res;
        }
        return res != num;
    }
}
