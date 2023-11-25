Task Description: Write a program for a console process consisting of the main thread and several instances of the marker thread.

The main thread should perform the following actions:
1. Allocate memory for an array of integers, the size of which is input from the console.
2. Initialize the array elements to zero.
3. Prompt for the number of marker threads to launch.
4. Start the specified number of marker thread instances, passing each instance its ordinal number at launch as a parameter.
5. Signal the start of all marker threads.
6. Perform the following actions in a loop:
   6.1. Wait until all marker threads signal that they cannot continue their work.
   6.2. Display the contents of the array on the console.
   6.3. Prompt for the ordinal number of the marker thread to which a signal will be sent to terminate its work.
   6.4. Send a signal to terminate the work of the marker thread whose number was obtained in step 6.3.
   6.5. Wait for the marker thread, to which a signal to terminate work was sent in step 6.4, to finish its work.
   6.6. Display the contents of the array on the console.
   6.7. Signal to continue the work of the remaining marker threads.
7. Finish its work after all marker threads have finished.

The marker thread should perform the following actions:
1. Start working upon receiving a signal from the main thread.
2. Initialize the generation of a sequence of random numbers. Use the srand function, passing its ordinal number as an argument.
3. Work cyclically, performing the following actions on each cycle:
   3.1. Generate a random number using the rand function.
   3.2. Divide this number by the array size using modulo.
   3.3. If the element of the array, whose index is equal to the result of the division, is zero, then perform the following actions:
      3.3.1. Sleep for 5 milliseconds.
      3.3.2. Set its ordinal number in the element whose index was calculated.
      3.3.3. Sleep for 5 milliseconds.
      3.3.4. Continue the execution of cycle 3.
   3.4. Otherwise:
      3.4.1. Display the following information on the console:
         - Its ordinal number;
         - The number of marked elements;
         - The index of the array element that cannot be marked.
      3.4.2. Signal the main thread that it cannot continue its work.
      3.4.3. Wait for a response signal to continue or finish work from the main thread.
4. If a signal to terminate work is received, perform the following actions:
   4.1. Set all elements that it marked in the array to zero.
   4.2. Finish work.
5. If a signal to continue work is received, continue the execution of the cycle from step 3.
