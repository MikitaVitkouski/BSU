#include "pch.h"
#include "Fraction.h"

TEST(FractionTest, Addition) {
    Fraction a(1, 2);
    Fraction b(1, 3);
    Fraction result = a + b;

    EXPECT_EQ(result.getNumerator(), 5);
    EXPECT_EQ(result.getDenominator(), 6);
}

TEST(FractionTest, NegativeAddition) {
    Fraction a(-1, 2);
    Fraction b(1, 3);
    Fraction result = a + b;

    EXPECT_EQ(result.getNumerator(), -1);
    EXPECT_EQ(result.getDenominator(), 6);
}

TEST(FractionTest, ZeroAddition) {
    Fraction zero(0, 1);
    Fraction b(1, 3);
    Fraction result = zero + b;

    EXPECT_EQ(result.getNumerator(), 1);
    EXPECT_EQ(result.getDenominator(), 3);
}

TEST(FractionTest, Reduction) {
    Fraction a(3, 6);
    Fraction b(4, 8);
    Fraction result = a + b;

    EXPECT_EQ(result.getNumerator(), 1);
    EXPECT_EQ(result.getDenominator(), 1);
}

TEST(FractionTest, Subtraction) {
    Fraction f1(1, 3);
    Fraction f2(3, 2);
    Fraction result = f2 - f1;

    EXPECT_EQ(result.getNumerator(), 7);
    EXPECT_EQ(result.getDenominator(), 6);
}

TEST(FractionTest, NegativeSubtraction) {
    Fraction a(-1, 2);
    Fraction b(-1, 3);
    Fraction result = a - b;

    EXPECT_EQ(result.getNumerator(), -1);
    EXPECT_EQ(result.getDenominator(), 6);
}

TEST(FractionTest, Multiplication) {
    Fraction f1(1, 4);
    Fraction f2(5, 3);
    Fraction result = f1 * f2;

    EXPECT_EQ(result.getNumerator(), 5);
    EXPECT_EQ(result.getDenominator(), 12);
}

TEST(FractionTest, OneMultiplication) {
    Fraction one(1, 1);
    Fraction f(5, 3);
    Fraction result = one * f;

    EXPECT_EQ(result.getNumerator(), 5);
    EXPECT_EQ(result.getDenominator(), 3);
}

TEST(FractionTest, Division) {
    Fraction f1(1, 3);
    Fraction f2(5, 7);
    Fraction result = f2 / f1;

    EXPECT_EQ(result.getNumerator(), 15);
    EXPECT_EQ(result.getDenominator(), 7);
}

TEST(FractionTest, DivisionByZeroNumerator) {
    Fraction f1(1, 5);
    Fraction f2(0, 7);

    EXPECT_THROW(f1 / f2, std::invalid_argument);
}

TEST(FractionTest, ZeroDividedByFraction) {
    Fraction zero(0, 8);
    Fraction f(5, 7);
    Fraction result = zero / f;

    EXPECT_EQ(result.getNumerator(), 0);
    EXPECT_EQ(result.getDenominator(), 1);
}

TEST(FractionTest, InvalidDenominator) {
    EXPECT_THROW(Fraction(1, 0), std::invalid_argument);
}