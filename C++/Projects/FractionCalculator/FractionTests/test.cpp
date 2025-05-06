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

TEST(FractionTest, Equal) {
    Fraction a(1, 2);
    Fraction b(4, 8);
    bool result = a == b;

    EXPECT_EQ(result, true);

    Fraction c(3, 4);
    result = c == a;
    
    EXPECT_EQ(result, false);

    result = c == b;

    EXPECT_EQ(result, false);

    a.setNumerator(0);
    b.setNumerator(0);
    result = a == b;

    EXPECT_EQ(result, true);

    b.setDenominator(-8);
    result = a == b;

    EXPECT_EQ(result, true);
}

TEST(FractionTest, NotEqual) {
    Fraction a(1, 2);
    Fraction b(4, 8);
    bool result = a != b;

    EXPECT_EQ(result, false);

    Fraction c(3, 4);
    result = c != a;

    EXPECT_EQ(result, true);

    result = c != b;

    EXPECT_EQ(result, true);

    a.setNumerator(0);
    b.setNumerator(0);
    result = a != b;

    EXPECT_EQ(result, false);

    b.setDenominator(-8);
    result = a != b;

    EXPECT_EQ(result, false);
}

TEST(FractionTest, More) {
    Fraction a(1, 2);
    Fraction b(4, 8);
    bool result = a > b;

    EXPECT_EQ(result, false);

    Fraction c(3, 4);
    result = c > a;

    EXPECT_EQ(result, true);

    result = c > b;

    EXPECT_EQ(result, true);

    a.setNumerator(0);
    b.setNumerator(0);
    result = a > b;

    EXPECT_EQ(result, false);

    b.setDenominator(-8);
    result = a > b;

    EXPECT_EQ(result, false);
}

TEST(FractionTest, MoreOrEqual) {
    Fraction a(1, 2);
    Fraction b(4, 8);
    bool result = a >= b;

    EXPECT_EQ(result, true);

    Fraction c(3, 4);
    result = c >= a;

    EXPECT_EQ(result, true);

    result = c >= b;

    EXPECT_EQ(result, true);

    a.setNumerator(0);
    b.setNumerator(0);
    result = a >= b;

    EXPECT_EQ(result, true);

    b.setDenominator(-8);
    result = a >= b;

    EXPECT_EQ(result, true);
}

TEST(FractionTest, Less) {
    Fraction a(1, 2);
    Fraction b(4, 8);
    bool result = a < b;

    EXPECT_EQ(result, false);

    Fraction c(3, 4);
    result = c < a;

    EXPECT_EQ(result, false);

    result = c < b;

    EXPECT_EQ(result, false);

    a.setNumerator(0);
    b.setNumerator(0);
    result = a <  b;

    EXPECT_EQ(result, false);

    b.setDenominator(-8);
    result = a < b;
    EXPECT_EQ(result, false);

    Fraction d(5, 8);
    result = a < d;

    EXPECT_EQ(result, true);
}

TEST(FractionTest, LessOrEqual) {
    Fraction a(1, 2);
    Fraction b(4, 8);
    bool result = a <= b;

    EXPECT_EQ(result, true);

    Fraction c(3, 4);
    result = c <= a;

    EXPECT_EQ(result, false);

    result = c <= b;

    EXPECT_EQ(result, false);

    a.setNumerator(0);
    b.setNumerator(0);
    result = a <= b;

    EXPECT_EQ(result, true);

    b.setDenominator(-8);
    result = a <= b;
    EXPECT_EQ(result, true);

    Fraction d(5, 8);
    result = a <= d;

    EXPECT_EQ(result, true);
}

TEST(FractionTest, EqualToInt) {
    Fraction a(1, 2);
    int i = 2;
    bool result = a == i;

    EXPECT_EQ(result, false);

    Fraction c(3, 1);
    i = 3;
    result = c == i;

    EXPECT_EQ(result, true);

    Fraction d(0, 16);
    i = 0;
    result = d == i;

    EXPECT_EQ(result, true);

    c.setNumerator(-3);
    i = -3;
    result = c == i;

    EXPECT_EQ(result, true);
}

TEST(FractionTest, NotEqualToInt) {
    Fraction a(1, 2);
    int i = 2;
    bool result = a != i;

    EXPECT_EQ(result, true);

    Fraction c(3, 1);
    i = 3;
    result = c != i;

    EXPECT_EQ(result, false);

    Fraction d(0, 16);
    i = 0;
    result = d != i;

    EXPECT_EQ(result, false);

    c.setNumerator(-3);
    i = -3;
    result = c != i;

    EXPECT_EQ(result, false);
}

