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
            int oneDay = 24 * 60;
            int timeGap = oneDay;
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
                                    int candidateTime = (h1 * 10 + h2) * 60 + m1 * 10 + m2;
                                    int newGap = (candidateTime > currTime) ? candidateTime - currTime : oneDay - currTime + candidateTime ;
                                    if ( newGap <= timeGap ) {
                                        timeGap = newGap;
                                        nextTime = candidateTime;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return string.Format("{0:00}:{1:00}", nextTime / 60, nextTime % 60);
        }
    }
}
