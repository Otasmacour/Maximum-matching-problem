# Maximum-matching-problem
Solving this problem with different algorithms.

The "maximum matching" problem is one of the problems in graph theory and specifically concerns bipartite graphs. First, I will explain some basic concepts:

Bipartite graph: A graph whose vertices can be partitioned into two disjoint sets such that all edges lead from one set to the other.

The "maximum matching" problem is to find the largest possible set of edges between the vertices of two sides of a bipartite graph, where it is true that only one edge (in some cases more, but always limited) can lead from each vertex.
# Hopcroft–Karp algorithm
The Hopcroft-Karp algorithm is used to find the maximum matching in a bipartite graph. It starts with an empty pairing and gradually finds paths that increase the size of the pairing. It uses BFS to find alternate paths and DFS to augment them. The algorithm iterates until alternate paths are found.


