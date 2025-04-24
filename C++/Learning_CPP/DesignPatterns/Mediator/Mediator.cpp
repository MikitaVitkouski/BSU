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

class Plane : public Aircraft {
private:
	std::string id;
public:
	Plane(const std::string& id, ATCMediator* m) : Aircraft(m), id(id) { }

	void requestLanding() override {
		std::cout << "[Plane " << id << "] requesting landing.\n";
	}

	std::string getID() const override {
		return id;
	}
};

void ControlTower::registerAircraft(Aircraft* aircraft) {
	aircrafts.push_back(aircraft);
}

void ControlTower::notify(Aircraft* sender, const std::string& event) {
	if (event == "landing") {
		std::cout << "[Tower] Plane " << sender->getID() << " cleared to land.\n";

		// notify others about landing
		for (auto* aircraft : aircrafts) {
			if (aircraft != sender) {
				std::cout << "[Tower] Notifying plane " << aircraft->getID() << " to hold position.\n";
			}
		}
	}
}

int main() {
	ControlTower tower;

	Plane p1("MH370", &tower);
	Plane p2("AB670", &tower);
	Plane p3("AIR322", &tower);
	
	tower.registerAircraft(&p1);
	tower.registerAircraft(&p2);
	tower.registerAircraft(&p3);

	p1.requestLanding();

	/*Output:
	[Plane MH370] requesting landing.
	*/

	return 0;
}