using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumMatchingProblem
{
    class HopcroftKarp
    {
        Stack<Node> unMatchedNodes;
        BipartiteGraph bipartiteGraph;
        void PrintFlows(List<Node> nodes)
        {
            foreach (Node node in nodes)
            {
                foreach (var item in node.neighbours)
                {
                    Console.WriteLine("From " + node.index.ToString() + " to " + item.Key.index.ToString() + " - " + item.Value.isUsed.ToString());
                }
            }
        }
        public int Solve(string inputPath)
        {
            bipartiteGraph = new BipartiteGraph(Directory.GetParent(Environment.CurrentDirectory)?.Parent?.FullName + inputPath);
            unMatchedNodes = new Stack<Node>(bipartiteGraph.leftNodes);
            while (unMatchedNodes.Count > 0)
            {
                Node unMatchedNode = unMatchedNodes.Pop();
                var result = BFS(unMatchedNode);
                if (result.pathFound)
                {
                    List<Node> list = Path(result.depths, result.unMatchedRightSideNode, unMatchedNode);
                    UpdatePath(list);
                }
            }
            int numberOfMatchedRightSide = 0;
            foreach(Node node in bipartiteGraph.rightNodes)
            {
                if(node.matched)
                {
                    numberOfMatchedRightSide++;
                }
            }
            return numberOfMatchedRightSide;
        }
        static void UpdatePath(List<Node> nodes)
        {
            nodes[0].matched = true;
            nodes[nodes.Count - 1].matched = true;
            for(int i = 0; i < nodes.Count - 1; i++)
            {
                Node start = nodes[i];
                Node destination = nodes[i + 1];
                Flow flow = start.neighbours[destination];
                if(flow.isUsed)
                {
                    flow.isUsed = false;
                }
                else
                {
                    flow.isUsed = true;
                }
            }
        }
        static List<Node> Path(Dictionary<Node, int> depths, Node unMatchedRightSideNode, Node unMatchedLeftSideNode)
        {
            List<Node> path = new List<Node>();
            Node currentNode = unMatchedRightSideNode;
            while (currentNode != unMatchedLeftSideNode)
            {
                path.Add(currentNode);
                foreach (Node node in currentNode.neighbours.Keys)
                {
                    if(depths.ContainsKey(node))
                    {
                        if (depths[node] == depths[currentNode] - 1)
                        {
                            currentNode = node;
                        }
                    }
                }
            }
            path.Add(currentNode);
            return path;
        }
        public (Dictionary<Node, int> depths, Node unMatchedRightSideNode, bool pathFound) BFS(Node unMatchedNode)
        {
            Dictionary<Node, int> depths = new Dictionary<Node, int>();
            Queue<Node> queue = new Queue<Node>();
            depths.Add(unMatchedNode, 0);
            queue.Enqueue(unMatchedNode);
            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                foreach (Node adjacent in node.neighbours.Keys)
                {
                    if (adjacent.nodeType == NodeType.RightSide && adjacent.matched == false)
                    {
                        depths.Add(adjacent, depths[node] + 1);
                        return (depths, adjacent, true);
                    }
                    if (depths.ContainsKey(adjacent) == false)
                    {
                        queue.Enqueue(adjacent);
                        depths.Add(adjacent, depths[node] + 1);
                    }
                    else if (depths[adjacent] > depths[node] + 1)
                    {
                        queue.Enqueue(adjacent);
                        depths[adjacent] = depths[node] + 1;
                    }
                }
            }
            return (depths, new Node(), false); //if this happens, the unmatched node on the right side has not been found
        }
    }
}