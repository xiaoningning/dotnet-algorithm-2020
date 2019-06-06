public class Solution {
    public string GetHint(string secret, string guess) {
        int[] m = new int[256];
        int bull = 0, cow = 0;
        for (int i = 0; i < secret.Length; i++) {
            if (secret[i] == guess[i]) bull++;
            else {
                if (m[secret[i]]++ < 0) cow++;
                if (m[guess[i]]-- > 0) cow++;
            }
        }
        return bull+"A"+cow+"B";
    }
}
