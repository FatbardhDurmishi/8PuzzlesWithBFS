using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8PuzzlesWithBFS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] goalState = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 0 } };
            Node initialNode = new Node
            {
                State = new int[,] {
                    { 1, 8, 2},
                    { 0, 4, 3 },
                    { 7, 6, 5 } },
                Row = 1,
                Column = 0,
                Depth = 0,
                Parent = null

            };

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(initialNode);

            HashSet<Node> visited = new HashSet<Node>();

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                if (current.IsGoalState(goalState, current.State))
                {
                    Console.WriteLine("The puzzle is solved" + "\nDepth: " + current.Depth);
                    for (int i = 0; i < current.State.GetLength(0); i++)
                    {
                        for (int j = 0; j < current.State.GetLength(1); j++)
                        {
                            Console.WriteLine(current.State[i, j]);
                        }
                    }
                    break;
                }

                List<Node> nodes = current.GetChildren(current);

                foreach (Node item in nodes)
                {

                    //nese e kena check niher state aktual ose gjendet ne queue e anashkalojm
                    if (item.StateIsChecked(visited) || queue.Contains(item))
                    {
                        continue;
                    }

                    queue.Enqueue(item);
                    visited.Add(item);
                }
            }
            Console.ReadLine();
        }
    }
}