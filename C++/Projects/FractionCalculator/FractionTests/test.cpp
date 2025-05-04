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

TEST(FractionTest, PlusEqual) {
    Fraction a(3, 6);
    Fraction b(7, 6);
    a += b;

    EXPECT_EQ(a.getNumerator(), 5);
    EXPECT_EQ(a.getDenominator(), 3);
}

TEST(FractionTest, MinusEqual) {
    Fraction a(29, 8);
    Fraction b(11, 8);
    a -= b;

    EXPECT_EQ(a.getNumerator(), 9);
    EXPECT_EQ(a.getDenominator(), 4);
}

TEST(FractionTest, MultiplyEqual) {
    Fraction a(5, 8);
    Fraction b(8, 6);
    a *= b;

    EXPECT_EQ(a.getNumerator(), 5);
    EXPECT_EQ(a.getDenominator(), 6);
}

TEST(FractionTest, DivideEqual) {
    Fraction a(11, 6);
    Fraction b(22, 5);
    a /= b;

    EXPECT_EQ(a.getNumerator(), 5);
    EXPECT_EQ(a.getDenominator(), 12);
}

TEST(FractionTest, UnaryPlus) {
    Fraction a(3, 4);
    Fraction result1 = +a;
    Fraction b(-1, 2);
    Fraction result2 = +b;
    Fraction c(0, 7);
    Fraction result3 = +c;

    EXPECT_EQ(result1.getNumerator(), 3);
    EXPECT_EQ(result1.getDenominator(), 4);
    EXPECT_EQ(result2.getNumerator(), -1);
    EXPECT_EQ(result2.getDenominator(), 2);
    EXPECT_EQ(result3.getNumerator(), 0);
    EXPECT_EQ(result3.getDenominator(), 1);
}

TEST(FractionTest, UnaryMinus) {
    Fraction a(3, 5);
    Fraction result1 = -a;
    Fraction b(-7, 8);
    Fraction result2 = -b;
    Fraction c(0, 7);
    Fraction result3 = -c;

    EXPECT_EQ(result1.getNumerator(), -3);
    EXPECT_EQ(result1.getDenominator(), 5);
    EXPECT_EQ(result2.getNumerator(), 7);
    EXPECT_EQ(result2.getDenominator(), 8);
    EXPECT_EQ(result3.getNumerator(), 0);
    EXPECT_EQ(result3.getDenominator(), 1);
}

TEST(FractionTest, PrefixPlusPlus) {
    Fraction f(1, 2);
    ++f;
    Fraction zero(0, 7);
    ++zero;
    Fraction minus_f(-7, 16);
    ++minus_f;
    
    EXPECT_EQ(f.getNumerator(), 3);
    EXPECT_EQ(f.getDenominator(), 2);
    EXPECT_EQ(zero.getNumerator(), 1);
    EXPECT_EQ(zero.getDenominator(), 1);
    EXPECT_EQ(minus_f.getNumerator(), 9);
    EXPECT_EQ(minus_f.getDenominator(), 16);
}

TEST(FractionTest, PostfixPlusPlus) {
    Fraction f(1, 2);
    Fraction temp_f = f++;

    EXPECT_EQ(temp_f.getNumerator(), 1);
    EXPECT_EQ(temp_f.getDenominator(), 2);

    EXPECT_EQ(f.getNumerator(), 3);
    EXPECT_EQ(f.getDenominator(), 2);

    Fraction zero(0, 7);
    Fraction temp_zero = zero++;

    EXPECT_EQ(temp_zero.getNumerator(), 0);
    EXPECT_EQ(temp_zero.getDenominator(), 1);

    EXPECT_EQ(zero.getNumerator(), 1);
    EXPECT_EQ(zero.getDenominator(), 1);

    Fraction minus_f(-7, 16);
    Fraction temp_minus_f = minus_f++;

    EXPECT_EQ(temp_minus_f.getNumerator(), -7);
    EXPECT_EQ(temp_minus_f.getDenominator(), 16);

    EXPECT_EQ(minus_f.getNumerator(), 9);
    EXPECT_EQ(minus_f.getDenominator(), 16);
}

TEST(FractionTest, PrefixMinusMinus) {
    Fraction f(1, 2);
    --f;
    Fraction zero(0, 7);
    --zero;
    Fraction minus_f(-7, 16);
    --minus_f;

    EXPECT_EQ(f.getNumerator(), -1);
    EXPECT_EQ(f.getDenominator(), 2);
    EXPECT_EQ(zero.getNumerator(), -1);
    EXPECT_EQ(zero.getDenominator(), 1);
    EXPECT_EQ(minus_f.getNumerator(), -23);
    EXPECT_EQ(minus_f.getDenominator(), 16);
}

