using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		var intarray = Enumerable.Range(1,5);	
		Console.WriteLine("enumerable range:"+string.Join(',', intarray));
		var sarray = Enumerable.Repeat("a", 5);
		Console.WriteLine("enumerable repeat:"+string.Join(',', sarray));
		
		// get tuple as return of func
		var (l, s) = GetIt("aefbgc");
		Console.WriteLine("string length:"+l);
		s = new string(s.OrderBy(a => a).ToArray());
		Console.WriteLine("orderby:" + s);
		s = s.Remove(1,1);
		Console.WriteLine("remove string at 1:"+s);
		
		// array as key of dictionary
		var d = new Dictionary<(int,string), string>(){{(1,"1"), "abcd"}};
		Console.WriteLine(d[(1,"1")]);
		Console.WriteLine(d.ContainsKey((2,"3")));
		Console.WriteLine(d.ContainsKey((1,"1")));
		
		var lst = new List<string>(){"a","b","v"};
		// Get index of list
		foreach (var (idx, v) in lst.Select((v, i) => (i, v))) {
			Console.WriteLine(idx + ": " + v);
		}
	}
	static (int, string) GetIt(string s) {
		return (s.Length, s);
	}
}
