Write a program to control access of parallel processes to a file through named channels.

The formulation of the problem.

1. Develop a server process that performs the following actions.
1.1. Creates a binary file whose entries have the following structure:

struct employee
{
int num; // employee identification number
char name[10]; // employee name
double hours; // number of hours worked
};

The file name and student data are entered from the console.

1.2. Outputs the created file to the console.
1.3. Launches Client Client processes that access the file via a named
channel. The number of client processes is entered from the console.
1.4. Serves the requests of client processes as follows:
- if the client process requests a modification of a file record, access to this file record is blocked for other client processes until the modification of the record by the client is completed;
- if the client process requests to read a file record, then access to this record for other client processes:
- is not blocked if they also request access to read data;
- blocked if they request write access to the data.
1.5. After the completion of all client processes, it outputs a modified file to the console.
1.6. On command from the console, it completes its work.

2. Develop a Client-Client process that performs the following actions:
2.1. Performs a cycle:
2.1.1. Requests execution of one of the operations from the console:
- modification of the file entry;
- reading a record;
- exit the loop;
2.1.2. After entering the required data, performs this operation.
2.2. Access to the file records is carried out by the key, which is the employee ID.
2.3. When modifying a record, the client process performs the following actions:
2.3.1. Requests a record key;
2.3.2. Sends a request to the server;
2.3.3. Outputs the record received from the server to the console;
2.3.4. Requests new field values;
2.3.5. Sends the modified record to the server on command from the console;
2.3.6. Terminates access to the record by command from the console.
2.4. When reading a record, the client process performs the following actions:
2.3.1. Requests a record key;
2.3.2. Sends a request to the server;
2.3.3. Outputs the record received from the server to the console;
2.3.4. Terminates access to the record by command from the console.

!!!A simplified version of laboratory work. Solve the task for a single process Server and a single Client process.
