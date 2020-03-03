public class MedianFinder {
    List<int> mn,mx;
    /** initialize your data structure here. */
    public MedianFinder() {
        mn = new List<int>();
        mx = new List<int>();
    }
    
    public void AddNum(int num) {
        mn.Add(num);
        mn.Sort();
        mx.Add(mn.Last());
        mx.Sort();
        mn.RemoveAt(mn.Count - 1);
        if (mn.Count < mx.Count) {
            mn.Add(mx.First());
            mn.Sort();
            mx.RemoveAt(0);
        }
    }
    
    public double FindMedian() {
        return mn.Count > mx.Count ? (double) mn.Last() : 0.5 * (mn.Last() + mx.First());
    }
}

public class MedianFinder1 {

    /** initialize your data structure here. */
    public MedianFinder1() {
        min = new SortedDictionary<int, List<int>>();
        max = new SortedDictionary<int, List<int>>();
        minC = 0;
        maxC = 0;
    }
    
    public void AddNum(int num) {
        if(!min.ContainsKey(num)) min.Add(num,new List<int>());
        min[num].Add(num);
        minC++;
        if(!max.ContainsKey(min.Last().Key)) 
                max.Add(min.Last().Key,new List<int>());
        max[min.Last().Key].Add(min.Last().Key);
        maxC++;
        min.Last().Value.RemoveAt(0);
        minC--;
        if(min.Last().Value.Count == 0) min.Remove(min.Last().Key);
        if (minC < maxC) {
            if(!min.ContainsKey(max.First().Key)) 
                min.Add(max.First().Key,new List<int>());
            min[max.First().Key].Add(max.First().Key);
            minC++;
            max.First().Value.RemoveAt(0);
            maxC--;
            if(max.First().Value.Count == 0) max.Remove(max.First().Key);
        }
    }
    
    public double FindMedian() {
        return (minC > maxC) ? 
                (double) min.Last().Key 
                :  0.5 * (min.Last().Key + max.First().Key);
    }
    
    private SortedDictionary<int, List<int>> min;
    private int minC;
    private SortedDictionary<int, List<int>> max;
    private int maxC;
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
