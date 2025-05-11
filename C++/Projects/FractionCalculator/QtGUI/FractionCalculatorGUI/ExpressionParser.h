#ifndef EXPRESSIONPARSER_H
#define EXPRESSIONPARSER_H

#include "Fraction.h"
#include <QString>
#include <QStringList>
#include <QVector>

// Parses a string token into a Fraction (e.g. "3/4" → Fraction(3,4))
Fraction parseFraction(const QString& token);

// Converts an infix token list (e.g. {"1/2", "+", "3/4"}) to Reverse Polish Notation
QVector<QString> toRPN(const QStringList& tokens);

// Evaluates an RPN token list and returns the result as a Fraction
Fraction evalRPN(const QVector<QString>& rpn);

// Parses and evaluates an infix expression string (e.g. "1/2 + 3/4")
Fraction parseExpression(const QString& expr);

QStringList preprocessUnaryMinus(const QStringList& tokens);

// Operator helpers
int getPrecedence(const QString& op);
bool isOperator(const QString& token);
bool isRightAssociative(const QString& op);

#endif // EXPRESSIONPARSER_H
