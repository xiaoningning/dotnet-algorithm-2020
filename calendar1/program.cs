public class MyCalendar {
    private SortedDictionary<int, int> timesDict;
    public MyCalendar() {
        timesDict = new SortedDictionary<int, int>();
    }
    
    public bool Book(int start, int end) {
        int cnt = 0, current = 0;
        if (timesDict.ContainsKey(start)) timesDict[start]++;
        else timesDict.Add(start, 1); 

        if (timesDict.ContainsKey(end)) timesDict[end]--;
        else timesDict.Add(end, -1);

        foreach(var times in timesDict){
            cnt += times.Value;
            if(cnt == 2) {
                // remove booked time
                timesDict[start]--;
                timesDict[end]++;
                return false;
            }
        } 
        return true;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */
