#include <iostream>
#include <fstream>
#include <string>
#include <boost/thread.hpp>
#include <boost/thread/mutex.hpp>
#include <boost/thread/condition_variable.hpp>

const int MAX_MESSAGE_LENGTH = 20;
const int NUM_ENTRIES = 1;

boost::mutex fileMutex;
boost::condition_variable senderCondition;
boost::condition_variable receiverCondition;
bool senderReady = false;
bool messageReceived = false;

void receiver(const std::string& file_name) {
    std::ifstream file(file_name, std::ios::binary);

    for (int i = 0; i < NUM_ENTRIES; ++i) {
        boost::unique_lock<boost::mutex> lock(fileMutex);

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
        boost::unique_lock<boost::mutex> lock(fileMutex);
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
        boost::unique_lock<boost::mutex> lock(fileMutex);
        // Signal the receiver that a message has been sent
        senderCondition.notify_one();
        // Wait for a signal from the receiver indicating that the message has been received
        receiverCondition.wait(lock, [] { return messageReceived; });
    }
}

int main() {
    std::string sender_file;
    std::cout << std::endl << "Enter a sender name: " << std::endl;
    std::cin >> sender_file;
    std::cin.ignore();

    std::string receiver_file;
    std::cout << std::endl << "Enter a receiver name: " << std::endl;
    std::cin >> receiver_file;
    std::cin.ignore();

    boost::thread receiver_thread(boost::bind(receiver, receiver_file));
    boost::thread sender_thread(boost::bind(sender, sender_file));
    receiver_thread.join();
    sender_thread.join();

    return 0;
}