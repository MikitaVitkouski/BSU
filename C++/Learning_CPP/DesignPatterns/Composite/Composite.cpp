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

class Folder : public FileSystemItem {
private:
	std::string name;
	std::vector <std::shared_ptr<FileSystemItem>> items;
public:
	Folder(const std::string& name) : name(name) { }

	void add(const std::shared_ptr<FileSystemItem>& item) {
		items.push_back(item);
	}

	void print(int indent = 0) const override {
		std::cout << std::string(indent, ' ') << "folder " << name << "\n";
		for (const auto& item : items) {
			item->print(indent + 2);
		}
	}
};

int main() {
	auto root = std::make_shared<Folder>("Documents");
	auto resume = std::make_shared<File>("Resume.docx");
	auto budget = std::make_shared<File>("Budget.xlsx");

	auto projects = std::make_shared<Folder>("Projects");
	auto project1 = std::make_shared<File>("Project1.txt");
	auto project2 = std::make_shared<File>("Project2.txt");

	projects->add(project1);
	projects->add(project2);

	root->add(resume);
	root->add(budget);
	root->add(projects);

	root->print();

	/* Output:
	folder Documents
		file Resume.docx
		file Budget.xlsx
		folder Projects
			file Project1.txt
			file Project2.txt
	*/

	return 0;
}