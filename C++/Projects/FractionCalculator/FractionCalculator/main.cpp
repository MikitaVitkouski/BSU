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

		out << "Unary +f1: " << +f1 << "\n";
		out << "Unary -f1: " << -f1 << "\n";

		out << "f1++: " << f1++ << "\n";
		out << "++f1: " << ++f1 << "\n";

		out << "f1--: " << f1-- << "\n";
		out << "--f1: " << --f1 << "\n";

		auto printBool = [&](const std::string& message, bool condition) {
			out << message << (condition ? "yes" : "no") << "\n";
		};

		printBool("f1 == f2? ", f1 == f2);
		printBool("f1 != f2? ", f1 != f2);
		printBool("f1 < f2? ", f1 < f2);
		printBool("f1 <= f2? ", f1 <= f2);
		printBool("f1 > f2? ", f1 > f2);
		printBool("f1 >= f2? ", f1 >= f2);

		printBool("f1 == 2? ", f1 == 2);
		printBool("f1 != 2? ", f1 != 2);
		printBool("f1 > 2? ", f1 > 2);
		printBool("f1 >= 2? ", f1 >= 2);
		printBool("f1 < 2? ", f1 < 2);
		printBool("f1 <= 2? ", f1 <= 2);

		printBool("f1 == 0.5? ", f1 == 0.5);
		printBool("f1 != 0.5? ", f1 != 0.5);
		printBool("f1 > 0.5? ", f1 > 0.5);
		printBool("f1 >= 0.5? ", f1 >= 0.5);
		printBool("f1 < 0.5? ", f1 < 0.5);
		printBool("f1 <= 0.5? ", f1 <= 0.5);

		out << "f2 as double (toDouble()): " << f2.toDouble() << "\n";

		out << "f3 as string (toString()): " << f3.toString() << "\n";

		double f1_as_double = static_cast<double>(f1);
		out << "f1 using static_cast<double>: " << f1_as_double << "\n";

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