using System;
using System.Collections.Generic;

namespace largestRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n1 = new int[]{2,1,5,6,2,3};
            var obj = new Solution();
            Console.WriteLine("largest rectangle [2,1,5,6,2,3] {0}", obj.LargestRectangleArea(n1));
            n1 = new int[]{1};
            Console.WriteLine("largest rectangle [1] {0}", obj.LargestRectangleArea(n1));
        }
    }
    public class Solution {
        public int LargestRectangleArea1(int[] heights) {
            Stack<int> st = new Stack<int>();
            int res = 0;
            for(int i = 0; i <= heights.Length; i++){
                // handle only heights.Length = 1, such as [1]
                int tmp = i < heights.Length ? heights[i] : 0;
                while (st.Count != 0 && heights[st.Peek()] >= tmp) {
                    int cur = st.Pop();
                    res = Math.Max(res, heights[cur] * (st.Count == 0 ? i : (i - st.Peek() - 1)));
                }
                st.Push(i);
            }
            return res;
        }

        public int LargestRectangleArea(int[] heights) {
            int res = 0;
            Stack<int> st = new Stack<int>();
            // add 0 at the end for heights.Length == 1
            List<int> h = new List<int>(heights);
            h.Add(0);
            for (int i = 0; i < h.Count; ++i) {
                if (st.Count == 0 || h[st.Peek()] < h[i]) {
                    st.Push(i);
                } else {
                    int cur = st.Pop();
                    res = Math.Max(res, h[cur] * (st.Count == 0 ? i : (i - st.Peek() - 1)));
                    --i; // stop i here to calculate all cases in stack
                }     
            }
            return res;
        }
    }
}
