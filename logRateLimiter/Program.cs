public class Logger {
    Dictionary<string, int> m;
    /** Initialize your data structure here. */
    public Logger() {
        m = new Dictionary<string, int>();
    }
    
    /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
        If this method returns false, the message will not be printed.
        The timestamp is in seconds granularity. */
    public bool ShouldPrintMessage(int timestamp, string message) {
        if (!m.ContainsKey(message)){
            m.Add(message, timestamp);
            return true;
        }
        if (timestamp - m[message] >= 10){
            m[message] = timestamp;
            return true;
        }
        return false;
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */
