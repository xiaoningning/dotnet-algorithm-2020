public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var res = new List<IList<int>>();
        for (int i = 0; i < numRows; ++i) {
            var row = new int[i+1];
            Array.Fill(row, 1);
            for (int j = 1; j < i; j++)
			    row[j] = res[i - 1][j - 1] + res[i - 1][j];
		    res.Add(new List<int>(row));
        }
        return res;
    }
}
