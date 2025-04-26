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


int main() {


	return 0;
}