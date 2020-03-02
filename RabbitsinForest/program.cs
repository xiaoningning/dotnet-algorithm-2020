public class Solution {
    public int NumRabbits(int[] answers) {
        int res = 0;
        var m = new Dictionary<int,int>();
        // answer can be 0
        foreach (var a in answers) {
            if (!m.ContainsKey(a + 1) || m[a+1] == 0) {
                res += a + 1; // others + itself
                m[a + 1] = a; // another a rabbits
            }
            else m[a+1]--;
        }
        return res;
    }
}
