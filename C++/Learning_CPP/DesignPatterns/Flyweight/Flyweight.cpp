#include <iostream>
#include <unordered_map>
#include <memory>
#include <string>

class TreeType {
private:
	std::string name;
	std::string texture;
	std::string color;
public:
	TreeType(const std::string& n, const std::string& t, const std::string& c) : name(n), texture(t), color(c) { }

	void draw(int x, int y) const {
		std::cout << "Drawing tree '" << name << "' at(" << x << ", " << y
			<< ") with texture '" << texture << "' and color '" << color << "'\n";
	}
};

class Tree {
private:
	int x, y;
	std::shared_ptr<TreeType> type;
public:
	Tree(int xPos, int yPos, std::shared_ptr<TreeType> treeType) : x(xPos), y(yPos), type(treeType) { }

	void draw() const {
		type->draw(x, y);
	}
};

int main() {


	return 0;
}