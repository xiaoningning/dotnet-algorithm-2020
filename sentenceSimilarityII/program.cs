public class Solution {
    Dictionary<string, string> roots = new Dictionary<string, string>();
    public bool AreSentencesSimilarTwo(string[] words1, string[] words2, IList<IList<string>> pairs) {
        if (words1.Length != words2.Length) return false;
        foreach (var p in pairs) {
            string r1 = FindRoot(roots, p[0]);
            string r2 = FindRoot(roots, p[1]);
            if (r1 != r2) roots[r1] = r2;
        }

        for (int i = 0; i < words1.Length; i++) {
            if (!words1[i].Equals(words2[i]) 
                && !FindRoot(roots, words1[i]).Equals(FindRoot(roots, words2[i]))) 
                return false;
        }
        return true;
    }
    string FindRoot(Dictionary<string, string> roots, string i){
        if (!roots.ContainsKey(i)) roots.Add(i, i);
        while (i != roots[i]) {
            // path compression
            // roots[i] = roots[roots[i]];
            i = roots[i];
        }
        return i;
    }
}
