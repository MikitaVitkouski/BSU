#include <iostream>
#include <fstream>
#include <windows.h>
#include <vector>
#include <string>
#include "employee.h"

std::string file_name;
int number_of_employees;
std::vector<employee> emps;
int number_of_clients;
std::vector<HANDLE> hSemaphore;

DWORD WINAPI operations(LPVOID pipe)
{
    HANDLE hPipe = (HANDLE)pipe;
    DWORD dwBytesRead;
    DWORD dwBytesWrite;

    int message;
    int chosen_option;
    employee emp_to_push;
    bool checker;
    int ID;
    bool check;
    int msg;

    while (true)
    {
        if (!ReadFile(hPipe, &message, sizeof(message), &dwBytesRead, NULL))
            return 0;

        ID = message / 10;
        chosen_option = message % 10;
        check = false;

        for (int i = 0; i < number_of_employees; i++)
        {
            if (emps[i].num == ID)
            {
                ID = i;
                check = true;
            }
        }

        WriteFile(hPipe, &check, sizeof(check), &dwBytesWrite, NULL);

        if (!check)
            continue;

        if (chosen_option == 1)
        {
            for (int i = 0; i < number_of_clients; i++)
                WaitForSingleObject(hSemaphore[ID], INFINITE);

            emp_to_push = emps[ID];

            checker = WriteFile(hPipe, &emp_to_push, sizeof(employee), &dwBytesWrite, NULL);

            if (checker)
                std::cout << "Data to modify was sent.\n";
            else
                std::cout << "Data to modify wasn't sent.\n";

            ReadFile(hPipe, &emp_to_push, sizeof(employee), &dwBytesWrite, NULL);

            emps[ID] = emp_to_push;

            std::ofstream fout(file_name);

            for (const auto& emp : emps)
                fout << emp.num << " " << emp.name << " " << emp.hours << "\n";

            fout.close();

            ReadFile(hPipe, &msg, sizeof(msg), &dwBytesWrite, NULL);

            if (msg == 1)
                for (int i = 0; i < number_of_clients; i++)
                    ReleaseSemaphore(hSemaphore[ID], 1, NULL);
        }
        else if (chosen_option == 2)
        {
            WaitForSingleObject(hSemaphore[ID], INFINITE);

            emp_to_push = emps[ID];

            checker = WriteFile(hPipe, &emp_to_push, sizeof(employee), &dwBytesWrite, NULL);

            if (checker)
                std::cout << "Data to read was sent.\n";
            else
                std::cout << "Data to read wasn't sent.\n";

            ReadFile(hPipe, &msg, sizeof(msg), &dwBytesWrite, NULL);

            if (msg == 1)
                ReleaseSemaphore(hSemaphore[ID], 1, NULL);
        }
    }

    DisconnectNamedPipe(hPipe);
    CloseHandle(hPipe);
}

int main()
{
    std::cout << "Enter file name:\n";
    std::cin >> file_name;

    std::cout << "Enter number of employees:\n";
    std::cin >> number_of_employees;

    emps.resize(number_of_employees);

    for (int i = 0; i < number_of_employees; i++)
    {
        std::cout << "Enter " << i + 1 << " employee ID:\n";
        std::cin >> emps[i].num;

        std::cout << "Enter employee name:\n";
        std::wcin >> emps[i].name;

        std::cout << "Enter employee hours:\n";
        std::cin >> emps[i].hours;
    }

    std::ofstream fout(file_name);

    for (const auto& emp : emps)
        fout << emp.num << " " << emp.name << " " << emp.hours << "\n";

    fout.close();

    std::ifstream fin(file_name);

    int ID;
    std::string name;
    double hours;

    for (int i = 0; i < number_of_employees; i++)
    {
        fin >> ID >> name >> hours;
        std::cout << "\nID of employee: " << ID << "\nName of employee: " << name << "\nHours of employee: " << hours << "\n";
    }

    fin.close();

    std::cout << "Enter number of clients:\n";
    std::cin >> number_of_clients;

    hSemaphore.resize(number_of_employees);

    for (int i = 0; i < number_of_employees; i++)
        hSemaphore[i] = CreateSemaphore(NULL, number_of_clients, number_of_clients, nullptr);

    for (int i = 0; i < number_of_clients; ++i)
    {
        STARTUPINFO si;
        PROCESS_INFORMATION pi;
        std::string cmd = "Named_pipe_client.exe";
        LPSTR clientCmdLine = const_cast<LPSTR>(cmd.c_str());

        ZeroMemory(&si, sizeof(STARTUPINFO));
        si.cb = sizeof(STARTUPINFO);

        if (CreateProcessA(NULL, clientCmdLine, NULL, NULL, TRUE, CREATE_NEW_CONSOLE, NULL, NULL, &si, &pi))
        {
            CloseHandle(pi.hProcess);
            CloseHandle(pi.hThread);
        }
        else
        {
            std::cout << "Failed to create process. Error code: " << GetLastError() << std::endl;
        }
    }

    WaitForMultipleObjects(number_of_clients, hSemaphore.data(), TRUE, INFINITE);

    std::vector<HANDLE> hPipe(number_of_clients);
    std::vector<HANDLE> hThreads(number_of_clients);

    for (int i = 0; i < number_of_clients; i++)
    {
        hPipe[i] = CreateNamedPipe("\\\\.\\pipe\\pipe_name", PIPE_ACCESS_DUPLEX, PIPE_TYPE_MESSAGE | PIPE_READMODE_MESSAGE | PIPE_WAIT, PIPE_UNLIMITED_INSTANCES,
            0, 0, INFINITE, NULL);

        if (hPipe[i] == INVALID_HANDLE_VALUE)
        {
            std::cout << "Creation of the named pipe failed.\n The last error code: " << GetLastError() << "\n";
            std::cout << "Press any char to finish server: ";
            std::getchar();
            return 0;
        }

        if (!ConnectNamedPipe(hPipe[i], (LPOVERLAPPED)NULL))
        {
            std::cout << "The connection failed.\nThe last error code: " << GetLastError() << "\n";
            CloseHandle(hPipe[i]);

            std::cout << "Press any char to finish the server: ";
            std::getchar();
            return 0;
        }

        hThreads[i] = CreateThread(NULL, 0, operations, static_cast<LPVOID>(hPipe[i]), 0, NULL);
    }

    WaitForMultipleObjects(number_of_clients, hThreads.data(), TRUE, INFINITE);

    std::cout << "All clients have ended their work.";

    fin.open(file_name);

    for (int i = 0; i < number_of_employees; i++)
    {
        fin >> ID >> name >> hours;
        std::cout << "\nID of employee: " << ID << "\nName of employee: " << name << "\nHours of employee: " << hours << "\n";
    }

    fin.close();

    std::cout << "Press any char to finish the server: \n";
    std::getchar();

    return 0;
}