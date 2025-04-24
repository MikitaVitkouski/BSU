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

class Book {
private:
	std::string title;
public:
	Book(const std::string& title) : title(title) { }
	std::string getTitle() const {
		return title;
	}
};

class IBookCollection {
public:
	virtual ~IBookCollection() = default;
	virtual std::unique_ptr<IIterator<Book>> createIterator() = 0;
};



int main() {


	return 0;
}