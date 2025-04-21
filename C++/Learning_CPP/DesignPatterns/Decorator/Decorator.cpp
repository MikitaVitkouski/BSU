#include <iostream>
#include <memory>
#include <string>

class DataSource {
public:
	virtual void writeData(const std::string& data) = 0;
	virtual std::string readData() = 0;
	virtual ~DataSource() = default;
};

class FileDataSource : public DataSource {
private:
	std::string fileData;
public:
	void writeData(const std::string& data) override {
		fileData = data;
		std::cout << "Writing to file: " << data << "\n";
	}

	std::string readData() override {
		std::cout << "Reading from file: " << fileData << "\n";
		return fileData;
	}
};

class DataSourceDecorator : public DataSource {
protected:
	std::shared_ptr<DataSource> wrappee;
public:
	DataSourceDecorator(std::shared_ptr<DataSource> source) : wrappee(source) { }
};

class EncryptionDecorator : public DataSourceDecorator {
public:
	EncryptionDecorator(std::shared_ptr<DataSource> source) : DataSourceDecorator(source) {}

	void writeData(const std::string& data) override {
		std::string encrypted = "Encrypted(" + data + ")";
		wrappee->writeData(encrypted);
	}

	std::string readData() override {
		std::string data = wrappee->readData();
		return "Decrypted(" + data + ")";
	}
};

class CompressionDecorator : public DataSourceDecorator {
public:
	CompressionDecorator(std::shared_ptr<DataSource> source) : DataSourceDecorator(source) {}

	void writeData(const std::string& data) override {
		std::string compressed = "Compressed(" + data + ")";
		wrappee->writeData(compressed);
	}

	std::string readData() override {
		std::string data = wrappee->readData();
		return "Compressed(" + data + ")";
	}
};

int main() {
	//Clean file
	std::shared_ptr<DataSource> file = std::make_shared<FileDataSource>();

	//Wrapping file to encryption, then to compression
	std::shared_ptr<DataSource> encrypted = std::make_shared<EncryptionDecorator>(file);

	std::shared_ptr<DataSource> compressedEncrypted = std::make_shared<CompressionDecorator>(encrypted);

	//Client does not know about wrapping
	compressedEncrypted->writeData("Sensitive data");

	std::cout << "Final read: " << compressedEncrypted->readData() << "\n";

	/* Output:
	Writing to file: Encrypted(Compressed(Sensitive data))
	Reading from file: Encrypted(Compressed(Sensitive data))
	Final read: Compressed(Decrypted(Encrypted(Compressed(Sensitive data))))
	*/

	return 0;
}