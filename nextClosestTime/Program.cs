using System;
using System.Collections.Generic;

namespace nextClosestTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string timeStr = args[0];
            Console.WriteLine("input time: {0}", timeStr);
            Console.WriteLine("the next closest time: {0}", NextClosestTime(timeStr));
        }

        public static string NextClosestTime(string time) {
            int hours = Int32.Parse(time.Substring(0,2));
            int mins = Int32.Parse(time.Substring(3));
            int currTime = hours * 60 + mins;
            int nextTime = 0;
            HashSet<int> allowed = new HashSet<int>();
            int timeGap = 24 * 60;
            foreach (char c in time)
            {   
                if (c != ':'){
                    allowed.Add(c - '0');
                }                
            }

            foreach(int h1 in allowed){
                foreach(int h2 in allowed){
                    if (h1 * 10 + h2  < 24){
                        foreach(int m1 in allowed){
                            foreach(int m2 in allowed){
                                if (m1 * 10 + m2 < 60){
                                    int tmpTime = (h1 * 10 + h2) * 60 + m1 * 10 + m2;
                                    int tmpGap = Math.Abs(tmpTime - currTime) % (24 * 60) ;
                                    if ( tmpGap < timeGap && tmpGap > 0 ) {
                                        timeGap = tmpGap;
                                        nextTime = tmpTime;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return string.Format("{0}:{1}", nextTime / 60, nextTime % 60);
        }
    }
}
