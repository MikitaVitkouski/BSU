The input consists of two character sequences A and B. Each sequence is non-empty, consists of lowercase Latin letters, and has a length of no more than 1000 characters. The penalty is determined as follows:

- Deleting a character from sequence A equals x points.
- Inserting a character into sequence A equals y points.
- Replacing a character in sequence A with any other character equals z points.

The input is formatted as follows:
- The first three lines contain the integers x, y, and z, respectively. All numbers are positive integers and do not exceed 1,000,000.
- The next two lines contain the character sequences A and B (the elements of the sequence are of type string).

Output:

Output the minimum total penalty.

Example:

in.txt:

```bash
2

3

1

abcd

bce
```
out.txt:

```bash
3
```
