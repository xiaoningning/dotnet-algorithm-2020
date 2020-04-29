public class Solution {
    public int WordsTyping(string[] sentence, int rows, int cols) {
        var all = "";
        foreach (var str in sentence) all += str + " ";
        int s = 0, len = all.Length;
        for (int i = 0; i < rows; i++) {
            s += cols;
            if (all[s % len] == ' ') s++;
            else {
                while (s > 0 && all[(s - 1) % len] != ' ') s--;
            }
        }
        return s / len;
    }
}
