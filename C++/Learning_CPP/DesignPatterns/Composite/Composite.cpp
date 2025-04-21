#include <iostream>
#include <memory>
#include <string>
#include <vector>

class FileSystemItem {
public:
	virtual void print(int ident = 0) const = 0;
	virtual ~FileSystemItem() = default;
};

class File : public FileSystemItem {
private:
	std::string name;
public:
	File(const std::string& name) : name(name) { }

	void print(int indent = 0) const override {
		std::cout << std::string(indent, ' ') << "file " << name << "\n";
	}
};



int main() {


	return 0;
}