#include "Fraction.h"
#include <fstream>

std::ofstream out("output.txt");
std::ifstream in("input.txt");

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

		try {
			Fraction f4(1, 0);
		}
		catch (const std::invalid_argument& e) {
			out << "Error creating Fraction with zero denominator: " << e.what() << "\n";
		}

		auto printBool = [&](const std::string& message, bool condition) {
			out << message << (condition ? "yes" : "no") << "\n";
		};

		printBool("f1 == f2? ", f1 == f2);
		printBool("f1 != f2? ", f1 != f2);
		printBool("f1 < f2? ", f1 < f2);
		printBool("f1 <= f2? ", f1 <= f2);
		printBool("f1 > f2? ", f1 > f2);
		printBool("f1 >= f2? ", f1 >= f2);

		Fraction f;
		in >> f;
		out << "f: " << f << "\n";

	} catch (const std::exception& e) {
		out << "Error: " << e.what() << std::endl;
	}

	out.flush();
	out.close();
	return 0;
}