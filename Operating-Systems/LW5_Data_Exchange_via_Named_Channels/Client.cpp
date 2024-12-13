#include <iostream>
#include <string>
#include <windows.h>
#include "employee.h"

int main()
{
    HANDLE hStartEvent = OpenEvent(EVENT_MODIFY_STATE, FALSE, "Process Started");

    if (hStartEvent == NULL)
    {
        std::wcout << L"Open event failed. \nEnter any char to exit.\n";
        std::wcin.get();
        return GetLastError();
    }

    SetEvent(hStartEvent);

    HANDLE hPipe = CreateFile("\\\\.\\pipe\\pipe_name", GENERIC_WRITE | GENERIC_READ, 0, NULL, OPEN_EXISTING, 0, NULL);

    if (hPipe == INVALID_HANDLE_VALUE)
    {
        std::wcout << L"Creation of the named pipe failed.\n The last error code: " << GetLastError() << L"\n";
        std::wcout << L"Press any char to finish server: ";
        std::wcin.get();
        return 0;
    }

    std::wstring chosen_option;
    DWORD dwBytesWritten;
    DWORD dwBytesReaden;
    int ID;
    int message_to_send;
    bool checker;
    employee emp;

    while (true)
    {
        ID = 0;
        std::wcout << L"Choose option:\n 1. Modify data\n 2. Read data\n 3. Exit\n";
        std::wcin >> chosen_option;

        if (chosen_option == L"1")
        {
            std::wcout << L"Enter ID of employee:\n";
            std::wcin >> ID;

            message_to_send = ID * 10 + std::stoi(chosen_option);

            checker = WriteFile(hPipe, &message_to_send, sizeof(message_to_send), &dwBytesWritten, NULL);

            if (checker)
                std::wcout << L"Message was sent.\n";
            else
                std::wcout << L"Message wasn't sent.\n";

            bool check_is_correct;

            ReadFile(hPipe, &check_is_correct, sizeof(check_is_correct), &dwBytesReaden, NULL);

            if (!check_is_correct)
            {
                std::wcout << L"ID is incorrect. Try again.\n";
                continue;
            }

            emp = {};

            if (!ReadFile(hPipe, &emp, sizeof(employee), &dwBytesReaden, NULL))
            {
                std::wcout << L"Data reading from the named pipe failed.\n" << L"The last error code: " << GetLastError() << L"\n";
                std::wcout << L"Press any char to finish server: \n";
                std::wcin.get();
                return 0;
            }

            std::wcout << L"ID of employee: " << emp.num << L"\nName of employee: " << emp.name << L"\nHours of employee: " << emp.hours << L"\n";

            std::wcout << L"Enter new Name:\n";
            std::wcin >> emp.name;

            std::wcout << L"Enter new Hours:\n";
            std::wcin >> emp.hours;

            std::wcout << L"Press any key to send modified record to Server\n";
            std::wcin.get();

            checker = WriteFile(hPipe, &emp, sizeof(employee), &dwBytesWritten, NULL);

            if (checker)
                std::wcout << L"Message was sent.\n";
            else
                std::wcout << L"Message wasn't sent.\n";

            std::wcout << L"Press any key to end the selected option\n";
            std::wcin.get();

            message_to_send = 1;
            WriteFile(hPipe, &message_to_send, sizeof(message_to_send), &dwBytesWritten, NULL);
        }
        else if (chosen_option == L"2")
        {

            std::wcout << L"Enter ID of employee:\n";
            std::wcin >> ID;

            message_to_send = ID * 10 + std::stoi(chosen_option);
            checker = WriteFile(hPipe, &message_to_send, sizeof(message_to_send), &dwBytesWritten, NULL);

            if (checker)
                std::wcout << L"Message was sent.\n";
            else
                std::wcout << L"Message wasn't sent.\n";

            bool check_is_correct;

            ReadFile(hPipe, &check_is_correct, sizeof(check_is_correct), &dwBytesReaden, NULL);

            if (!check_is_correct)
            {
                std::wcout << L"ID is incorrect. Try again.\n";
                continue;
            }

            emp = {};

            if (!ReadFile(hPipe, &emp, sizeof(employee), &dwBytesReaden, NULL))
            {
                std::wcout << L"Data reading from the named pipe failed.\n" << L"The last error code: " << GetLastError() << L"\n";
                std::wcout << L"Press any char to finish server: \n";
                std::wcin.get();
                return 0;
            }

            std::wcout << L"ID of employee: " << emp.num << L"\nName of employee: " << emp.name << L"\nHours of employee: " << emp.hours << L"\n";
            std::wcout << L"Press any key to end the selected optionn\n";
            std::wcin.get();

            message_to_send = 1;
            WriteFile(hPipe, &message_to_send, sizeof(message_to_send), &dwBytesWritten, NULL);
        }
        else if (chosen_option == L"3")
            break;
        else
            std::wcout << L"Incorrect input.Try again\n";
    }

    return 0;
}