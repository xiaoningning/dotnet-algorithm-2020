public class StockSpanner {
    Stack<int[]> s;
    public StockSpanner() {
        s = new Stack<int[]>();
    }
    
    public int Next(int price) {
        int res = 1;
        while (s.Any() && s.Peek()[0] <= price)
            res += s.Pop()[1];
        s.Push(new int[2]{price, res});
        return res;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */
