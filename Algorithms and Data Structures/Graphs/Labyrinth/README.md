# **Labyrinth (without intersections on roads)**  

---

## **Problem Statement**

The labyrinth is represented by an adjacency matrix  

\[
C = [C_{i,j}]
\]

of size \( N \times N \),  
where  

\[
C_{i,j} = 1 \quad \text{if room } i \text{ is connected to room } j
\]

and \( C_{i,j} = 0 \) otherwise.  
Each room is numbered from **1** to **N**.  

Some rooms are **entrances**, and others are **exits**.  
Entrances and exits are given by sets:

\[
X = \{ X_1, X_2, \ldots, X_p \}, \quad Y = \{ Y_1, Y_2, \ldots, Y_k \}
\]

It is required to find the **maximum number of people** that can move from any entrance to any exit **without intersecting on roads**, but they **can share rooms**.

---

### **Input Format (input.txt)**

1. The first line contains three integers:  

\[
N, \; p, \; k
\]

where  
- \( N \) — number of rooms \((1 \le N \le 300)\),  
- \( p \) — number of entrances,  
- \( k \) — number of exits.  

2. Then follow \( N \) lines, each containing \( N \) elements of the adjacency matrix \( C \).

3. The next line contains \( p \) distinct integers — the indices of the entrance rooms.

4. The last line contains \( k \) distinct integers — the indices of the exit rooms.  

*No room can be both an entrance and an exit.*

---

### **Output Format (output.txt)**

A single integer —  

\[
\text{the maximum number of people who can pass from entrances to exits}
\]

---

## **Algorithm Description**

### **Overview**

The problem is solved using the **Edmonds–Karp algorithm**,  
which is an implementation of the **Ford–Fulkerson method** for computing the **maximum flow** in a network.

---

### **Step-by-step algorithm**

1. **Convert the labyrinth into a flow network.**
   - Each room → vertex.  
   - Each road → directed edge with capacity **1**  
     (Only one person can move along the same road.)

2. **Add a super source** \( S \) and **a super sink** \( T \):  
   - Connect \( S \) to each entrance with an edge of *infinite capacity*:  
     \[
     c(S, X_i) = \infty
     \]
   - Connect each exit to \( T \) with an edge of *infinite capacity*:  
     \[
     c(Y_j, T) = \infty
     \]
   This ensures that the number of people entering or leaving is not limited by artificial bottlenecks.

3. **Run BFS (Breadth-First Search)** to find an *augmenting path* from \( S \) to \( T \)  
   with available (non-zero) capacities.

4. **Find the minimum capacity** \( \Delta \) along the found path:  
   \[
   \Delta = \min_{(u,v)\in P} c(u,v)
   \]
   This represents how much additional flow can be sent through the path.

5. **Update residual capacities**:  
   \[
   c(u,v) := c(u,v) - \Delta, \quad c(v,u) := c(v,u) + \Delta
   \]

6. **Repeat BFS** until no augmenting path can be found.

7. The **sum of all augmentations** gives the **maximum flow**:  
   \[
   F_{max} = \sum \Delta_i
   \]
   which equals the maximum number of people that can pass through the labyrinth without road intersections.

---