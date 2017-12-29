using System;
using System.Collections.Generic;
using System.Linq;

namespace getSkyline
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int[,] buildings = new int[,]{{2, 9, 10},
                                        {3, 7, 15}, 
                                        {5, 12, 12}, 
                                        {15, 20, 10}, 
                                        {19, 24, 8}};
            */
            int[,] buildings = new int[,]{{0,2,3},{2,5,3}};
            
            Console.WriteLine("buildings:");
            for (int i = 0; i < buildings.GetLength(0); i++)
            {
                for (int x = 0; x < buildings.GetLength(1); x++)
                {
                    Console.Write(buildings[i, x]);
                    Console.Write(" ");
                }                
                Console.WriteLine();
            }
            var res = GetSkyline(buildings);

            Console.WriteLine("skylines:");
            for (int i = 0; i < res.Count; i++)
            {
                Console.WriteLine(string.Join(",", res[i]));                
            }
        }

        static IList<int[]> GetSkyline(int[,] buildings) {
            List<int[]> res = new List<int[]>();
            List<int[]> heights = new List<int[]>();
            for (int i = 0; i < buildings.GetLength(0); i++)
            {
                // use negative height as the start point
                heights.Add(new int[]{buildings[i,0], -buildings[i,2]});
                heights.Add(new int[]{buildings[i,1], buildings[i,2]});
            }
            heights.Sort((a, b) => (a[0] == b[0]) ? a[1] - b[1] : a[0] - b[0]);
            
            // key: height, value: count of buildings with the same height
            SortedDictionary<int, int> sortedHeights = new SortedDictionary<int, int>();
            // the base height as the terminated point.
            // value is dummy here.
            sortedHeights.Add(0, 1); 
            int prevHeight = 0;
            foreach (var h in heights)
            {
                if(h[1] < 0) {
                    if(sortedHeights.ContainsKey(-h[1])) sortedHeights[-h[1]]++;
                    else sortedHeights[-h[1]] = 1;
                    // sortedHeights[-h[1]] = sortedHeights.ContainsKey(-h[1]) ? sortedHeights[-h[1]]++ : 1 ;
                }
                else {
                    if (sortedHeights.ContainsKey(h[1]) && sortedHeights[h[1]] == 1) sortedHeights.Remove(h[1]);
                    else if (sortedHeights.ContainsKey(h[1])) sortedHeights[h[1]]--;
                    else sortedHeights[h[1]] = 1;
                }                            

                int currHeight = sortedHeights.Last().Key;
                if(currHeight != prevHeight){
                   res.Add(new int[]{h[0], currHeight});
                   prevHeight = currHeight;
                } 
            }
            return res;
        }
    }
}
