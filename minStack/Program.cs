public class MinStack {
    // use two stack, one for min value
    // another for all value
    private int _min;
    private Stack<int> _s;
    /** initialize your data structure here. */
    public MinStack() {
        _min = Int32.MaxValue;
        _s = new Stack<int>();
    }
    
    public void Push(int x) {
        if (x <= _min) {
            _s.Push(_min);
            _min = x;
        }
        _s.Push(x);
    }
    
    public void Pop() {
        int t = _s.Peek();
        _s.Pop();

        if (t == _min) {
            _min = _s.Peek();
            _s.Pop();
        }
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
