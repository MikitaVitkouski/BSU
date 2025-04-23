#include <iostream>
#include <memory>
#include <string>

//command's interface
class Command {
public:
	virtual void execute() = 0;
	virtual ~Command() = default;
};

//Receiver
class Light {
public:
	void turnOn() {
		std::cout << "Light is ON\n";
	}
	void turnOff() {
		std::cout << "Light is OFF\n";
	}
};

//Concrete commands
class TurnOnCommand : public Command {
private:
	Light& light;
public:
	TurnOnCommand(Light& l) : light(l) { }
	void execute() override {
		light.turnOn();
	}
};

class TurnOffCommand : public Command {
private:
	Light& light;
public:
	TurnOffCommand(Light& l) : light(l) { }
	void execute() override {
		light.turnOff();
	}
};

int main() {


	return 0;
}