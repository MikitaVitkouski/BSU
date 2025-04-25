#include <iostream>
#include <string>
#include <memory>

//Strategy's interface
class RouteStrategy {
public:
	virtual void buildRoute(const std::string& from, const std::string& to) = 0;
	virtual ~RouteStrategy() = default;
};

//Concrete strategies
class CarRoute : public RouteStrategy {
public:
	void buildRoute(const std::string& from, const std::string& to) override {
		std::cout << "Building route by car: " << from << " -> " << to << "\n";
	}
};

class WalkingRoute : public RouteStrategy {
public:
	void buildRoute(const std::string& from, const std::string& to) override {
		std::cout << "Building route on foot: " << from << " -> " << to << "\n";
	}
};

class PublicTransportRoute : public RouteStrategy{
public:
	void buildRoute(const std::string & from, const std::string & to) override {
		std::cout << "Building route by public transport: " << from << " -> " << to << "\n";
	}
};

class Navigator {
private:
	std::unique_ptr<RouteStrategy> strategy;
public:
	void setStrategy(std::unique_ptr<RouteStrategy> newStrategy) {
		strategy = std::move(newStrategy);
	}

	void navigate(const std::string& from, const std::string& to) {
		if (strategy) {
			strategy->buildRoute(from, to);
		}
		else {
			std::cout << "There is no any strategy of route.\n";
		}
	}
};

int main() {

	return 0;
}