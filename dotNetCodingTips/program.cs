using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		var ar = Enumerable.Range(1,5);	
		Console.WriteLine(string.Join(',', ar));
		var (l, s) = GetIt("abc");
		Console.WriteLine(l);		
		var d = new Dictionary<(int,string), string>(){{(1,"1"), "abc"}};
		Console.WriteLine(d[(1,"1")]);
		Console.WriteLine(d.ContainsKey((2,"3")));
		Console.WriteLine(d.ContainsKey((1,"1")));
		var lst = new List<string>(){"a","b","v"};
		foreach (var (idx, v) in lst.Select((v, i) => (i, v))) {
			Console.WriteLine(idx + ": " + v);
		}
	}
  
	static (int, string) GetIt(string s) {
		return (s.Length, s);
	}
}
