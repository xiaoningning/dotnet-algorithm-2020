using System;
using System.Linq;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine(KMP("BBC_ABCDAB_ABCDABCDABDE", "ABCDABD"));
		Console.WriteLine(KMP("ABCABCABED", "ABCABCE"));
	}
	
	static int[] GetNext(string p) {
		int n = p.Length;
		int[] next = new int[n];
		for (int i = 0; i < n; i++) next[i] = -1;
		int k = -1, j = 0;
		Console.WriteLine(p);
		while (j < n - 1) {
			Console.WriteLine(p[j]+" j:" + j +", " + (k != -1 ? p[k] : "-") +" k:" + k);
			if (k == -1 || p[k] == p[j]) {
				k++;j++;
				next[j] = (p[k] != p[j]) ? k : next[k];
			}
			else k = next[k];
			Console.WriteLine("next: " + string.Join(',', next));
		}
		return next;
	}
	static int KMP(string s, string p) {
		int m = s.Length, n = p.Length, i = 0, j = 0;
		var next = GetNext(p);
		while(i < m && j < n) {
			Console.WriteLine(s[i]+" i:" + i +", " + (j != -1 ? p[j] : "") +" j:" + j);
			Console.WriteLine(s);
			Console.WriteLine(new String('-',i-j) + p);
			if (j == -1 || s[i] == p[j]) {
				i++;j++;
			}
			else j = next[j];
		}
		// O(n + m)
		return j == n ? i - j : -1;
	}
}
