#include <iostream>
#include <memory>
#include <string>
#include <vector>

class Shape {
protected:
	std::string color;
public:
	Shape() = default;

	Shape(const Shape& other) : color(other.color) { }

	virtual std::unique_ptr<Shape> clone() const = 0;

	void setColor(const std::string& c) {
		color = c;
	}

	virtual void draw() const = 0;

	virtual ~Shape() = default;
};

int main() {


	return 0;
}