using System;
using System.Collections.Generic;

namespace calendar3
{
    class Program
    {
        static void Main(string[] args)
        {
            int start, end;
            
            MyCalendarThree myCalendar = new MyCalendarThree();
            
            while (true)
            {
                Console.WriteLine("input calender:");
                string input = Console.ReadLine();

                if (input.Equals("x")) break;

                start = Int32.Parse(input.Split(',')[0]);
                end = Int32.Parse(input.Split(',')[1]);
                Console.WriteLine("input calendar start {0} end {1}", start, end);
                Console.WriteLine("Book result: {0}", myCalendar.Book(start, end));
            }
        }
    }

    public class MyCalendarThree
    {
        SortedDictionary<int, int> timesDict;
        public MyCalendarThree()
        {
            timesDict = new SortedDictionary<int, int>();
        }

        public int Book(int start, int end)
        {
            int cnt = 0, current = 0;
            if (timesDict.ContainsKey(start)) timesDict[start]++;
            else timesDict.Add(start, 1); 
            
            if (timesDict.ContainsKey(end)) timesDict[end]--;
            else timesDict.Add(end, -1);

            foreach(var times in timesDict){
                current += times.Value;
                if(current > cnt) cnt = current;
            } 
            
            return cnt;
        }
    }

}
