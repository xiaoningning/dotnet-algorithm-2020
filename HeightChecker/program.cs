public class Solution {
    public int HeightChecker(int[] heights) {
        int[] copy = (int[])heights.Clone();
        Array.Sort(copy);
        int cnt = 0;
        for(int i = 0; i < copy.Length; i++){
            if (heights[i] != copy[i]) cnt++;
        }
        return cnt;
    }
}
