Find the largest half-path in which the sum of the keys of the extreme vertices is minimal. Delete (by right deletion) the root vertex of this half-path.

Input:

The input file contains a sequence of numbers — the keys of the vertices in the order they are added to the tree. It is guaranteed that there are at least two vertices in the tree.

in.txt:

50
40
60
30
45
27
35
46

Output:

The output file must contain a sequence of vertex keys obtained by a direct left-hand traversal of the resulting tree.

out.txt:

50
45
30
27
35
46
60
