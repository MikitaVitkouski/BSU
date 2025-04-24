#include <iostream>
#include <memory>
#include <string>
#include <vector>

class Aircraft;

class ATCMediator {
public:
	virtual void notify(Aircraft* sender, const std::string& event) = 0;
};

class ControlTower : public ATCMediator {
private:
	std::vector<Aircraft*> aircrafts;
public:
	void registerAircraft(Aircraft* aircraft);

	void notify(Aircraft* sender, const std::string& event) override;
};

class Aircraft {
private:
	ATCMediator* mediator;
public:
	Aircraft(ATCMediator* m) : mediator(m) { }
	virtual void requestLanding() = 0;
	virtual std::string getID() const = 0;
};

int main() {


	return 0;
}