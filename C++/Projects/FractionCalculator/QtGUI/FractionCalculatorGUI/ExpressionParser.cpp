#include "ExpressionParser.h"
#include <stack>
#include <stdexcept>

// Converts a string like "3/4" or "5" into a Fraction object
Fraction parseFraction(const QString& token) {
    // Split the string by the '/' character
    QStringList parts = token.split('/');
    if (parts.size() == 1) {
        // If there's only one part, it's a whole number (e.g. "6"), treat it as "5/1"
        return Fraction(parts[0].toInt(), 1);
    } else if (parts.size() == 2) {
        // If the format is correct: numerator and denominator (e.g. "3/4")
        return Fraction(parts[0].toInt(), parts[1].toInt());
    } else {
        // If there are more than two parts (e.g. "1/2/3"), it's an invalid format
        throw std::invalid_argument("Incorrect fraction's format: " + token.toStdString());
    }
}

int getPrecedence(const QString& op) {
    if (op == "+" || op == "-") return 1; // Low precedence
    if (op == "*" || op == "/") return 2; // Medium precedence
    if (op == "^") return 3; // High precedence
    return 0; // Unknown operator - zero precedence
}

// Checks is the token real arithmetic operator
bool isOperator(const QString& token) {
    return token == "+" || token == "-" || token == "*" || token == "/" || token == "^";
}

// Determines if the operator is right-associative (for example, exponentiation)
bool isRightAssociative(const QString& op) {
    return op == "^";
}

