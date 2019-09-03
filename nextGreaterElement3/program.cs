public class Solution {
    public int NextGreaterElement(int n) {
        var strArr = n.ToString().ToCharArray();
        int len = strArr.Length, i = len - 1;
        for (; i > 0 ; i--) {
            if (strArr[i] > strArr[i - 1]) break;
        }
        if (i == 0) return -1;
        for (int j = len - 1; j >= i; --j) {
            if (strArr[j] > strArr[i - 1]) {
                Swap(strArr, j, i - 1);
                break;
            }
        }
        Array.Sort(strArr, i, len - i);
        long res = Convert.ToInt64(new string(strArr));
        return res > Int32.MaxValue ? -1 : Convert.ToInt32(res);
    }
    void Swap(char[] a, int x, int y) {
        var t = a[x];
        a[x] = a[y];
        a[y] = t;
     }
}
