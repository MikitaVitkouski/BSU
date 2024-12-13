First, a Huffman code tree is constructed. Let the original alphabet consist of n symbols, where the i-th symbol occurs pi times in the input text. Initially, all symbols are considered active nodes of the future tree, and the i-th node is labeled with the value pi. At each step, we take two active nodes with the smallest labels, create a new node labeling it with the sum of the labels of these nodes, and make it their parent. The new node becomes active, and its two children are removed from the list of active nodes. This process is repeated multiple times until only one active node remains, which is considered the root of the tree.

Note that the symbols of the alphabet are represented by the leaves of this tree. For each leaf (symbol), the length of its Huffman code is equal to the length of the path from the root of the tree to that leaf. The code itself is constructed as follows: for each internal node of the tree, consider two edges leading from it to its children. Assign label 0 to one edge and label 1 to the other. The code for each symbol is a sequence of zeros and ones along the path from the root to the leaf.

The task is to calculate the length of the text after encoding it using the Huffman method. The text itself is not given; only the number of times each symbol appears in the text is known. This is sufficient to solve the problem because the code length depends only on the frequency of symbol appearances.

Input:

The first line contains an integer n (2 ≤ n ≤ 500,000).
The second line contains n numbers pi — the frequencies of symbol occurrences in the text (1 ≤ pi ≤ 10^9, pi ≤ pi + 1 for each i from 1 to n − 1).

Output:

Output a single number — the length (in bits) of the encoded text.

Example:

huffman.in:

6

1 1 2 2 5 8


huffman.out:

42
