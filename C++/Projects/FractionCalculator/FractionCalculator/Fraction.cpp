#include "Fraction.h"
#include <numeric>
#include <stdexcept>
#include <cmath>

Fraction::Fraction(int num, int den) {
	if (den == 0) {
		throw std::invalid_argument("Denominator can't be zero");
	}

	numerator = num;
	denominator = den;
	simplify();
}

// Getters
int Fraction::getNumerator() const { return numerator; }
int Fraction::getDenominator() const { return denominator; }

// Setters
void Fraction::setNumerator(int num) {
	numerator = num; simplify();
}
void Fraction::setDenominator(int den) {
	if (den == 0) {
		throw std::invalid_argument("Denominator can't be zero");
	}

	denominator = den;
	simplify();
}

void Fraction::simplify() {
	int gcd = std::gcd(numerator, denominator);
	numerator /= gcd;
	denominator /= gcd;
	if (denominator < 0) {
		numerator = -numerator;
		denominator = -denominator;
	}
}