TEST(FractionTest, MoreToInt) {
    Fraction a(1, 2);
    int i = 2;
    bool result = a > i;

    EXPECT_EQ(result, false);

    Fraction c(3, 1);
    i = 3;
    result = c > i;

    EXPECT_EQ(result, false);

    Fraction d(0, 16);
    i = 0;
    result = d > i;

    EXPECT_EQ(result, false);

    c.setNumerator(-3);
    i = -4;
    result = c > i;

    EXPECT_EQ(result, true);
}

TEST(FractionTest, MoreOrEqualToInt) {
    Fraction a(1, 2);
    int i = 2;
    bool result = a >= i;

    EXPECT_EQ(result, false);

    Fraction c(3, 1);
    i = 3;
    result = c >= i;

    EXPECT_EQ(result, true);

    Fraction d(0, 16);
    i = 0;
    result = d >= i;

    EXPECT_EQ(result, true);

    c.setNumerator(-3);
    i = -4;
    result = c >= i;

    EXPECT_EQ(result, true);
}

TEST(FractionTest, LessToInt) {
    Fraction a(1, 2);
    int i = 2;
    bool result = a < i;

    EXPECT_EQ(result, true);

    Fraction c(3, 1);
    i = 3;
    result = c < i;

    EXPECT_EQ(result, false);

    Fraction d(0, 16);
    i = 0;
    result = d < i;

    EXPECT_EQ(result, false);

    c.setNumerator(-3);
    i = -4;
    result = c < i;

    EXPECT_EQ(result, false);
}

TEST(FractionTest, LessOrEqualToInt) {
    Fraction a(1, 2);
    int i = 2;
    bool result = a <= i;

    EXPECT_EQ(result, true);

    Fraction c(3, 1);
    i = 3;
    result = c <= i;

    EXPECT_EQ(result, true);

    Fraction d(0, 16);
    i = 0;
    result = d <= i;

    EXPECT_EQ(result, true);

    c.setNumerator(-3);
    i = -4;
    result = c <= i;

    EXPECT_EQ(result, false);
}

TEST(FractionTest, EqualToDouble) {
    Fraction a(1, 2);
    double i = 0.5;
    bool result = a == i;

    EXPECT_EQ(result, true);

    Fraction c(3, 1);
    i = 3.0;
    result = c == i;

    EXPECT_EQ(result, true);

    Fraction d(0, 16);
    i = 0.0;
    result = d == i;

    EXPECT_EQ(result, true);

    c.setNumerator(-3);
    c.setDenominator(6);
    i = -0.5;
    result = c == i;

    EXPECT_EQ(result, true);
}

TEST(FractionTest, NotEqualToDouble) {
    Fraction a(1, 2);
    double i = 0.5;
    bool result = a != i;

    EXPECT_EQ(result, false);

    Fraction c(3, 1);
    i = 3.0;
    result = c != i;

    EXPECT_EQ(result, false);

    Fraction d(0, 16);
    i = 0.0;
    result = d != i;

    EXPECT_EQ(result, false);

    c.setNumerator(-3);
    c.setDenominator(6);
    i = -0.5;
    result = c != i;

    EXPECT_EQ(result, false);

    d.setNumerator(4);
    d.setDenominator(10);
    i = 0.33;
    result = d != i;

    EXPECT_EQ(result, true);
}

TEST(FractionTest, MoreToDouble) {
    Fraction a(1, 2);
    double i = 0.33;
    bool result = a > i;

    EXPECT_EQ(result, true);

    Fraction c(3, 2);
    i = 3.0;
    result = c > i;

    EXPECT_EQ(result, false);

    Fraction d(0, 16);
    i = 0.0;
    result = d > i;

    EXPECT_EQ(result, false);

    c.setNumerator(-3);
    c.setDenominator(8);
    i = -0.5;
    result = c > i;

    EXPECT_EQ(result, true);

    d.setNumerator(4);
    d.setDenominator(10);
    i = 0.33;
    result = d > i;

    EXPECT_EQ(result, true);
}

TEST(FractionTest, MoreOrEqualToDouble) {
    Fraction a(1, 2);
    double i = 0.5;
    bool result = a >= i;

    EXPECT_EQ(result, true);

    Fraction c(3, 2);
    i = 3.0;
    result = c >= i;

    EXPECT_EQ(result, false);

    Fraction d(0, 16);
    i = 0.0;
    result = d >= i;

    EXPECT_EQ(result, true);

    c.setNumerator(-3);
    c.setDenominator(8);
    i = -0.5;
    result = c >= i;

    EXPECT_EQ(result, true);

    d.setNumerator(1);
    d.setDenominator(3);
    i = 0.33;
    result = d >= i;

    EXPECT_EQ(result, true);
}

