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

	Fraction& operator+=(const Fraction& other);
	Fraction& operator-=(const Fraction& other);
	Fraction& operator*=(const Fraction& other);
	Fraction& operator/=(const Fraction& other);

	Fraction operator+() const; //unary plus
	Fraction operator-() const; //unary minus
	Fraction& operator++(); //prefix++
	Fraction operator++(int); //postfix++
	Fraction& operator--(); //prefix--
	Fraction operator--(int); //postfix--

	bool operator==(const Fraction& other) const;
	bool operator>=(const Fraction& other) const;
	bool operator<=(const Fraction& other) const;
	bool operator>(const Fraction& other) const;
	bool operator<(const Fraction& other) const;
	bool operator!=(const Fraction& other) const;

	//comparing with int
	bool operator==(int value) const;
	bool operator>(int value) const;
	bool operator<(int value) const;
	bool operator<=(int value) const;
	bool operator>=(int value) const;
	bool operator!=(int value) const;

	//comparing with double
	bool operator==(double value) const;
	bool operator>(double value) const;
	bool operator<(double value) const;
	bool operator<=(double value) const;
	bool operator>=(double value) const;
	bool operator!=(double value) const;

	double toDouble() const; // returns decimal representation of the fraction
	std::string toString() const; // for future purpose (GUI)
	explicit operator double() const; // for "static_cast<double>(Fraction_object)"

	friend std::istream& operator>>(std::istream& is, Fraction& frac);
	friend std::ostream& operator<<(std::ostream& os, const Fraction& frac);
};

#endif