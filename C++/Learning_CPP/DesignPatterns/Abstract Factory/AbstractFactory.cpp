#include <iostream>
#include <memory>
#include <string>

class Chair {
public:
	virtual void sit() const = 0;
	virtual ~Chair() = default;
};

class Sofa {
public:
	virtual void lie() const = 0;
	virtual ~Sofa() = default;
};

class Table {
public:
	virtual void use() const = 0;
	virtual ~Table() = default;
};

int main() {


	return 0;
}