TEST(FractionTest, LessToDouble) {
    Fraction a(3, 4);
    double i = 1.33;
    bool result = a < i;

    EXPECT_EQ(result, true);

    Fraction c(3, 8);
    i = 3.0;
    result = c < i;

    EXPECT_EQ(result, true);

    Fraction d(0, 16);
    i = 0.0;
    result = d < i;

    EXPECT_EQ(result, false);

    c.setNumerator(-3);
    c.setDenominator(8);
    i = -0.5;
    result = c < i;

    EXPECT_EQ(result, false);

    d.setNumerator(4);
    d.setDenominator(18);
    i = 0.33;
    result = d < i;

    EXPECT_EQ(result, true);
}

TEST(FractionTest, LessOrEqualToDouble) {
    Fraction a(3, 4);
    double i = 1.33;
    bool result = a <= i;

    EXPECT_EQ(result, true);

    Fraction c(3, 8);
    i = 3.0;
    result = c <= i;

    EXPECT_EQ(result, true);

    Fraction d(0, 16);
    i = 0.0;
    result = d <= i;

    EXPECT_EQ(result, true);

    c.setNumerator(-3);
    c.setDenominator(8);
    i = -0.5;
    result = c <= i;

    EXPECT_EQ(result, false);

    d.setNumerator(1);
    d.setDenominator(1);
    i = 1.0;
    result = d <= i;

    EXPECT_EQ(result, true);
}

TEST(FractionTest, toDouble) {
    Fraction a(1, 2);
    double v = 0.5;

    EXPECT_EQ(a.toDouble(), v);

    Fraction b(3, 4);
    double q = 0.75;

    EXPECT_EQ(b.toDouble(), q);

    Fraction c(1, 1);
    Fraction d(0, 1);
    double t = 1.0;
    double y = 0.0;

    EXPECT_EQ(c.toDouble(), t);
    EXPECT_EQ(d.toDouble(), y);

    Fraction e(-5, 4);
    Fraction f(-6, 8);
    t = -1.25;
    y = -0.75;

    EXPECT_EQ(e.toDouble(), t);
    EXPECT_EQ(f.toDouble(), y);
}

TEST(FractionTest, reverse) {
    Fraction a(3, 9);
    Fraction b(3, 1);

    EXPECT_EQ(a.reverse(), b);

    Fraction c(-3, 11);
    Fraction d(-11, 3);

    EXPECT_EQ(c.reverse(), d);

    Fraction e(-8, 40);
    Fraction f(-5, 1);

    EXPECT_EQ(e.reverse(), f);

    Fraction t(0, 17);
    EXPECT_THROW(t.reverse(), std::invalid_argument);
}

TEST(FractionTest, abs) {
    Fraction a(0, -9);
    Fraction b(0, 1);

    EXPECT_EQ(a.abs(), b);

    Fraction c(-1, 7);
    Fraction d(1, 7);

    EXPECT_EQ(c.abs(), d);

    Fraction e(3, -4);
    Fraction f(3, 4);

    EXPECT_EQ(e.abs(), f);

    Fraction g(-5, -6);
    Fraction h(5, 6);

    EXPECT_EQ(g.abs(), h);

    Fraction i(2, 3);
    Fraction j(2, 3);

    EXPECT_EQ(i.abs(), j);
}

TEST(FractionTest, toString) {
    Fraction f(1, 2);
    EXPECT_EQ(f.toString(), "1/2");

    Fraction a(-3, 4);
    EXPECT_EQ(a.toString(), "-3/4");

    Fraction b(5, -8);
    EXPECT_EQ(b.toString(), "-5/8");

    Fraction c(-6, -9);
    EXPECT_EQ(c.toString(), "2/3");

    Fraction e(0, 7);
    EXPECT_EQ(e.toString(), "0/1");
}

TEST(FractionTest, toDoubleOperator) {
    Fraction a(5, 8);
    double result = static_cast<double>(a);

    EXPECT_DOUBLE_EQ(result, 0.625);

    Fraction b(3, -4);
    result = static_cast<double>(b);

    EXPECT_DOUBLE_EQ(result, -0.75);

    Fraction f(5, -10);
    result = static_cast<double>(f);

    EXPECT_DOUBLE_EQ(result, -0.5);

    Fraction y(-2, -10);
    result = static_cast<double>(y);

    EXPECT_DOUBLE_EQ(result, 0.2);

    Fraction zero(0, -15);
    result = static_cast<double>(zero);

    EXPECT_DOUBLE_EQ(result, 0.0);
}