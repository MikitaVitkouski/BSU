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
	std::shared_ptr<Color> red = std::make_shared<Red>();
	std::shared_ptr<Color> blue = std::make_shared<Blue>();

	std::unique_ptr<Shape> redCircle = std::make_unique<Circle>(red);
	std::unique_ptr<Shape> blueSquare = std::make_unique<Square>(blue);
	std::unique_ptr<Shape> redSquare = std::make_unique<Square>(red);

	redCircle->draw();
	blueSquare->draw();
	redSquare->draw();

	return 0;
}