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

class Circle : public Shape {
private:
	int radius;
public:
	Circle(int r = 0) : radius(r) { }

	Circle(const Circle& other) : Shape(other), radius(other.radius) { }

	std::unique_ptr<Shape> clone() const override {
		return std::make_unique<Circle>(*this);
	}

	void draw() const override {
		std::cout << "Circle with radius " << radius << " and color " << color << "\n";
	}

	void setRadius(int r) {
		radius = r;
	}
};

class Rectangle : public Shape {
private:
	int width;
	int height;
public:
	Rectangle(int w = 0, int h = 0) : width(w), height(h) { }

	Rectangle(const Rectangle& other) : Shape(other), width(other.width), height(other.height) { }

	std::unique_ptr<Shape> clone() const override {
		return std::make_unique<Circle>(*this);
	}

	void draw() const override {
		std::cout << "Rectangle " << width << "x" << height << " and color " << color << "\n";
	}

	void setSize(int w, int h) {
		width = w;
		height = h;
	}
};

int main() {


	return 0;
}