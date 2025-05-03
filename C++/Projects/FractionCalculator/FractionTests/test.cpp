#include "pch.h"
#include "Fraction.h"

TEST(FractionTest, Addition) {
    Fraction a(1, 2);
    Fraction b(1, 3);
    Fraction result = a + b;

    EXPECT_EQ(result.getNumerator(), 5);
    EXPECT_EQ(result.getDenominator(), 6);
}

TEST(FractionTest, Subtraction) {
    Fraction f1(1, 3);
    Fraction f2(3, 2);
    Fraction result = f2 - f1;

    EXPECT_EQ(result.getNumerator(), 7);
    EXPECT_EQ(result.getDenominator(), 6);
}