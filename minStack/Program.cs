public class MinStack {
    private Stack<int> s1;
    private Stack<int> s2;
    
    public MinStack() {
        s1 = new Stack<int>();
        s2 = new Stack<int>();
    }  
    public void Push(int x) {
        s1.Push(x);
        if (!s2.Any() || s2.Peek() >= x) s2.Push(x);
    }
    public void Pop() {
        int x = s1.Pop();
        if (s2.Peek() == x) s2.Pop();
    }   
    public int Top() {
        return s1.Peek();
    }  
    public int GetMin() {
        return s2.Peek();
    }
}
public class MinStack1 {
    // use two stack, one for min value
    // another for all value
    private int _min;
    private Stack<int> _s;
    /** initialize your data structure here. */
    public MinStack1() {
        _min = Int32.MaxValue;
        _s = new Stack<int>();
    }
    
    public void Push(int x) {
        // push the old min value
        // then new min
        if (x <= _min) {
            _s.Push(_min);
            _min = x;
        }
        _s.Push(x);
    }
    
    public void Pop() {
        int t = _s.Pop();
        //  the old min is always under current min
        if (t == _min) _min = _s.Pop();
    }
    
    public int Top() {
        return _s.Peek();
    }
    
    public int GetMin() {
        return _min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
