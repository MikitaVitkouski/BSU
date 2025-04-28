#pragma once

class Fraction {
public:
    Fraction(int numerator = 0, int denominator = 1);

    int getNumerator() const { return numerator_; }
    int getDenominator() const { return denominator_; }

private:
    int numerator_;
    int denominator_;
};