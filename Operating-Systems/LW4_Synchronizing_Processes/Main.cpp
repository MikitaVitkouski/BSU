#include <iostream>
#include <fstream>
#include <string>
#include <thread>
#include <mutex>
#include <condition_variable>

const int MAX_MESSAGE_LENGTH = 20;
const int NUM_ENTRIES = 1;

std::mutex fileMutex;
std::condition_variable senderCondition;
std::condition_variable receiverCondition;
bool senderReady = false;
bool messageReceived = false;

void receiver(const std::string& file_name) {
    std::ifstream file(file_name, std::ios::binary);

    for (int i = 0; i < NUM_ENTRIES; ++i) {
        std::unique_lock<std::mutex> lock(fileMutex);

        // Wait for a signal from the sender
        receiverCondition.wait(lock, [] { return senderReady; });

        // Read the message from the file
        std::string message;
        std::getline(file, message, '\0');  // Read until null character
        std::cout << std::endl << "Received message: " << message << std::endl;

        // Signal the sender that the message has been received
        messageReceived = true;
        senderCondition.notify_one();
    }
}

void sender(const std::string& file_name) {
    std::ofstream file(file_name, std::ios::binary);

    {
        std::unique_lock<std::mutex> lock(fileMutex);
        senderReady = true;
        receiverCondition.notify_one();
    }

    // Get input message from the console
    std::string message;
    std::cout << "Enter message (or type 'exit' to finish): ";
    std::getline(std::cin, message);

    // Write the message to the file
    file.write(message.c_str(), message.length() + 1);  // Include the null character

    {
        std::unique_lock<std::mutex> lock(fileMutex);
        // Signal the receiver that a message has been sent
        senderCondition.notify_one();
        // Wait for a signal from the receiver indicating that the message has been received
        receiverCondition.wait(lock, [] { return messageReceived; });
    }
}

int main() {
    const std::string file_name = "shared_messages.bin";

    std::thread receiver_thread(receiver, file_name);
    std::thread sender_thread(sender, file_name);

    receiver_thread.join();
    sender_thread.join();

    return 0;
}