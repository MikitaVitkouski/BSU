#include <iostream>
#include <vector>
#include <cstdlib>
#include <ctime>
#include <pthread.h>
#include <algorithm>
#include <unistd.h>

class MarkerThread {
public:
    MarkerThread(int markerNumber, std::vector<int>& array, int arraySize, pthread_mutex_t& arrayMutex, pthread_cond_t& startCond, pthread_cond_t& continueCond)
        : markerNumber(markerNumber), array(array), arraySize(arraySize), arrayMutex(arrayMutex), startCond(startCond), continueCond(continueCond), isTerminated(false) {}

    void start() {
        pthread_create(&thread, NULL, &MarkerThread::run, this);
    }

    void terminate() {
        {
            pthread_mutex_lock(&arrayMutex);
            isTerminated = true;
            pthread_mutex_unlock(&arrayMutex);
        }
        pthread_cond_signal(&continueCond);
        pthread_join(thread, NULL);
        std::cout << "Marker " << markerNumber << ": Thread terminated" << std::endl;
    }

public:
    static void* run(void* arg) {
        MarkerThread* instance = static_cast<MarkerThread*>(arg);
        instance->threadRun();
        return NULL;
    }

private:
    int markerNumber;
    std::vector<int>& array;
    int arraySize;
    pthread_t thread;
    pthread_mutex_t& arrayMutex;
    pthread_cond_t& startCond;
    pthread_cond_t& continueCond;
    bool isTerminated;

    void threadRun() {
        std::cout << "Marker " << markerNumber << ": Thread started" << std::endl;

        srand(static_cast<unsigned int>(markerNumber));

        pthread_mutex_lock(&arrayMutex);
        pthread_cond_wait(&startCond, &arrayMutex);
        pthread_mutex_unlock(&arrayMutex);

        while (true) {
            int randomNumber = rand();
            int index = randomNumber % arraySize;

            pthread_mutex_lock(&arrayMutex);
            if (array[index] == 0) {
                usleep(5000); // Используем usleep вместо Sleep
                array[index] = markerNumber;
                usleep(5000);

                std::cout << "Marker " << markerNumber << ": Marked element at index " << index << std::endl;
            }
            else {
                std::cout << "Marker " << markerNumber << ": Element at index " << index << " is already marked" << std::endl;
                std::cout << "Marker " << markerNumber << ": Signaling main thread about inability to continue" << std::endl;
                pthread_cond_signal(&continueCond);
                pthread_cond_wait(&startCond, &arrayMutex);

                if (isTerminated) {
                    pthread_mutex_unlock(&arrayMutex);
                    break;
                }
            }
            pthread_mutex_unlock(&arrayMutex);

            pthread_mutex_lock(&arrayMutex);
            pthread_cond_wait(&continueCond, &arrayMutex);

            if (isTerminated) {
                pthread_mutex_unlock(&arrayMutex);
                break;
            }
            pthread_mutex_unlock(&arrayMutex);
        }

        std::cout << "Marker " << markerNumber << ": Thread ended" << std::endl;
    }

public:
    bool getTerminationStatus() const {
        return isTerminated;
    }
};

int main() {
    int arraySize, numMarkerThreads;

    std::cout << "Enter array size: ";
    std::cin >> arraySize;

    std::vector<int> array(arraySize, 0);
    pthread_t* threads = NULL;
    pthread_mutex_t arrayMutex = PTHREAD_MUTEX_INITIALIZER;
    pthread_cond_t startCond = PTHREAD_COND_INITIALIZER;
    pthread_cond_t continueCond = PTHREAD_COND_INITIALIZER;
    std::vector<MarkerThread*> markerThreads;
    bool startSignal = false;
    bool continueSignal = true;

    std::cout << "Enter number of marker threads: ";
    std::cin >> numMarkerThreads;

    threads = new pthread_t[numMarkerThreads];

    for (int i = 0; i < numMarkerThreads; ++i) {
        markerThreads.push_back(new MarkerThread(i + 1, array, arraySize, arrayMutex, startCond, continueCond));
        pthread_create(&threads[i], NULL, &MarkerThread::run, markerThreads[i]);
    }

    startSignal = true;
    pthread_cond_broadcast(&startCond);

    while (true) {
        usleep(500000); // Используем usleep вместо Sleep

        std::cout << "Array state: ";
        for (int i = 0; i < arraySize; ++i) {
            std::cout << array[i] << " ";
        }
        std::cout << std::endl;

        int threadToTerminate;
        while (true) {
            std::cout << "Enter marker thread number to terminate (1 to " << numMarkerThreads << "): ";
            std::cin >> threadToTerminate;
            if (threadToTerminate >= 1 && threadToTerminate <= numMarkerThreads && !markerThreads[threadToTerminate - 1]->getTerminationStatus()) {
                break;
            }
            else {
                std::cout << "Invalid thread number or thread already terminated. Please try again." << std::endl;
            }
        }

        pthread_mutex_lock(&arrayMutex);
        continueSignal = true;
        startSignal = true;
        pthread_mutex_unlock(&arrayMutex);
        pthread_cond_broadcast(&continueCond);
        pthread_cond_wait(&startCond, &arrayMutex);
        markerThreads[threadToTerminate - 1]->terminate();

        bool allThreadsTerminated = true;
        for (int i = 0; i < numMarkerThreads; ++i) {
            if (!markerThreads[i]->getTerminationStatus()) {
                allThreadsTerminated = false;
                break;
            }
        }

        if (allThreadsTerminated) {
            break;
        }
    }

    for (int i = 0; i < numMarkerThreads; ++i) {
        pthread_join(threads[i], NULL);
        delete markerThreads[i];
    }

    delete[] threads;

    return 0;
}