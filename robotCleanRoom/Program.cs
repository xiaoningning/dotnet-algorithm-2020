using System;
using System.Collections.Generic;

namespace robotCleanRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("robot room cleaner can not build");
        }
    }
    
    interface Robot {
        // Returns true if the cell in front is open and robot moves into the cell.
        // Returns false if the cell in front is blocked and robot stays in the current cell.
        public bool Move();
    
        // Robot will stay in the same cell after calling turnLeft/turnRight.
        // Each turn will be 90 degrees.
        public void TurnLeft();
        public void TurnRight();
        // Clean the current cell.
        public void Clean();
    }
    
    class Solution {
        public void CleanRoom(Robot robot) {
            HashSet<string> visited = new HashSet<string>();
            DFS(robot, 0, 0, visited);
        }

        void DFS(Robot robot, int x, int y, HashSet<string> visited){
            string temp = x + "," + y;
            if (visited.Contains(temp)) {
                return;
            }
            visited.Add(temp);
            robot.Clean();
            // always go back the original position
            if (MoveUp(robot)) {
                DFS(robot, x-1, y, visited);
                MoveDown(robot);
            }
            if (MoveLeft(robot)) {
                DFS(robot, x, y-1, visited);
                MoveRight(robot);
            }
            if (MoveRight(robot)) {
                DFS(robot, x, y+1, visited);
                MoveLeft(robot);
            }
            if (MoveDown(robot)) {
                DFS(robot, x+1, y, visited);
                MoveUp(robot);
            }
            
        }
        // always face up
        private bool MoveUp(Robot robot) {
		    bool res = robot.Move();
            return res;
        }
        private bool MoveLeft(Robot robot) {
            robot.TurnLeft();
            bool res = robot.Move();
            robot.TurnRight();
            return res;
        }
        private bool MoveRight(Robot robot) {
            robot.TurnRight();
            bool res = robot.Move();
            robot.TurnLeft();
            return res;
        }
        private bool MoveDown(Robot robot) {
            robot.TurnLeft();
            robot.TurnLeft();
            bool res = robot.Move();
            robot.TurnRight();
            robot.TurnRight();
            return res;
        }
    }
}
