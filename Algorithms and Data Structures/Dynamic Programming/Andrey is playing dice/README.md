After passing the exam in mathematics, Andrey decided to play dice.He has N cubes, each characterized by the values A_i and B_i.
At the same time, each cube has its number written on it.Andrey wants to build a tower of N cubes, and all the cubes should go in order,
and the lowest cube should be the cube with the number 1. Initially, there are $N$ towers of one cube on the floor. Andrey can connect two turrets,
provided that after connecting these turrets, the cubes in the resulting turret will go in order (i, i+1, etc.
A cube with a smaller number should have a cube with a larger number).Since these are unusual cubes, you need to stroke the cat to connect the turrets.
Let l be the cube with the smallest number among all the cubes in the two connected towers, and r be the one with the maximum.
To connect the turrets, Andrey needs to stroke the cat A_l * B_r once.

In order not to torment the poor animal, Andrey needs to know: what is the minimum number of times to stroke the cat in order to assemble a tower of N$cubes?

Input:

The input in the first line is a single positive integer N <= 500 — the number of cubes.Next, two positive integers A_i <= 10^7 and B_i <= 10^7 follow in N lines.

Output: 

Output a single non—negative integer - the answer to the problem.

Example:

Standard input:

3
34 29
29 4
4 15

Standard output:

646