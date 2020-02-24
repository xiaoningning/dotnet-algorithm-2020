public class Solution {
    public IList<int> GrayCode(int n) {
        var res = new List<int>(){0};
        for (int i = 0; i < n; i++) {
            int cnt = res.Count;
            for (int j = cnt - 1; j >= 0; j--) {
                res.Add(res[j] | 1 << i); // shift 1 bit for grey code
            }
        }
        return res;
    }
    /*
    Int    Grey Code    Binary
 　　  000        000
 　　  001        001
  　 　011        010
  　 　010        011
  　 　110        100
  　 　111        101
  　 　101        110
  　　 100        111
    */
}
