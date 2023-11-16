using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumMatchingProblem
{
    class Node
    {
        public int index;
        public bool matched;
        public NodeType nodeType;
        public Dictionary<Node, Flow> neighbours = new Dictionary<Node, Flow>();
    }
}