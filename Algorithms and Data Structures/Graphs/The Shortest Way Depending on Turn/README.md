The Cartesian coordinates of the N intersections of the city are given, which are numbered from 1 to N. There is a traffic light at each intersection. Some intersections are connected by two-way (right-hand) roads that intersect only at intersections. For each of the M roads, the non-negative time required to travel along it from one intersection to another is known.

It is necessary to drive from junction A to junction B in the shortest possible time.

The travel time depends on the set of roads being traveled and on the waiting time at intersections. So, if you drove from junction X to junction C on the XC road and want to go further along the CY road, then the waiting time at junction C depends on whether you turn left or not. If you turn left, then the waiting time is DK, where the number D is the number of roads intersecting at the intersection C, and the number K is some constant. If you don't turn left, then the waiting time at the intersection is zero. A U-turn at an intersection is considered a left turn.

Note:

If the car is initially located at an intersection with coordinates (x, y), then it is assumed that it arrived at this point from a point with coordinates (x, y − 1).

Input:

The first line of the input file contains the natural numbers N, M and K (N ≤ 1000, M ≤ 1000, K ≤ 1000).

Each of the following N lines contains a pair of integers x and y (separated by a space), which specify the coordinates of the intersection of the city (|x|, |y| < 1000).

In each of the following M lines there are three numbers p, r and t (separated by spaces), where p and r are the numbers of intersections that the road connects, and the natural number t (t ≤ 1000) is the travel time along it.

The last line of the file contains the numbers A and B of the initial and final intersections, respectively.

Output:

If the path does not exist, then the only line of the output file should contain the message No.
If the path exists, then the message Yes should be displayed in the first line, and in the second — a natural number t — the travel time along the fastest route.

Example:

input.txt:

```bash
6 5 5

4 2

4 0

2 4

4 6

6 4

0 4

1 2 0

3 4 1

1 5 1

1 3 1

6 3 1

2 6
```

output.txt:

```bash
Yes

16
```
