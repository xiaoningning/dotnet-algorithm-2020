public class Solution {
    public string RemoveDuplicateLetters(string s) {
        int[] cnt = new int[256], visited = new int[256];
        var res = "0";
        foreach (var a in s) cnt[a]++;
        foreach (var a in s) {
            cnt[a]--;
            if (visited[a] > 0) continue;
            while (a < res.Last() && cnt[res.Last()] > 0) {
                visited[res.Last()] = 0; // will use next one
                res = res.Remove(res.Length - 1, 1);
            }
            res += a;
            visited[a] = 1;
        }
        return res.Substring(1);
    }
}
