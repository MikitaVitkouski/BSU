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

class Tea : public Beverage {
	void brew() override {
		std::cout << "Brewing tea\n";
	}

	void addCondiments() override {
		std::cout << "Adding lemon\n";
	}
};

class Coffee : public Beverage {
	void brew() override {
		std::cout << "Brewing coffee\n";
	}

	void addCondiments() override {
		std::cout << "Adding milk\n";
	}
};

int main() {
	Tea tea;
	Coffee coffee;

	std::cout << "--- Making tea ---\n";
	tea.prepareRecipe();

	std::cout << "\n--- Making coffee ---\n";
	coffee.prepareRecipe();

	/*Output:
	--- Making tea ---
	Boiling water
	Brewing tea
	Pouring in cup
	Adding lemon

	--- Making coffee ---
	Boiling water
	Brewing coffee
	Pouring in cup
	Adding milk
	*/

	return 0;
}