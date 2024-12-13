Develop a multithreaded application that calculates the product of matrices A (m×n) and B (n×k).
The elements cij of the resulting matrix C = A×B are computed concurrently by p identical threads.
If a thread is already calculating the element cij of matrix C, the next thread starting the calculation chooses to compute the element cij+1 if j<k, and ci+1k if j=k.
After computing an element of the matrix product, the thread checks if there is an element that has not been calculated yet.
If such an element exists, the thread proceeds to calculate it. Otherwise, it sends a user-defined completion message and suspends its execution.
The main thread, upon receiving completion messages from all threads, displays the result on the screen and launches a thread to write the result to the end of a log file.
Each thread should introduce a delay in the execution of calculations to allow all threads to work. Implement thread synchronization through a critical section or a mutex.
