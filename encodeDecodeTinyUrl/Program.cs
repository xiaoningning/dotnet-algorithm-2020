using System;
using System.Collections.Generic;
using System.Text;

namespace encodeDecodeTinyUrl
{
    class Program
    {
        static void Main(string[] args)
        {
            string longUrl = args[0];            
            Console.WriteLine("input url:" + longUrl);
            Console.WriteLine(encode(longUrl));
            Console.WriteLine("short url:");
            string shortUrl = Console.ReadLine();
            Console.WriteLine(decode(shortUrl));
        }
        static string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static Dictionary<string, string> map = new Dictionary<string, string>();
        static Random random = new Random();
        static string key = getRandomKey();

        public static string getRandomKey(){
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 6; i++){
                sb.Append(alphabet[random.Next(62)]);
            }
            return sb.ToString();
        }

        public static string encode(string longUrl){
            while(map.ContainsKey(key)){
                key = getRandomKey();
            }
            map.Add(key, longUrl);
            return "http://tinyurl.com/" + key;
        }

        public static string decode(string shortUrl){
            string tmpKey = shortUrl.Replace("http://tinyurl.com/", "");
            if (map.ContainsKey(tmpKey)){
                return map[tmpKey];
            }
            else{
                return "wrong input";
            }            
        }
    }
}
