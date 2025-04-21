#include <iostream>
#include <memory>
#include <string>

class DataSource {
	virtual void writeData(const std::string& data) = 0;
	virtual std::string readData() = 0;
	virtual ~DataSource() = default;
};

int main() {


	return 0;
}