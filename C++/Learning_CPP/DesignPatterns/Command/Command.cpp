#include <iostream>
#include <memory>
#include <string>
#include <vector>

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

//(Invoker)
class RemoteControl {
private:
	std::vector<std::shared_ptr<Command>> history;
public:
	void pressButton(std::shared_ptr<Command> cmd) {
		cmd->execute();
		history.push_back(cmd); // can be used for cancelling
	}
};


//Client
int main() {
	Light livingRoomLight;

	auto onCommand = std::make_shared<TurnOnCommand>(livingRoomLight);
	auto offCommand = std::make_shared<TurnOffCommand>(livingRoomLight);

	RemoteControl remote;
	remote.pressButton(onCommand);
	remote.pressButton(offCommand);

	/*Output:
	Light is ON
	Light is OFF
	*/

	return 0;
}