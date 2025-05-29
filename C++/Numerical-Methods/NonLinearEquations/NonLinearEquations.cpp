#include <iostream>
#include <cmath>
#include <iomanip>
#include <fstream>

// function definition
double f(double x) {
    return exp(-x) - pow(x - 1, 2);
}

// first derivative of f
double df(double x) {
    return -exp(-x) - 2 * x + 2;
}

// second derivative of f
double d2f(double x) {
    return exp(-x) - 2;
}

// iteration function g(x) for the simple iteration method
double g(double x) {
    return -log(pow(x - 1, 2));
}

int main() {
    setlocale(LC_ALL, "Rus");

    // initial guess and tolerance
    double x0 = -3.25;
    double tol = 1e-7;

    int iter_newton = 0, iter_iteration = 0, iter_chebyshev = 0;

    std::ofstream out("output.txt");

    // simple iteration method
    out << "\nSimple iteration method:" << "\n";
    double x = x0;
    while (true) {
        double x_next = g(x); // simple iteration method's formula
        iter_iteration++;
        if (fabs(x_next - x) < tol) {
            out << std::fixed << std::setprecision(16) << "Approximated root: " << x_next << "endl" << std::endl;
            out << "Number of iterations: " << iter_iteration << std::endl;
            out << std::scientific << "Error: " << fabs(f(x_next)) << std::endl;
            break;
        }
        x = x_next;
    }

    out << "\nNewton method:" << std::endl;
    x = x0;
    while (true) {
        double fx = f(x);
        double dfx = df(x);

        double x_next = x - fx / dfx; // newton method's formula
        iter_newton++;
        if (fabs(x_next - x) < tol) {
            out << std::fixed << std::setprecision(16) << "Approximated root: " << x_next << std::endl;
            out << "Number of iterations: " << iter_newton << std::endl;
            out << std::scientific << "Error: " << fabs(f(x_next)) << std::endl;
            break;
        }
        x = x_next;
    }

    out << "\nChebyshev method:" << std::endl;
    x = x0;
    while (true) {
        double fx = f(x);
        double dfx = df(x);
        double d2fx = d2f(x);

        double x_next = x - fx / dfx - (pow(fx, 2) * d2fx) / (2 * pow(dfx, 3)); // chebyshev method's formula
        iter_chebyshev++;
        if (fabs(x_next - x) < tol) {
            out << std::fixed << std::setprecision(16) << "Approximated root: " << x_next << std::endl;
            out << "Number of iteration: " << iter_chebyshev << std::endl;
            out << std::scientific << "Error: " << fabs(f(x_next)) << std::endl;
            break;
        }
        x = x_next;
    }

    return 0;
}