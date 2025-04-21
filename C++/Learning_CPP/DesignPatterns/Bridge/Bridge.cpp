#include <iostream>
#include <memory>
#include <string>

class Color {
public:
	virtual std::string getColor() const = 0;
	virtual ~Color() = default;
};

class Red : public Color {
public:
	std::string getColor() const override {
		return "Red";
	}
};

class Blue : public Color {
public:
	std::string getColor() const override {
		return "Blue";
	}
}; 

class Shape {
protected:
	std::shared_ptr<Color> color;
public:
	Shape(std::shared_ptr<Color> c) : color(std::move(c)) { }
	virtual void draw() const = 0;
	virtual ~Shape() = default;
};

class Circle : public Shape {
public:
	Circle(std::shared_ptr<Color> c) : Shape(std::move(c)) { }

	void draw() const override {
		std::cout << "Drawing a " << color->getColor() << " Circle.\n";
	}
};

class Square : public Shape {
public:
	Square(std::shared_ptr<Color> c) : Shape(std::move(c)) { }

	void draw() const override {
		std::cout << "Drawing a " << color->getColor() << " Square.\n";
	}
};

int main() {


	return 0;
}