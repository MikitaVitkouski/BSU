#include "Fraction.h"
#include <numeric>
#include <stdexcept>
#include <cmath>
#include <string>

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
    if (getDenominator() < 0) {
        numerator = -getNumerator();
        denominator = -getDenominator();
    }
    int gcd = std::gcd(getNumerator(), getDenominator());
    numerator /= gcd;
    denominator /= gcd;
}

Fraction Fraction::operator+(const Fraction& other) const {
    int num = other.getDenominator() * getNumerator() + getDenominator() * other.getNumerator();
    int den = other.getDenominator() * getDenominator();
    return Fraction(num, den);
}

Fraction Fraction::operator-(const Fraction& other) const {
    int num = getNumerator() * other.getDenominator() - other.getNumerator() * getDenominator();
    int den = other.getDenominator() * getDenominator();
    return Fraction(num, den);
}

Fraction Fraction::operator*(const Fraction& other) const {
    int num = getNumerator() * other.getNumerator();
    int den = getDenominator() * other.getDenominator();
    return Fraction(num, den);
}

Fraction Fraction::operator/(const Fraction& other) const {
    int num = getNumerator() * other.getDenominator();
    int den = getDenominator() * other.getNumerator();
    return Fraction(num, den);
}

Fraction& Fraction::operator+=(const Fraction& other) {
    *this = *this + other;
    return *this;
}

Fraction& Fraction::operator-=(const Fraction& other) {
    *this = *this - other;
    return *this;
}

Fraction& Fraction::operator*=(const Fraction& other) {
    *this = *this * other;
    return *this;
}

Fraction& Fraction::operator/=(const Fraction& other) {
    *this = *this / other;
    return *this;
}

bool Fraction::operator==(const Fraction& other) const {
    return getNumerator() == other.getNumerator() && getDenominator() == other.getDenominator();
}

bool Fraction::operator!=(const Fraction& other) const {
    return !(*this == other);
}

bool Fraction::operator>(const Fraction& other) const {
    return getNumerator() * other.getDenominator() > getDenominator() * other.getNumerator();
}

bool Fraction::operator<(const Fraction& other) const {
    return getNumerator() * other.getDenominator() < getDenominator() * other.getNumerator();
}

bool Fraction::operator>=(const Fraction& other) const {
    return getNumerator() * other.getDenominator() >= getDenominator() * other.getNumerator();
}

bool Fraction::operator<=(const Fraction& other) const {
    return getNumerator() * other.getDenominator() <= getDenominator() * other.getNumerator();
}

Fraction Fraction::operator+() const {
    return Fraction(+getNumerator(), +getDenominator());
}

Fraction Fraction::operator-() const {
    return Fraction(-getNumerator(), getDenominator());
}

Fraction& Fraction::operator++() {
    *this += 1;
    return *this;
}

Fraction Fraction::operator++(int) {
    Fraction temp = *this;
    *this += 1;
    return temp;
}

Fraction& Fraction::operator--() {
    *this -= 1;
    return *this;
}

Fraction Fraction::operator--(int) {
    Fraction temp = *this;
    *this -= 1;
    return temp;
}

Fraction Fraction::operator^(int n) const {
    if (n == 0) {
        return Fraction(1);
    }
    Fraction base = *this;

    if (n < 0) {
        base = base.reverse();
        n *= -1;
    }

    auto new_num = std::pow(base.getNumerator(), n);
    auto new_din = std::pow(base.getDenominator(), n);

    return Fraction(new_num, new_din);
}

Fraction& Fraction::operator^=(int n) {
    *this = *this ^ n;
    return *this;
}

Fraction Fraction::operator+(int rhs) const {
    int num = getNumerator() + rhs * getDenominator();
    int den = getDenominator();

    return Fraction(num, den);
}


Fraction Fraction::operator-(int rhs) const {
    int num = getNumerator() - rhs * getDenominator();
    int den = getDenominator();

    return Fraction(num, den);
}

Fraction Fraction::operator*(int rhs) const {
    int num = getNumerator() * rhs;
    int den = getDenominator();

    return Fraction(num, den);
}

Fraction Fraction::operator/(int rhs) const {
    return *this * Fraction(1, rhs);
}

bool Fraction::operator==(int value) const {
    return getNumerator() == value * getDenominator();
}

bool Fraction::operator>(int value) const {
    return getNumerator() > value * getDenominator();
}

bool Fraction::operator>=(int value) const {
    return getNumerator() >= value * getDenominator();
}

bool Fraction::operator<(int value) const {
    return getNumerator() < value * getDenominator();
}

bool Fraction::operator<=(int value) const {
    return getNumerator() <= value * getDenominator();
}

bool Fraction::operator!=(int value) const {
    return getNumerator() != value * getDenominator();
}

bool Fraction::operator==(double value) const {
    return toDouble() == value;
}

bool Fraction::operator>(double value) const {
    return toDouble() > value;
}

bool Fraction::operator>=(double value) const {
    return toDouble() >= value;
}

bool Fraction::operator<(double value) const {
    return toDouble() < value;
}

bool Fraction::operator<=(double value) const {
    return toDouble() <= value;
}

bool Fraction::operator!=(double value) const {
    return toDouble() != value;
}

double Fraction::toDouble() const {
    return static_cast<double>(getNumerator()) / getDenominator();
}

std::string Fraction::toString() const {
    return std::to_string(getNumerator()) + "/" + std::to_string(getDenominator());
}

Fraction::operator double() const {
    return static_cast<double>(getNumerator()) / getDenominator();
}

Fraction Fraction::reverse() const{
    if (numerator == 0) {
        throw std::invalid_argument("Cannot reverse a fraction with numerator 0.");
    }
    return Fraction(denominator, numerator);
}

Fraction Fraction::abs() const {
    return Fraction(std::abs(getNumerator()), std::abs(getDenominator()));
}

std::istream& operator>>(std::istream& is, Fraction& frac) {
    int num, den;
    char slash;

    std::istream::sentry s(is);
    if (!s) return is;

    is >> num >> slash >> den;

    if (!is || slash != '/' || den == 0) {
        is.setstate(std::ios::failbit);
        return is;
    }

    is >> std::ws;
    if (is.peek() != EOF) {
        is.setstate(std::ios::failbit);
        return is;
    }

    frac = Fraction(num, den);
    return is;
}

std::ostream& operator<<(std::ostream& os, const Fraction& frac) {
    if (frac.getDenominator() == 1) {
        os << frac.getNumerator();
    }
    else {
        os << frac.getNumerator() << "/" << frac.getDenominator();
    }
    return os;
}

Fraction operator+(int lhs, const Fraction& rhs) {
    int num = lhs * rhs.getDenominator() + rhs.getNumerator();
    int den = rhs.getDenominator();
    return Fraction(num, den);
}

Fraction operator*(int lhs, const Fraction& rhs) {
    int num = lhs * rhs.getNumerator();
    int den = rhs.getDenominator();

    return Fraction(num, den);
}

Fraction operator-(int lhs, const Fraction& rhs) {
    int num = lhs * rhs.getDenominator() - rhs.getNumerator();
    int den = rhs.getDenominator();

    return Fraction(num, den);
}

Fraction operator/(int lhs, const Fraction& rhs) {
    int num = lhs * rhs.getDenominator();
    int den = rhs.getNumerator();

    return Fraction(num, den);
}
