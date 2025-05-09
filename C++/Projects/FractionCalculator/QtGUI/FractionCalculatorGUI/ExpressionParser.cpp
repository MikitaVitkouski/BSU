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

// Converts an infix expression (standard mathematical notation) to Reverse Polish Notation (RPN)
QVector<QString> toRPN(const QStringList& tokens) {
    QVector<QString> output; // This will store the resulting RPN expression
    std::stack<QString> ops; // Stack for operators and parentheses

    for(const QString& token : tokens) {
        if (token == "(") {
            ops.push(token); // Push opening parentheses to the stack
        } else if (token == ")") {
            // Process everything until the matching opening parenthesis
            while(!ops.empty() && ops.top() != "(") {
                output.push_back(ops.top());
                ops.pop();
            }
            if(ops.empty()) throw std::runtime_error("Mismatched parentheses");
            ops.pop(); // Pop the "(" from the stack
        } else if (isOperator(token)) {
            // Process operators based on precedence
            while (!ops.empty() && isOperator(ops.top())) {
                if ((getPrecedence(ops.top()) > getPrecedence(token)) ||
                    (getPrecedence(ops.top()) == getPrecedence(token) && !isRightAssociative(token))) {
                    output.push_back(ops.top());
                    ops.pop();
                } else break;
            }
            ops.push(token);
        } else {
            // If the token is not an operator or parentheses, it's a fraction or number
            output.push_back(token);
        }

    }

    // Pop remaining operators from the stack
    while (!ops.empty()) {
        if (ops.top() == "(" || ops.top() == ")") throw std::runtime_error("Mismatched parentheses");
        output.push_back(ops.top());
        ops.pop();
    }
    return output;
}

// Evaluates a Reverse Polish Notation (RPN) expression
Fraction evalRPN(const QVector<QString>& rpn) {
    std::stack<Fraction> st;

    for(const QString& token : rpn) {
        if (isOperator(token)) {
            // If the token is an operator, pop two operands from the stack and apply the operator
            if (st.size() < 2) throw std::runtime_error("Insufficient operands");
            Fraction b = st.top(); st.pop();
            Fraction a = st.top(); st.pop();

            if (token == "+") st.push(a + b);
            else if (token == "-") st.push(a - b);
            else if (token == "*") st.push(a * b);
            else if (token == "/") st.push(a / b);
            else if (token == "^") st.push(a ^ b.getNumerator());
        } else {
             // If the token is not an operator, it must be a fraction or a number
            st.push(parseFraction(token));
        }
    }

    if(st.size() != 1) throw std::runtime_error("Error while evaluating the expression");
    return st.top();
}

// Parses a mathematical expression and returns the result as a Fraction
Fraction parseExpression(const QString& expr) {
    // Split the expression into tokens
    QStringList tokens = expr.split(' ', Qt::SkipEmptyParts);

    // Convert the tokens to RPN
    auto rpn = toRPN(tokens);

    return evalRPN(rpn);
}
