#ifndef FRACTION_H
#define FRACTION_H

#include <iostream>

class Fraction {
private:
	int numerator;
	int denominator;

	void simplify();
public:
	Fraction(int num = 0, int den = 1);
	int getNumerator() const;
	int getDenominator() const;
	void setNumerator(int num);
	void setDenominator(int den);

	Fraction operator+(const Fraction& other) const;
	Fraction operator-(const Fraction& other) const;
	Fraction operator*(const Fraction& other) const;
	Fraction operator/(const Fraction& other) const;
	Fraction operator+=(const Fraction& other);
	Fraction operator-=(const Fraction& other);
	Fraction operator*=(const Fraction& other);
	Fraction operator/=(const Fraction& other);

	bool operator==(const Fraction& other) const;
	bool operator>=(const Fraction& other) const;
	bool operator<=(const Fraction& other) const;
	bool operator>(const Fraction& other) const;
	bool operator<(const Fraction& other) const;
	bool operator!=(const Fraction& other) const;

	friend std::istream& operator>>(std::istream& is, Fraction& frac);
	friend std::ostream& operator<<(std::ostream& os, const Fraction& frac);
};

#endif