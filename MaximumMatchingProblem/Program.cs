using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumMatchingProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HopcroftKarp hopcroftKarp = new HopcroftKarp();
            int maximumMatching = hopcroftKarp.Solve(@"\input2.txt");
            Console.WriteLine(maximumMatching);
            Console.ReadLine();
        }
    }
}