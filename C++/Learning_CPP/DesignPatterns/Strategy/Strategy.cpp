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

int main() {


	return 0;
}