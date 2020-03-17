public class Solution {
    /*
    Put the largest element to its position. 
    Each element requires two flips
    e.g. [3, 2, 4, 1]
    largest element: 4, index: 2
    flip1: [4, 2, 3, 1]
    flip2: [1, 3, 2, 4]
    Repeat for [1, 3, 2]…
    */
    public IList<int> PancakeSort(int[] A) {
        var res = new List<int>();
        int n = A.Length, i;
        // k <= A.length
        // A[i] is a permutation of [1, 2, ..., A.length]
        for (int k = n; k >= 1; k--) {
            for (i = 0; A[i] != k; i++); // find index of k
            Array.Reverse(A, 0, i + 1); // Reverse => O(n)
            // Console.WriteLine(string.Join(",",A));
            res.Add(i + 1);
            Array.Reverse(A, 0, k); // move the largest to the end
            // Console.WriteLine(string.Join(",",A));
            res.Add(k);
        }
        // O(n^2)
        return res;
    }
}
