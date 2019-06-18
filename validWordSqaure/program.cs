public class Solution {
    public bool ValidWordSquare(IList<string> words) {
        if (words.Count == 0) return true;
        if (words.Count != words[0].Length) return false;
        for (int i = 0; i < words.Count; i++) {
            for (int j = 0; j < words[i].Length; j++) {
                // check j first due to words[j]
                if (j >= words.Count 
                    || i >= words[j].Length 
                    || words[i][j] != words[j][i]) return false;
            } 
        }
        return true;
    }
}
