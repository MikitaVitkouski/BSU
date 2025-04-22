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
		std::cout << "Drawing tree '" << name << "' at (" << x << ", " << y
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

class TreeFactory {
private:
	std::unordered_map<std::string, std::shared_ptr<TreeType>> types;
public:
	std::shared_ptr<TreeType> getTreeType(const std::string& name, const std::string& texture, const std::string& color) {
		std::string key = name + texture + color;
		if (types.find(key) == types.end()) {
			types[key] = std::make_shared<TreeType>(name, texture, color);
		}
		return types[key];
	}
};

class Forest {
private:
	std::vector<Tree> trees;
	TreeFactory factory;
public:
	void plantTree(int x, int y, const std::string& name, const std::string& texture, const std::string& color) {
		auto type = factory.getTreeType(name, texture, color);
		trees.emplace_back(x, y, type);
	}

	void drawForest() const {
		for (const auto& tree : trees) {
			tree.draw();
		}
	}
};

int main() {
	Forest forest;

	forest.plantTree(30, 40, "Bereza", "bereza_texture.jpeg", "Green");
	forest.plantTree(20, 30, "Pine", "pine_texture.png", "DarkGreen");
	forest.plantTree(50, 60, "Bereza", "oak_texture.jpg", "Green");

	std::cout << "Rendering forest: \n";
	forest.drawForest();

	/* Output:
	Rendering forest:
	Drawing tree 'Bereza' at (30, 40) with texture 'bereza_texture.jpeg' and color 'Green'
	Drawing tree 'Pine' at (20, 30) with texture 'pine_texture.png' and color 'DarkGreen'
	Drawing tree 'Bereza' at (50, 60) with texture 'oak_texture.jpg' and color 'Green'
	*/

	return 0;
}