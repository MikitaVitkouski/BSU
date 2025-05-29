#include <iostream>
#include <cmath>
#include <iomanip>
#include <vector>
#include <algorithm>
#include <fstream>

const double alpha_j = 0.15;
const double t0 = alpha_j;
const double T = 1.0 + alpha_j; // [t0;T]
const int N = 10;
const double h = (T - t0) / N; // step
const double EPS = 1e-6; // tolerance for newton_step

// exact solution of cauchy problem
double exact_solution(double t) {
    return (1.0 / 20.0) * std::exp(-t) * t * (3 + 17 * std::exp(t) * std::sin(t));
}

// f_tilde first derivative
double f_tilde_derivative(double t) {
    return -alpha_j * std::exp(-t) + (1.0 - alpha_j) * std::cos(t);
}

// right part of different equation
double f(double t, double u) {
    return u / t + t * f_tilde_derivative(t);
}

// first derivation by u of right part
double df_du(double t, double u) {
    return 1.0 / t;
}

// newton step to find y_guess
double newton_step(double t_k, double y_k, double t_k1, double y_guess) {
    double phi = y_guess - y_k - (h / 2.0) * (f(t_k, y_k) + f(t_k1, y_guess));
    double phi_der = 1.0 - (h / 2.0) * df_du(t_k1, y_guess);
    return y_guess - phi / phi_der;
}

// method to initialize start conditions
void initialize(std::vector<double>& t, std::vector<double>& y, std::vector<double>& y_exact, std::vector<double>& error) {
    t[0] = t0;
    y[0] = alpha_j * (alpha_j * std::exp(-alpha_j) + (1.0 - alpha_j) * std::sin(alpha_j));
    y_exact[0] = exact_solution(t[0]);
    error[0] = std::abs(y[0] - y_exact[0]);
}

int main() {
    std::ofstream out("output.txt");

    std::vector<double> t(N + 1);
    std::vector<double> y(N + 1);
    std::vector<double> y_exact(N + 1);
    std::vector<double> error(N + 1);

    t[0] = t0;
    y[0] = alpha_j * (alpha_j * std::exp(-alpha_j) + (1.0 - alpha_j) * std::sin(alpha_j));
    y_exact[0] = exact_solution(t[0]);
    error[0] = std::abs(y[0] - y_exact[0]);

    // explicit Euler method: y_k+1 = y_k + hf_k
    for (int k = 0; k < N; ++k) {
        t[k + 1] = t[k] + h; // next time moment
        y[k + 1] = y[k] + h * f(t[k], y[k]);
        y_exact[k + 1] = exact_solution(t[k + 1]); // write exact solution's value at the time moment t_k+1
        error[k + 1] = std::abs(y[k + 1] - y_exact[k + 1]); // compute error here
    }

    out << "\n" << "Explicit Euler method: " << std::endl;
    out << std::fixed << std::setprecision(10);
    out << "k\tt_k\t\ty_k\t\tu(t_k)\t\t|y_k - u(t_k)|\n";

    for (int k = 0; k <= N; ++k) {
        out << k << "\t"
            << t[k] << "\t"
            << y[k] << "\t"
            << y_exact[k] << "\t"
            << std::scientific << error[k] << std::fixed << "\n";
    }

    initialize(t, y, y_exact, error);
    // explicit Runge-Kutta method (A_1 = 1): y_k+1 = y_k + hf(t_k + h/2.0, y_k + hf_k/2.0)
    for (int k = 0; k < N; ++k) {
        t[k + 1] = t[k] + h;

        double phi0 = h * f(t[k], y[k]);
        double phi1 = h * f(t[k] + h / 2.0, y[k] + phi0 / 2.0);
        y[k + 1] = y[k] + phi1;

        y_exact[k + 1] = exact_solution(t[k + 1]); // write exact solution value's at the time moment t_k+1
        error[k + 1] = std::abs(y[k + 1] - y_exact[k + 1]); // compute error here
    }

    out << "\n" << "Explicit Runge-Kutta method (A_1 = 1): " << std::endl;
    out << std::fixed << std::setprecision(10);
    out << "k\tt_k\t\ty_k(RK2)\t\tu(t_k)\t\t|y_k - u(t_k)|\n";
    for (int k = 0; k <= N; ++k) {
        out << k << "\t"
            << t[k] << "\t"
            << y[k] << "\t"
            << y_exact[k] << "\t";
        out << std::scientific << std::setprecision(5) << error[k] << std::fixed << std::setprecision(10) << "\n";
    }

    initialize(t, y, y_exact, error);
    // implicit Adams method implemented with Newton's method
    for (int k = 0; k < N; ++k) {
        t[k + 1] = t[k] + h;

        double y_next = y[k];
        double y_prev;

        do {
            y_prev = y_next;
            y_next = newton_step(t[k], y[k], t[k + 1], y_prev); // Newton's method
        } while (std::abs(y_next - y_prev) > EPS);

        y[k + 1] = y_next;
        y_exact[k + 1] = exact_solution(t[k + 1]); // write exact solution's value at the time moment t_k+1
        error[k + 1] = std::abs(y[k + 1] - y_exact[k + 1]); // compute error right here
    }

    out << "\n" << "Implicit Adams method implemented with Newton's method: " << std::endl;
    out << "k\t t_k\t\t y_k(Adams)\t u(t_k)\t\t |y_k - u(t_k)|\n";
    for (int k = 0; k <= N; ++k) {
        out << k << "\t " << std::fixed << std::setprecision(9) << t[k]
            << "\t " << y[k] << "\t " << y_exact[k] << "\t " << std::scientific << error[k] << std::fixed << "\n";
    }

    return 0;
}