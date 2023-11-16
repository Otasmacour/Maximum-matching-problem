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
        List<Node> unMatchedNodes;
        BipartiteGraph bipartiteGraph;
        public HopcroftKarp(string inputPath)
        {
            bipartiteGraph = new BipartiteGraph(Directory.GetParent(Environment.CurrentDirectory)?.Parent?.FullName + inputPath);
            unMatchedNodes = new List<Node>(bipartiteGraph.leftNodes);
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
