#include <iostream>
#include <vector>
#include <boost/thread.hpp>
#include <boost/thread/condition_variable.hpp>
#include <boost/atomic.hpp>
#include <boost/bind.hpp>
#include <chrono>

template <typename MutexType, typename ConditionVariableType>
class ThreadBase {
public:
    ThreadBase(MutexType& mutex, ConditionVariableType& cv, boost::atomic<bool>& startSignal, boost::atomic<bool>& continueSignal)
        : mutex(mutex), cv(cv), startSignal(startSignal), continueSignal(continueSignal), isTerminated(false) {}

    void start() {
        thread = boost::thread(boost::bind(&ThreadBase::run, this));
    }

    void terminate() {
        {
            boost::lock_guard<MutexType> lock(mutex);
            isTerminated = true;
        }
        cv.notify_all();
        thread.join();
    }

    bool getTerminationStatus() const {
        return isTerminated;
    }

protected:
    virtual void run() = 0;  // Должен быть реализован в производных классах

    MutexType& mutex;
    ConditionVariableType& cv;
    boost::atomic<bool>& startSignal;
    boost::atomic<bool>& continueSignal;
    bool isTerminated;

private:
    boost::thread thread;
};

class MarkerThread : public ThreadBase<boost::mutex, boost::condition_variable> {
public:
    MarkerThread(int markerNumber, std::vector<int>& array, int arraySize, boost::mutex& arrayMutex, boost::condition_variable& cv, boost::atomic<bool>& startSignal, boost::atomic<bool>& continueSignal)
        : ThreadBase(arrayMutex, cv, startSignal, continueSignal), markerNumber(markerNumber), array(array), arraySize(arraySize) {}

protected:
    void run() override {
        std::cout << "Marker " << markerNumber << ": Thread started" << std::endl;

        srand(static_cast<unsigned int>(markerNumber));

        {
            boost::unique_lock<boost::mutex> lock(mutex);
            cv.wait(lock, [&] { return startSignal.load(); });
        }

        while (true) {
            int randomNumber = rand();
            int index = randomNumber % arraySize;

            {
                boost::unique_lock<boost::mutex> lock(mutex);

                if (array[index] == 0) {
                    boost::this_thread::sleep_for(boost::chrono::milliseconds(5));
                    array[index] = markerNumber;
                    boost::this_thread::sleep_for(boost::chrono::milliseconds(5));

                    std::cout << "Marker " << markerNumber << ": Marked element at index " << index << std::endl;
                }
                else {
                    std::cout << "Marker " << markerNumber << ": Element at index " << index << " is already marked" << std::endl;
                    std::cout << "Marker " << markerNumber << ": Signaling main thread about inability to continue" << std::endl;
                    continueSignal.store(false);
                    cv.notify_one();
                    cv.wait(lock, [&] { return startSignal.load() || isTerminated; });

                    if (isTerminated) {
                        break;
                    }
                }
            }

            boost::unique_lock<boost::mutex> lock(mutex);
            cv.wait(lock, [&] { return continueSignal.load() || isTerminated; });

            if (isTerminated) {
                break;
            }
        }

        std::cout << "Marker " << markerNumber << ": Thread ended" << std::endl;
    }

private:
    int markerNumber;
    std::vector<int>& array;
    int arraySize;
};

int main() {
    int arraySize, numMarkerThreads;

    std::cout << "Enter array size: ";
    std::cin >> arraySize;

    std::vector<int> array(arraySize, 0);
    boost::mutex arrayMutex;
    boost::condition_variable cv;
    boost::atomic<bool> startSignal(false);
    boost::atomic<bool> continueSignal(true);

    std::cout << "Enter number of marker threads: ";
    std::cin >> numMarkerThreads;

    std::vector<MarkerThread> markerThreads;

    for (int i = 0; i < numMarkerThreads; ++i) {
        markerThreads.emplace_back(i + 1, array, arraySize, arrayMutex, cv, startSignal, continueSignal);
    }

    for (auto& markerThread : markerThreads) {
        markerThread.start();
    }

    startSignal.store(true);

    while (true) {
        boost::this_thread::sleep_for(boost::chrono::milliseconds(500));

        std::cout << "Array state: ";
        for (int i = 0; i < arraySize; ++i) {
            std::cout << array[i] << " ";
        }
        std::cout << std::endl;

        int threadToTerminate;
        while (true) {
            std::cout << "Enter marker thread number to terminate (1 to " << numMarkerThreads << "): ";
            std::cin >> threadToTerminate;
            if (threadToTerminate >= 1 && threadToTerminate <= numMarkerThreads && !markerThreads[threadToTerminate - 1].getTerminationStatus()) {
                break;
            }
            else {
                std::cout << "Invalid thread number or thread already terminated. Please try again." << std::endl;
            }
        }

        boost::unique_lock<boost::mutex> lock(arrayMutex);
        continueSignal.store(true);
        startSignal.store(true);
        lock.unlock();
        cv.notify_all();
        markerThreads[threadToTerminate - 1].terminate();

        bool allThreadsTerminated = std::all_of(markerThreads.begin(), markerThreads.end(),
            [](const MarkerThread& markerThread) { return markerThread.getTerminationStatus(); });

        if (allThreadsTerminated) {
            break;
        }
    }

    return 0;
}