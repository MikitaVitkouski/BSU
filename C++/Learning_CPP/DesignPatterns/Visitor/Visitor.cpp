#include <iostream>
#include <vector>
#include <memory>

class Circle;
class Rectangle;

//Interface of Visitor
class Visitor {
public:
	virtual void visit(Circle& circle) = 0;
	virtual void visit(Rectangle& rectangle) = 0;
	virtual ~Visitor() = default;
};

//Interface class for all shapes
class Shape {
public:
	virtual void accept(Visitor& visitor) = 0;
	virtual ~Shape() = default;
};

//Concrete elements
class Circle : public Shape {
private:
	double radius;
public:
	Circle(double radius) : radius(radius) { }

	double getRadius() const {
		return radius;
	}

	void accept(Visitor& visitor) override {
		visitor.visit(*this);
	}
};

class Rectangle : public Shape {
private:
	double width;
	double height;
public:
	Rectangle(double w, double h) : width(w), height(h) { }

	double getWidth() const {
		return width;
	}

	double getHeight() const {
		return height;
	}

	void accept(Visitor& visitor) override {
		visitor.visit(*this);
	}
};

//Concrete visitors
class AreaVisitor : public Visitor {
public:
	void visit(Circle& circle) override {
		double area = 3.14 * circle.getRadius() * circle.getRadius();
		std::cout << "Area of circle: " << area << ".\n";
	}

	void visit(Rectangle& rectangle) override {
		double area = rectangle.getHeight() * rectangle.getWidth();
		std::cout << "Area of rectangle: " << area << ".\n";
	}
};

class DrawVisitor : public Visitor {
public:
	void visit(Circle& circle) override {
		std::cout << "Drawing circle with radius: " << circle.getRadius() << ".\n";
	}

	void visit(Rectangle& rectangle) override {
		std::cout << "Drawing rectangle with width " << rectangle.getWidth() << " and height " << rectangle.getHeight() << ".\n";
	}
};

int main() {
	std::vector<std::unique_ptr<Shape>> shapes;
	shapes.push_back(std::make_unique<Circle>(5.0));
	shapes.push_back(std::make_unique<Rectangle>(4.0, 6.0));

	DrawVisitor drawVisitor;
	AreaVisitor areaVisitor;

	std::cout << "===Drawing shapes===\n";
	for (auto& shape : shapes) {
		shape->accept(drawVisitor);
	}

	std::cout << "\n===Counting areas===\n";
	for (auto& shape : shapes) {
		shape->accept(areaVisitor);
	}

	/*Output:
	===Drawing shapes===
	Drawing circle with radius: 5.
	Drawing rectangle with width 4 and height 6.

	===Counting areas===
	Area of circle: 78.5.
	Area of rectangle: 24.
	*/

	return 0;
}