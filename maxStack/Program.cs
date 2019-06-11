public class MaxStack {
    Stack<int> s1, s2;
    /** initialize your data structure here. */
    public MaxStack() {
        s1 = new Stack<int>();
        s2 = new Stack<int>();
    }
    
    public void Push(int x) {
        s1.Push(x);
        if (s2.Count == 0 || x >= s2.Peek()) 
            s2.Push(x);
    }
    
    public int Pop() {
        var t = s1.Pop();
        if (s2.Count != 0 && t == s2.Peek())
            s2.Pop();
        return t;
    }
    
    public int Top() {
        return s1.Peek();
    }
    
    public int PeekMax() {
        return s2.Count != 0 ? s2.Peek() : Int32.MinValue;
    }
    
    public int PopMax() {
        var t = s2.Count != 0 ? s2.Peek() : Int32.MinValue;
        var st = new Stack<int>();
        while (s1.Count != 0 && s1.Peek() != t) {
            st.Push(s1.Pop());
        }
        s1.Pop(); s2.Pop();
        while (st.Count != 0) {
            // reset s2 stack for new max
            Push(st.Pop());
        }
        return t;
    }
}

/**
 * Your MaxStack object will be instantiated and called as such:
 * MaxStack obj = new MaxStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.PeekMax();
 * int param_5 = obj.PopMax();
 */
