using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumMatchingProblem
{
    class BipartiteGraph
    {
        public Node source;
        public Node sink;
        public List<Node> rightNodes = new List<Node>();
        public List<Node> leftNodes = new List<Node>();
        public BipartiteGraph(string inputPath)
        {
            List<string> input = LoadingInput(inputPath);
            CreateGraph(input);
            PrintFlows(leftNodes);
        }
        List<string> LoadingInput(string path)
        {
            List<string> input = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    input.Add(s);
                }
            }
            return input;
        }
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
        void CreateGraph(List<string> input)
        {
            int index = 0;
            int rightNumber = int.Parse(input[index]); index++;
            int leftNumber = int.Parse(input[index]); index++;
            for (int i = 0; i < rightNumber; i++)
            {
                Node node = new Node();
                node.nodeType = NodeType.RightSide;
                node.index = i;
                rightNodes.Add(node);
            }
            for (int i = 0; i < leftNumber; i++)
            {
                Node node = new Node();
                node.nodeType = NodeType.LeftSide;
                node.index = i;
                leftNodes.Add(node);
            }
            for (int i = 0; i < leftNumber; i++)
            {
                string line = input[index].Trim(' '); index++;
                List<int> lineOfNumbers = line.Split(' ').Select(int.Parse).ToList();
                int numberOfEdges = lineOfNumbers[0];
                for (int j = 1; j < numberOfEdges + 1; j++)
                {
                    int indexOfRight = lineOfNumbers[j];
                    Node start = leftNodes[i];
                    Node destination = rightNodes[indexOfRight];
                    Flow flow = new Flow();
                    flow.isUsed = false;
                    start.neighbours.Add(destination, flow);
                    destination.neighbours.Add(start, flow);
                }
            }
        }
    }
}
