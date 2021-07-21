using System;
using System.Linq;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine(KMP("BBC_ABCDAB_ABCDABCDABDE", "ABCDABD"));
	}
	
	static int[] GetNext(string p) {
		int n = p.Length;
		int[] next = new int[n];
		for (int i = 0; i < n; i++) next[i] = -1;
		int k = -1, j = 0;
		while (j < n - 1) {
			Console.WriteLine("next: " + string.Join(',', next));
			if (k == -1 || p[k] == p[j]) {
				k++;j++;
				next[j] = (p[k] != p[j]) ? k : next[k];
			}
			else k = next[k];
		}
		return next;
	}
	static int KMP(string s, string p) {
		int m = s.Length, n = p.Length, i = 0, j = 0;
		var next = GetNext(p);
		while(i < m && j < n) {
			Console.WriteLine("i:" + i +", j:" + j);
			if (j == -1 || s[i] == p[j]) {
				i++;j++;
			}
			else j = next[j];
		}
		return j == n ? i - j : -1;
	}
}
