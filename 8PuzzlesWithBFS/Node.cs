using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8PuzzlesWithBFS
{
    public class Node
    {
        public int[,] State { get; set; } = new int[3, 3];
        public int Row { get; set; }
        public int Column { get; set; }
        public int Depth { get; set; }
        public Node Parent { get; set; }



        public bool IsGoalState(int[,] goalState, int[,] state)
        {
            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(1); j++)
                {
                    if (state[i, j] != goalState[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public List<Node> GetChildren(Node node)
        {
            List<Node> nodes = new List<Node>();
            int row = node.Row;
            int col = node.Column;
            Node newNode;

            //move empty tile up
            //empty tile mundemi me zhvendos nalt kur osht ne rreshtin 1 ose 2
            if (row > 0)
            {
                int[,] newState = (int[,])node.State.Clone();
                newState[row, col] = node.State[row - 1, col];
                //0  e konsiderojm si empty tile
                newState[row - 1, col] = 0;
                newNode = new Node
                {
                    State = newState,
                    Row = row - 1,
                    Column = col,
                    Depth = node.Depth + 1,
                    Parent = node
                };

                nodes.Add(newNode);
            }
            ////move empty tile down
            if (row < 2)
            {
                int[,] newState = (int[,])node.State.Clone();
                newState[row, col] = node.State[row + 1, col];
                newState[row + 1, col] = 0;
                newNode = new Node
                {
                    State = newState,
                    Row = row + 1,
                    Column = col,
                    Depth = node.Depth + 1,
                    Parent = node
                };
                nodes.Add(newNode);
            }

            //move empty tile left
            if (col > 0)
            {
                int[,] newState = (int[,])node.State.Clone();
                newState[row, col] = node.State[row, col - 1];
                newState[row, col - 1] = 0;
                newNode = new Node
                {
                    State = newState,
                    Row = row,
                    Column = col - 1,
                    Depth = node.Depth + 1,
                    Parent = node
                };
                nodes.Add(newNode);

            }
            //move empty tile right
            if (col < 2)
            {
                int[,] newState = (int[,])node.State.Clone();
                newState[row, col] = node.State[row, col + 1];
                newState[row, col + 1] = 0;
                newNode = new Node
                {
                    State = newState,
                    Row = row,
                    Column = col + 1,
                    Depth = node.Depth + 1,
                    Parent = node
                };
                nodes.Add(newNode);
            }
            return nodes;

        }

        //funksion qe kontrollon nese dy gjendjet jane te njejta
        public bool StateIsEqual(Node OtherNode)
        {
            for (int i = 0; i < State.GetLength(0); i++)
            {
                for (int j = 0; j < State.GetLength(1); j++)
                {
                    if (State[i, j] != OtherNode.State[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //funksion qe kontrollon nese gjendja eshte vizituar
        public bool StateIsChecked(HashSet<Node> visited)
        {
            foreach (Node node in visited)
            {
                //this i bje mu kon the current instace e klases
                if (node.StateIsEqual(this))
                {
                    return true;
                }
            }
            return false;
        }
    }


}
