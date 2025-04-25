#include <iostream>
#include <memory>
#include <string>

class Beverage {
public:
	void prepareRecipe() {
		boilWater();
		brew();
		pourInCup();
		addCondiments();
	}
protected:
	void boilWater() {
		std::cout << "Boiling water\n";
	}

	void pourInCup() {
		std::cout << "Pouring in cup\n";
	}

	//Variative steps
	virtual void brew() = 0;
	virtual void addCondiments() = 0;

	virtual ~Beverage() = default;
};

int main() {


	return 0;
}