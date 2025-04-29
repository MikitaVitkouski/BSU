#include "Fraction.h"
#include <fstream>

std::ofstream out("output.txt");

int main() {
	try {

		Fraction f1(1, 2);
		Fraction f2(3, 4);
		Fraction f3(1, 4);

		Fraction sum = f1 + f2;
		out << "f1 + f2: " << sum << "\n";

		Fraction diff = f1 - f2;
		out << "f1 - f2 = " << diff << "\n";

		Fraction mul = f1 * f3;
		out << "f1 * f3 = " << mul << "\n";

		Fraction div = f3 / f2;
		out << "f3 / f2 = " << div << "\n";

		Fraction f4(1, 0);
	} catch (const std::exception& e) {
		out << "Error: " << e.what() << std::endl;
	}

	return 0;
}