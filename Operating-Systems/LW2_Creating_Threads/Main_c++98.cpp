#include <iostream>
#include <vector>
#include <pthread.h>

struct ThreadArgs {
    std::vector<int>* arr;
    int min;
    int max;
    pthread_mutex_t mutex;
    pthread_t minMaxThread;
};

#ifdef _WIN32
#include <windows.h>
#define SLEEP(milliseconds) Sleep(milliseconds)
#else
#include <unistd.h>
#define SLEEP(milliseconds) usleep(milliseconds * 1000)
#endif

void* FindMinMaxThread(void* arg) {
    ThreadArgs* args = static_cast<ThreadArgs*>(arg);
    std::vector<int>& arr = *(args->arr);

    int min = arr[0];
    int max = arr[0];

    for (int i = 1; i < arr.size(); i++) {
        if (arr[i] < min) {
            min = arr[i];
        }
        if (arr[i] > max) {
            max = arr[i];
        }
        SLEEP(7);
    }

    pthread_mutex_lock(&args->mutex);
    args->min = min;
    args->max = max;
    pthread_mutex_unlock(&args->mutex);

    return NULL;
}

void* AverageThread(void* arg) {
    ThreadArgs* args = static_cast<ThreadArgs*>(arg);
    std::vector<int>& arr = *(args->arr);

    int min, max;

    // Wait for the min_max thread to finish
    pthread_join(args->minMaxThread, NULL);

    pthread_mutex_lock(&args->mutex);
    min = args->min;
    max = args->max;
    pthread_mutex_unlock(&args->mutex);

    int sum = 0;
    for (int i = 0; i < arr.size(); i++) {
        sum += arr[i];
        SLEEP(12);
    }

    double average = static_cast<double>(sum) / arr.size();

    pthread_mutex_lock(&args->mutex);
    for (int i = 0; i < arr.size(); i++) {
        if (arr[i] == min || arr[i] == max) {
            arr[i] = static_cast<int>(average);
        }
    }
    pthread_mutex_unlock(&args->mutex);

    return NULL;
}

template<typename T>
void printVector(std::vector<T>& v) {
    for (typename std::vector<T>::const_iterator it = v.begin(); it != v.end(); ++it) {
        std::cout << *it << " ";
    }

    std::cout << std::endl << std::endl;
}

int main() {
    std::vector<int> arr;
    int n;

    // Input the array size and elements
    std::cout << "Enter the array size: ";
    std::cin >> n;
    arr.resize(n);
    std::cout << "Enter the array elements:" << std::endl;
    for (int i = 0; i < n; i++) {
        std::cin >> arr[i];
    }

    // Create the min_max thread
    ThreadArgs args = { &arr, 0, 0, PTHREAD_MUTEX_INITIALIZER };
    args.minMaxThread = pthread_self();
    pthread_create(&args.minMaxThread, NULL, FindMinMaxThread, &args);

    // Perform other operations or wait if needed...

    pthread_join(args.minMaxThread, NULL);  // Wait for the min_max thread to finish

    // Create the average thread
    pthread_t averageThread;
    pthread_create(&averageThread, NULL, AverageThread, &args);

    pthread_join(averageThread, NULL);  // Wait for the average thread to finish

    // Output the result
    std::cout << std::endl;
    printVector(arr);
    std::cout << std::endl;

    return 0;
}