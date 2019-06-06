/**
 * // This is the Master's API interface.
 * // You should not implement it, or speculate about its implementation
 * class Master {
 *     public int Guess(string word);
 * }
 */
class Solution {
    public void FindSecretWord(string[] wordlist, Master master) {
        var l = wordlist.ToList();
        for (int i = 0, x = 0; i < 10 && x < 6; i++) {
            string guess = l[new Random().Next(l.Count)];
            x = master.Guess(guess);
            var l2 = new List<string>();
            foreach (var w in l)
                if (match(w, guess) == x) l2.Add(w);
            l = l2;
        }
    }
    
    public int match(string a, string b) {
        int matches = 0;
        for (int i = 0; i < a.Length; ++i) 
            if (a[i] == b[i]) matches++;
        return matches;
    }
}
