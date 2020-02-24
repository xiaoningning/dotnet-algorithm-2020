public class Solution {
    public string ShortestCommonSupersequence(string str1, string str2) {
        int i = 0, j = 0;
        var res = "";
        foreach (var c in lcs(str1, str2)) {
            while (str1[i] != c) res += str1[i++];
            while (str2[j] != c) res += str2[j++];
            res += c; i++; j++;
        }
        // Common Supersequence
        return res + str1.Substring(i) + str2.Substring(j);
    }
    // longest common subsequence
    string lcs(string s1, string s2) {
        int l1 = s1.Length, l2 = s2.Length;
        var dp = new string[l1+1, l2+1];
        for (int i = 0; i <= l1 ; i++)
            for (int j = 0; j <= l2 ; j++)
                dp[i,j] = "";
        for (int i = 0; i < l1 ; i++) {
            for (int j = 0; j < l2 ; j++) {
                if (s1[i] == s2[j]) dp[i+1, j+1] = dp[i,j] + s1[i];
                else dp[i+1,j+1] = dp[i+1,j].Length > dp [i,j+1].Length ? dp[i+1,j] : dp[i, j+1];
            }
        }
        return dp[l1,l2];
    }
}
