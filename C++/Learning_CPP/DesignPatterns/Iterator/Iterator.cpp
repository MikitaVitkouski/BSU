#include <iostream>
#include <memory>
#include <string>
#include <vector>

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

class BookCollection : public IBookCollection {
private:
	std::vector<Book> books;
public:
	void addBook(const Book& book) {
		books.push_back(book);
	}

	const std::vector<Book>& getBooks() const {
		return books;
	}

	std::unique_ptr<IIterator<Book>> createIterator() override;
};

class BookIterator : public IIterator<Book> {
private:
	const std::vector<Book>& books;
	size_t position = 0;
public:
	BookIterator(const std::vector<Book>& books) : books(books) { }

	bool hasNext() override {
		return position < books.size();
	}

	Book next() override {
		return books[position++];
	}
};

std::unique_ptr<IIterator<Book>> BookCollection::createIterator() {
	return std::make_unique<BookIterator>(this->books);
}

int main() {
	BookCollection library;
	
	library.addBook(Book("Clean Code"));
	library.addBook(Book("Design Patterns"));
	library.addBook(Book("Clean Agile"));

	auto iterator = library.createIterator();

	std::cout << "Books in library:\n";
	while (iterator->hasNext()) {
		Book book = iterator->next();
		std::cout << "- " << book.getTitle() << "\n";
	}

	/*Output:
	Books in library:
	- Clean Code
	- Design Patterns
	- Clean Agile
	*/

	return 0;
}