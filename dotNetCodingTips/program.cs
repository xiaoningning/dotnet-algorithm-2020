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
		var a1 = new int[1,2,3];
		Console.WriteLine("array rank: " + a1.Rank);
		var a2 = new int[2][][];
		Console.WriteLine("array rank: " + a2.Rank);
		
		var (l, s) = GetIt("aefbgc");
		Console.WriteLine("string length:"+l);
		var res = GetIt("aefbgc");
		Console.WriteLine(res.vs);
		s = new string(s.OrderBy(a => a).ToArray());
		Console.WriteLine("orderby:" + s);
		s = s.Remove(1,1);
		Console.WriteLine("remove string at 1:"+s);
		
		// array as key of dictionary
		var d = new Dictionary<(int,string), string>(){{(1,"11"), "abcd"}, {(2,"22"),"xyz"}};
		Console.WriteLine(d[(1,"11")]);
		Console.WriteLine(d.ContainsKey((2,"3")));
		Console.WriteLine(d.ContainsKey((1,"11")));
		foreach (var kv in d){
			Console.WriteLine("tuple as key of dict: "+ kv.Key.Item2);
		}
		var limitsLookup = new Dictionary<int, (int Min, int Max)>() {
			[2] = (4, 10),
			[4] = (10, 20),
			[6] = (0, 23)
		};

		if (limitsLookup.TryGetValue(4, out (int Min, int Max) limits)) {
			Console.WriteLine($"Found limits: min is {limits.Min}, max is {limits.Max}");
		}
		
		var q = new Queue<(int, string)>();
		q.Enqueue((1,"11"));
		Console.WriteLine("tuple queue: " + q.Dequeue().Item2);
		
		var lst = new List<string>(){"a","b","v"};
		// Get index of list
		foreach (var (idx, v) in lst.Select((v, i) => (i, v))) {
			Console.WriteLine(idx + ": " + v);
		}
		
		Console.WriteLine("is type check: " + ("abc" is not null));
	}
	
	static (int ln, string vs) GetIt(string s) {
		return (s.Length, s);
	}
}
