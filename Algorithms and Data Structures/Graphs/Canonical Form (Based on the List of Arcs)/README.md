Given a directed graph that forms a rooted tree, where the vertices of the graph are numbered from 1 to n, and the arcs are directed from the root to the leaves, output the canonical representation of this tree.

The canonical representation of a rooted tree with n vertices is an array P of size n, where pi is the parent of vertex i, and if vertex i is the root of the tree, then pi is set to zero.

Input:
The first line contains an integer n (1≤n≤100000). The next n−1 lines describe the arcs of the graph. An arc from vertex u to vertex v is defined by the pair of numbers u and v, separated by a space (1≤u,v≤n). It is guaranteed that the graph represents a rooted tree.

Output:
Print n numbers — the elements of the array P.