TEST(FractionTest, PostfixMinusMinus) {
    Fraction f(3, 2);
    Fraction temp_f = f--;

    EXPECT_EQ(temp_f.getNumerator(), 3);
    EXPECT_EQ(temp_f.getDenominator(), 2);

    EXPECT_EQ(f.getNumerator(), 1);
    EXPECT_EQ(f.getDenominator(), 2);

    Fraction zero(0, 7);
    Fraction temp_zero = zero--;

    EXPECT_EQ(temp_zero.getNumerator(), 0);
    EXPECT_EQ(temp_zero.getDenominator(), 1);

    EXPECT_EQ(zero.getNumerator(), -1);
    EXPECT_EQ(zero.getDenominator(), 1);

    Fraction minus_f(-11, 16);
    Fraction temp_minus_f = minus_f--;

    EXPECT_EQ(temp_minus_f.getNumerator(), -11);
    EXPECT_EQ(temp_minus_f.getDenominator(), 16);

    EXPECT_EQ(minus_f.getNumerator(), -27);
    EXPECT_EQ(minus_f.getDenominator(), 16);
}

TEST(FractionTest, Pow) {
    Fraction a(1, 4);
    Fraction b = a ^ 4;

    EXPECT_EQ(b.getNumerator(), 1);
    EXPECT_EQ(b.getDenominator(), 256);

    Fraction c = a ^ (-4);

    EXPECT_EQ(c.getNumerator(), 256);
    EXPECT_EQ(c.getDenominator(), 1);

    Fraction d(-2, 3);
    Fraction e = d ^ (-3);

    EXPECT_EQ(e.getNumerator(), -27);
    EXPECT_EQ(e.getDenominator(), 8);

    Fraction f(-15, 8);
    Fraction y = f ^ 0;

    EXPECT_EQ(y.getNumerator(), 1);
    EXPECT_EQ(y.getDenominator(), 1);

    Fraction x = f ^ 1;

    EXPECT_EQ(x.getNumerator(), -15);
    EXPECT_EQ(x.getDenominator(), 8);
}

TEST(FractionTest, PowEqual) {
    Fraction a(1, 4);
    a ^= 3;

    EXPECT_EQ(a.getNumerator(), 1);
    EXPECT_EQ(a.getDenominator(), 64);

    Fraction c = a ^ (-4);
    c ^= 0;

    EXPECT_EQ(c.getNumerator(), 1);
    EXPECT_EQ(c.getDenominator(), 1);

    Fraction d(-2, 3);
    d ^= -3;

    EXPECT_EQ(d.getNumerator(), -27);
    EXPECT_EQ(d.getDenominator(), 8);

    Fraction f(-15, 8);
    f ^= -1;

    EXPECT_EQ(f.getNumerator(), -8);
    EXPECT_EQ(f.getDenominator(), 15);
}

TEST(FractionTest, MultiplyByInt) {
    Fraction a(8, 9);
    int x = 3;
    Fraction b = a * x;

    EXPECT_EQ(b.getNumerator(), 8);
    EXPECT_EQ(b.getDenominator(), 3);

    x = -2;
    b = a * x;

    EXPECT_EQ(b.getNumerator(), -16);
    EXPECT_EQ(b.getDenominator(), 9);

    x = 5;
    b = a * x;

    EXPECT_EQ(b.getNumerator(), 40);
    EXPECT_EQ(b.getDenominator(), 9);

    x = 0;
    b = a * x;

    EXPECT_EQ(b.getNumerator(), 0);
    EXPECT_EQ(b.getDenominator(), 1);

    x = 1;
    b = a * x;

    EXPECT_EQ(b.getNumerator(), 8);
    EXPECT_EQ(b.getDenominator(), 9);
}

TEST(FractionTest, MultiplyByDouble) {
    Fraction a(8, 9);
    double x = 1.5;
    Fraction b = a * x;

    EXPECT_EQ(b.getNumerator(), 4);
    EXPECT_EQ(b.getDenominator(), 3);

    x = -2.5;
    b = a * x;

    EXPECT_EQ(b.getNumerator(), -20);
    EXPECT_EQ(b.getDenominator(), 9);

    x = 1.8;
    b = a * x;

    EXPECT_EQ(b.getNumerator(), 14);
    EXPECT_EQ(b.getDenominator(), 9);

    x = 0.0;
    b = a * x;

    EXPECT_EQ(b.getNumerator(), 0);
    EXPECT_EQ(b.getDenominator(), 1);

    x = 1.0;
    b = a * x;

    EXPECT_EQ(b.getNumerator(), 8);
    EXPECT_EQ(b.getDenominator(), 9);
}