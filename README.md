# Maximum-matching-problem
The "maximum matching" problem is one of the problems in graph theory and specifically concerns bipartite graphs. First, I will explain some basic concepts:

Bipartite graph: A graph whose vertices can be partitioned into two disjoint sets such that all edges lead from one set to the other.

The "maximum matching" problem is to find the largest possible set of edges between the vertices of two sides of a bipartite graph, where it is true that only one edge (in some cases more, but always limited) can lead from each vertex.

# This is what maximum matching could looks like. 
<img width="284" alt="283612789-fb765e5f-ae52-4bc1-b0ed-55a03aa8d58b" src="https://github.com/Otasmacour/Maximum-matching-problem/assets/111227700/c52fca16-28ab-4dd1-8d38-39e3de31d855">
<img width="290" alt="graph1" src="https://github.com/Otasmacour/Maximum-matching-problem/assets/111227700/a49c94c5-f395-4133-8ffd-c286ab35e93b">

# Hopcroft–Karp algorithm
The Hopcroft-Karp algorithm is used to find the maximum matching in a bipartite graph. It starts with an empty pairing and gradually finds paths that increase the size of the pairing. It uses BFS to find alternate paths and DFS to augment them. The algorithm iterates until alternate paths are found. For this problem, it is always given between which vertices an edge can lead.

# What the input should look like
The input describes a bipartite graph , in the following format:
- On the first line is the number of problems (the right side nodes)
- On the second line is the n number of agents (the left side nodes)
- On n lines are numbers e, that tell, how many edges are coming out of the nth node, followed by the e Indexes of the right vertexes, where the edge is pointing
# Example of correct input
```txt
3
3
2 0 2
1 1
1 0
```
# What does the output look like
- On the first line is the result, that tells us, what is the maximum matching in the graph
- The e lines (number of edges in the graph) contain information that informs us about which edges are used
# What the output for the above input looks like
```txt
3
From 0 to 0' - False
From 0 to 2' - True
From 1 to 1' - True
From 2 to 0' - True
```



