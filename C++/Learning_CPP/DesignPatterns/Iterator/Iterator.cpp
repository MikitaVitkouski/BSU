#include <iostream>
#include <memory>
#include <string>

template<typename T>
class IIterator {
public:
	virtual ~IIterator() = default;
	virtual bool hasNext() = 0;
	virtual T next() = 0;
};



int main() {


	return 0;
}