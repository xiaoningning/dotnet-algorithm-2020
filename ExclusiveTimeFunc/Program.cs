public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs) {
        int[] res = new int[n];
        // function id 
        var stk = new Stack<int>();
        int presTime = 0;
        foreach (string log in logs)
        {
            string[] f = log.Split(':');
            int fId = Int32.Parse(f[0]);
            string type = f[1];
            int time = Int32.Parse(f[2]);
            if (stk.Any()) res[stk.Peek()] += time - presTime;
            presTime = time;
            if (type == "start") stk.Push(fId);
            else{
                res[stk.Pop()]++;
                presTime++;
            }
        }
        return res;
    }
}
