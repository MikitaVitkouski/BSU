#include "Fraction.h"

int main() {
	try {
		Fraction f1(1, 2);
		Fraction f2(3, 4);
		Fraction f3(1, 4);
	}
	catch (const std::exception& e) {
		std::cout << "Error: " << e.what() << std::endl;
	}

	return 0;
}