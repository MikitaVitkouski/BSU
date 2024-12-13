Develop a console program Main and two utility programs (service programs) Creator and Reporter that perform the following actions.

Utility Creator creates a binary file, the name and number of records of which are obtained via the command line. The file records are entered from the console and have the following structure:

struct employee
{
    int num;          // employee's ID
    char name[10];    // employee's name
    double hours;     // hours worked
};

Utility Reporter creates a text file containing an ordered list of employees with their corresponding wages. The report is generated based on the binary file created by the Creator program.

The utility receives the following data via the command line:
1.1. Name of the source binary file.
1.2. Report file name.
1.3. Hourly wage.

The report contains the following lines:
2.1. Header: Report on the file "source binary file name."
2.2. Line: Employee number, employee name, hours worked, salary.
2.3. List of employees line by line. Each line contains information from the corresponding record in the binary file, and the last column of the line is the accrued salary = number of hours worked * hourly wage.

Main program performs the following actions:

Prompts the user for the name of the binary file and the number of records in this file.
Launches the Creator utility, passing the name of the created binary file and the number of records in this file via the command line.
Waits for the Creator utility to finish its work.
Outputs the contents of the created binary file to the console.
Prompts the user for:
a. Report file name.
b. Hourly wage.
Launches the Reporter utility, passing the following via the command line:
a. Name of the source binary file.
b. Report file name.
c. Hourly wage.
Waits for the Reporter utility to finish its work.
Outputs the report to the console.
Completes its execution.
