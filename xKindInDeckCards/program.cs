public class Solution {
    public bool HasGroupsSizeX(int[] deck) {
        var cardCnt = new Dictionary<int, int>();
        foreach (int card in deck) {
            if (!cardCnt.ContainsKey(card)) cardCnt.Add(card,0);
            ++cardCnt[card];
        }
        int mn = Int32.MaxValue;
        foreach (var a in cardCnt) mn = Math.Min(mn, a.Value);
        if (mn < 2) return false;
        for (int i = 2; i <= mn; ++i) {
            bool success = true;
            foreach (var a in cardCnt) {
                if (a.Value % i != 0) {
                    success = false;
                    break;
                }
            }
            if (success) return true;
        }
        return false;
    }
}
