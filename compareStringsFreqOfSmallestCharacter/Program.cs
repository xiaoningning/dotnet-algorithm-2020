public class Solution {
    public int[] NumSmallerByFrequency(string[] queries, string[] words) {
        int [] frq = new int[11];
        foreach (string w in words){
            int cnt = GetCnt(w);
            frq[cnt]++;
        }
        int sum = 0;
        for(int i=0; i< frq.Length; i++){
            sum += frq[i];
            frq[i] = sum;
        }
        int [] res = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++){
            int cnt = GetCnt(queries[i]);
            res[i] = frq[frq.Length -1] - frq[cnt];
        }
        return res;
    }
    int GetCnt(string s) {
        int[] m = new int[26];
        foreach(var c in s) m[c-'a']++;
        for (int i = 0; i < 26; i++)
            if (m[i] != 0) return m[i];
        return 0;
    }
}
