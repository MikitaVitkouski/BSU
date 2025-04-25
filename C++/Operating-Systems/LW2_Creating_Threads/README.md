Write a program for a console process that consists of three threads: main, min_max, and average.

The main thread should perform the following actions:

1. Create an array of integers, with the size and elements input from the console.
2. Create the min_max and average threads.
3. Wait for the min_max and average threads to finish.
4. Replace the maximum and minimum elements of the array with the average value of the array elements. Display the obtained results on the console.
5. Finish execution.

The min_max thread should perform the following actions:

1. Find the minimum and maximum elements of the array and display them on the console. After each comparison of elements, "sleep" for 7 milliseconds.
2. Finish its execution.

The average thread should perform the following actions:

1. Find the arithmetic mean of the array elements and display it on the console. After each summation operation of elements, "sleep" for 12 milliseconds.
2. Finish its execution.
