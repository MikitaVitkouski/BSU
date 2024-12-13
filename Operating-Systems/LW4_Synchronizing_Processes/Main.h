#include <iostream>
#include <fstream>
#include <string>
#include <thread>
#include <mutex>
#include <condition_variable>

const int MAX_MESSAGE_LENGTH = 20;
const int NUM_ENTRIES = 1;

extern std::mutex fileMutex;
extern std::condition_variable senderCondition;
extern std::condition_variable receiverCondition;
extern bool senderReady;
extern bool messageReceived;

void receiver(const std::string& file_name);
void sender(const std::string& file_name);