﻿using System;
using System.Collections.Generic;
namespace trapRainWater
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();               
            int[] h = new int[]{0,1,0,2,1,0,1,3,2,1,2,1};
            Console.WriteLine("trap rain water: {0}", obj.Trap(h));
        }
    }
    public class Solution {
        public int Trap1(int[] height) {
            int l = 0, r = height.Length - 1;
            int maxLeft = 0, maxRight = 0;
            int res = 0;
            while (l < r) {
                if (height[l] <= height[r]){
                    if (height[l] >= maxLeft) maxLeft = height[l];
                    res += maxLeft - height[l];
                    l++;
                }
                else {
                    if (height[r] >= maxRight) maxRight = height[r];
                    res += maxRight - height[r];
                    r--;
                }
            }
            return res;
        }
        public int Trap(int[] height) {
            Stack<int> stack = new Stack<int>();
            int res = 0, i = 0;
            while (i < height.Length) {            
                if (stack.Count == 0 || height[stack.Peek()] >= height[i]) stack.Push(i++);
                else {
                    int tmp = stack.Pop();
                    if (stack.Count == 0) continue;
                    res += (Math.Min(height[stack.Peek()], height[i]) - height[tmp]) * (i - stack.Peek() - 1);
                }
            }
            return res;
        }
    }
}
