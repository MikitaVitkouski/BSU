#include <iostream>
#include <memory>
#include <string>

class Character {
public:
	std::string weapon;
	std::string armor;
	std::string magic;

	void show() const {
		std::cout << "Character Loadout:\n";
		std::cout << "Weapon: " << weapon << "\n";
		std::cout << "Armor: " << armor << "\n";
		std::cout << "Magic: " << (magic.empty() ? "None" : magic) << "\n";
	}
};

class CharacterBuilder {
public:
	virtual void buildWeapon() = 0;
	virtual void buildArmor() = 0;
	virtual void buildMagic() = 0;

	virtual std::unique_ptr<Character> getResult() = 0;
	virtual ~CharacterBuilder() = default;
};

int main() {


	return 0;
}