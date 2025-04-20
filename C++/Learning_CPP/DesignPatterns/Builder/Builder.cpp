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

class WarriorBuilder : public CharacterBuilder {
private:
	std::unique_ptr<Character> character;
public:
	WarriorBuilder() { character = std::make_unique<Character>(); }

	void buildWeapon() override {
		character->weapon = "Sword";
	}

	void buildArmor() override {
		character->armor = "Heavy Plate Armor";
	}

	void buildMagic() override {
		character->magic = ""; //Warriors don't use the magic
	}

	std::unique_ptr<Character> getResult() override {
		return std::move(character);
	}
};

class MageBuilder : public CharacterBuilder {
private:
	std::unique_ptr<Character> character;
public:
	MageBuilder() { character = std::make_unique<Character>(); }

	void buildWeapon() override {
		character->weapon = "Magic Staff";
	}

	void buildArmor() override {
		character->armor = "Cloth Robe";
	}

	void buildMagic() override {
		character->magic = "Fireball";
	}

	std::unique_ptr<Character> getResult() override {
		return std::move(character);
	}
};

class CharacterDirector {
public:
	void createFullCharacter(CharacterBuilder& builder) {
		builder.buildWeapon();
		builder.buildArmor();
		builder.buildMagic();
	}

	void createLightCharacter(CharacterBuilder& builder) {
		builder.buildWeapon();
		builder.buildArmor(); //Without buildMagic()
	}
};

int main() {


	return 0;
}