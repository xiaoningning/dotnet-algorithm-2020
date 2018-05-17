using System;

namespace wordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            char[,] b = new char[,]{{'a', 'b'}};
            Console.WriteLine("word search {0}", obj.Exist(b, "ba"));
        }
    }
    public class Solution {
        public bool Exist(char[,] board, string word) {
            if(board.Length < word.Length) return false;
            int m = board.GetLength(0);
            int n = board.GetLength(1);
            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    if(WordSearch(board, word, 0, i, j)) return true;        
                }
            }
            return false;
        }
        bool WordSearch(char[,] board, string word, int idx, int i, int j){
            // search till the end of word
            if(idx == word.Length) return true;
            int m = board.GetLength(0);
            int n = board.GetLength(1);   
            if (i < 0 || j < 0 || i >= m || j >= n || board[i,j] != word[idx]) return false;
            char c = board[i,j];
            board[i,j] = '#';
            bool res = WordSearch(board, word, idx + 1, i - 1, j) 
                    || WordSearch(board, word, idx + 1, i + 1, j)
                    || WordSearch(board, word, idx + 1, i, j - 1)
                    || WordSearch(board, word, idx + 1, i, j + 1);
            board[i,j] = c;        
            return res;
        }
    }
}
