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

class ScandinavianChair : public Chair {
public:
	void sit() const override {
		std::cout << "You sit on a minimalist Scandinavian chair.\n";
	}
};

class ScandinavianSofa : public Sofa {
public:
	void lie() const override {
		std::cout << "You lie on a cozy Scandinavian sofa.\n";
	}
};

class ScandinavianTable : public Table {
public:
	void use() const override {
		std::cout << "You use a light wooden Scandinavian table.\n";
	}
};

class AmericanChair : public Chair {
public:
	void sit() const override {
		std::cout << "You sit on a bulky American chair.\n";
	}
};

class AmericanSofa : public Sofa {
public:
	void lie() const override {
		std::cout << "You lie on a massive American sofa.\n";
	}
};

class AmericanTable : public Table {
public:
	void use() const override {
		std::cout << "You use a heavy oak American table.\n";
	}
};

int main() {


	return 0;
}