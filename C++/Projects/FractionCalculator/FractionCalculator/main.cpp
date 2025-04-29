#include "Fraction.h"

int main() {
	try {
		Fraction f1(1, 2);
		Fraction f2(3, 4);
		Fraction f3(1, 4);

		Fraction sum = f1 + f2;
		std::cout << "f1 + f2: " << sum << "\n";
	}
	catch (const std::exception& e) {
		std::cout << "Error: " << e.what() << std::endl;
	}

	return 0;
}