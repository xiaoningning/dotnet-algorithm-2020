using System;

namespace wallsAndGates
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[,] rooms = new int[,]{
                {Int32.MaxValue, -1, 0, Int32.MaxValue},
                {Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, -1},
                {Int32.MaxValue, -1, Int32.MaxValue, -1},
                {0, -1, Int32.MaxValue, Int32.MaxValue}
                };
            obj.WallsAndGates(rooms);
            Console.WriteLine("walls and gates update:");
            foreach(var r in rooms){
                Console.WriteLine("{0}", string.Join(',', r));
            }
        }
    }
    public class Solution {
        public void WallsAndGates(int[,] rooms) {
            for(int i = 0; i < rooms.GetLength(0); i++){
                for(int j = 0; j < rooms.GetLength(1); j++){
                    if(rooms[i,j] == 0){
                        // set neighbor as 1
                        DFS(rooms, i-1, j, 1);
                        DFS(rooms, i+1, j, 1);
                        DFS(rooms, i, j+1, 1);
                        DFS(rooms, i, j-1, 1);
                    }
                }
            }
        }
        void DFS(int[,] rooms, int i, int j, int val){
            if(i < 0 || j < 0 || i >= rooms.GetLength(0) || j >= rooms.GetLength(1)) return;
            if(rooms[i,j] > val){
                rooms[i,j] = val;
                DFS(rooms, i-1, j, val+1);
                DFS(rooms, i+1, j, val+1);
                DFS(rooms, i, j+1, val+1);
                DFS(rooms, i, j-1, val+1);
            }
            
        }
    }
}
