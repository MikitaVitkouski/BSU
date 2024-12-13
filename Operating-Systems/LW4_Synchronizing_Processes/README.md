Write a program to transfer messages between processes via a shared file. The program includes one Receiver process and several processes

Sender. Sender processes send messages to the Receiver process.

Requirements for implementing the Receiver process. The Receiver process should perform the following actions:

0. Enter from the console the name of the binary file and the number of entries in the binary file
that will be used to send messages.
1. Create a binary file for messages. The maximum message length is 20
characters.
2. Enter the number of Sender processes from the console.
3. Start the specified number of Sender processes.
Pass the file name for messages to each Sender process via the command line.
4. Wait for a ready-to-work signal from all Sender processes.
5. Perform cyclically the following actions on the command from the console:
read a message from a binary file or finish your work.

Remark. The Receiver process enters the state of waiting for a new
message to arrive if the command to read a message from an empty binary file is called.

Requirements for the implementation of the Sender process. The Sender process should perform the following actions:

1. Open the file for sending messages. Get the file name from the command line.
2. Send a ready signal to the Receiver process.
3. Perform the following actions cyclically by command from the console:
send a message to the Receiver process or stop its work.

The text of the message is entered from the console. The message length is less than 20 characters.

Remark. The Sender process enters a waiting state if the command to write a message to a binary file filled with messages is called.

Additional requirements: Sending messages via a binary file should be organized as a ring FIFO queue. It means: the Receiver process
should read messages according to the order in which they are sent by processes Sender.

!!!A simplified version of laboratory work. Solve the task for one Receiver process and one Sender process. At the same time, only one message can be transmitted between processes at the same time.
