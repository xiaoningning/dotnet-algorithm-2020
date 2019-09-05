public class FreqStack {

    public FreqStack() {
        m = new Dictionary<int, List<int>>();
        freq = new Dictionary<int, int>();
    }
    
    public void Push(int x) {
        if (!freq.ContainsKey(x)) freq.Add(x,0);
        mxFreq = Math.Max(mxFreq, ++freq[x]);
        if (!m.ContainsKey(freq[x])) m.Add(freq[x], new List<int>());
        m[freq[x]].Add(x);
    }
    
    public int Pop() {
        int x = m[mxFreq].Last();
        m[mxFreq].Remove(x);
        if(!m[freq[x]--].Any()) mxFreq--;
        return x;
    }
    
    int mxFreq;
    Dictionary<int, List<int>> m;
    Dictionary<int, int> freq;
}

/**
 * Your FreqStack object will be instantiated and called as such:
 * FreqStack obj = new FreqStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 */
