#define BOOST_TEST_MODULE MainTests
#include <boost/test/included/unit_test.hpp>
#include <iostream>
#include <sstream>
#include <thread>
#include <chrono>
#include <fstream>
#include <mutex>
#include <condition_variable>
#include "Main.h"

const std::string sender_file = "sender_test.txt";
const std::string receiver_file = "receiver_test.txt";

BOOST_AUTO_TEST_SUITE(MyTestSuite)

BOOST_AUTO_TEST_CASE(SenderReceiverTest) {
    std::ofstream sender_test_file(sender_file, std::ios::binary);
    std::ofstream receiver_test_file(receiver_file, std::ios::binary);

    std::ostringstream sender_output;
    std::ostringstream receiver_output;

    std::streambuf* coutBuffer = std::cout.rdbuf();
    std::streambuf* cinBuffer = std::cin.rdbuf();
    std::cout.rdbuf(sender_output.rdbuf());
    std::cin.rdbuf(receiver_output.rdbuf());

    std::thread sender_thread(sender, sender_file);
    std::thread receiver_thread(receiver, receiver_file);

    sender_thread.join();
    receiver_thread.join();

    std::cout.rdbuf(coutBuffer);
    std::cin.rdbuf(cinBuffer);

    sender_test_file.close();
    receiver_test_file.close();

    std::string received_message = receiver_output.str();
    BOOST_CHECK_EQUAL(received_message, "Enter message (or type 'exit' to finish): \nReceived message: Hello, Boost.Test!\n");
}

BOOST_AUTO_TEST_SUITE_END()