#include <iostream>
#include <vector>
#include <cmath>
#include <iomanip>
#include <fstream>

#ifndef M_PI
#define M_PI 3.14159265358979323846
#endif

const int n = 10;
const int factorial_n1 = 39916800; // 11!
double h = 1.0 / n;
int j = 1;
double alpha_j = 0.1 + 0.05 * j;
double a = alpha_j;               // left boundary of interval
double b = 1 + alpha_j;           // right boundary of interval

// function definition
double f(double x) {
    return alpha_j * std::exp(-x) + (1 - alpha_j) * std::sin(x);
}

// Gauss elimination method to solve linear system Ax = b
std::vector<double> gaussSolve(std::vector<std::vector<double>> A, std::vector<double> b) {
    int size = b.size();
    for (int i = 0; i < size; i++) {
        // partial pivoting for numerical stability
        int maxRow = i;
        for (int k = i + 1; k < size; k++) {
            if (std::abs(A[k][i]) > std::abs(A[maxRow][i])) {
                maxRow = k;
            }
        }
        std::swap(A[i], A[maxRow]);
        std::swap(b[i], b[maxRow]);

        // elimination process
        for (int k = i + 1; k < size; k++) {
            double coeff = A[k][i] / A[i][i];
            for (int j = i; j < size; j++) {
                A[k][j] -= coeff * A[i][j];
            }
            b[k] -= coeff * b[i];
        }
    }

    // back substitution to find solution vector x
    std::vector<double> x(size);
    for (int i = size - 1; i >= 0; i--) {
        x[i] = b[i];
        for (int j = i + 1; j < size; j++) {
            x[i] -= A[i][j] * x[j];
        }
        x[i] /= A[i][i];
    }
    return x;
}

// return polynomial
double evaluatePolynomial(const std::vector<double>& coeffs, double x) {
    double result = 0;
    for (int k = 0; k < static_cast<int>(coeffs.size()); ++k) {
        result += coeffs[k] * std::pow(x, k);
    }
    return result;
}

// w = (x-x0)...(x-x_n)
double omega(const std::vector<double>& x_vals, double x) {
    double result = 1.0;
    for (double xi : x_vals) {
        result *= (x - xi);
    }
    return result;
}

// w'(x_i)
double omega_derivative_at(const std::vector<double>& x_vals, int i) {
    double xi = x_vals[i];
    double result = 1.0;
    for (int j = 0; j < static_cast<int>(x_vals.size()); ++j) {
        if (j != i) {
            result *= (xi - x_vals[j]);
        }
    }
    return result;
}

// return lagrange polynomial
double lagrangeInterpolation(double x, const std::vector<double>& x_vals, const std::vector<double>& y_vals) {
    int n = static_cast<int>(x_vals.size());
    double result = 0.0;
    double omega_x = omega(x_vals, x);
    for (int i = 0; i < n; ++i) {
        double term = y_vals[i] * omega_x / ((x - x_vals[i]) * omega_derivative_at(x_vals, i));
        result += term;
    }
    return result;
}

// generate Chebyshev nodes of the first kind on [a;b]
std::vector<double> chebyshevNodes(int n, double a, double b) {
    std::vector<double> nodes(n + 1);
    for (int k = 0; k <= n; ++k) {
        nodes[k] = 0.5 * (a + b) + 0.5 * (b - a) * std::cos(M_PI * (2 * k + 1) / (2 * (n + 1)));
    }
    return nodes;
}

// compute spline moments M_i
std::vector<double> computeSplineMoments(const std::vector<double>& x_vals, const std::vector<double>& f_vals) {
    std::vector<double> h_vals(n);
    for (int i = 1; i <= n; ++i) {
        h_vals[i - 1] = x_vals[i] - x_vals[i - 1];
    }

    // coefficients of tridiagonal system
    std::vector<double> a(n - 1), b(n - 1), c(n - 1), d(n - 1);
    for (int i = 1; i < n; ++i) {
        double hi = h_vals[i - 1];
        double hi1 = h_vals[i];
        a[i - 1] = hi / 6.0;
        b[i - 1] = (hi + hi1) / 3.0;
        c[i - 1] = hi1 / 6.0;
        d[i - 1] = (f_vals[i + 1] - f_vals[i]) / hi1 - (f_vals[i] - f_vals[i - 1]) / hi;
    }

    // Thomas method
    std::vector<double> alpha(n - 1), beta(n - 1);
    alpha[0] = -c[0] / b[0];
    beta[0] = d[0] / b[0];

    for (int i = 1; i < n - 1; ++i) {
        double denom = b[i] + a[i] * alpha[i - 1];
        alpha[i] = -c[i] / denom;
        beta[i] = (d[i] - a[i] * beta[i - 1]) / denom;
    }

    // back substitution of Thomas method
    std::vector<double> M(n + 1);
    M[0] = 0;
    M[n] = 0;
    M[n - 1] = beta[n - 2];
    for (int i = n - 3; i >= 0; --i) {
        M[i + 1] = alpha[i] * M[i + 2] + beta[i];
    }

    return M;
}

// evaluate cubic spline S(x) using spline moments M_i and nodes values
double evaluateSpline(double x, const std::vector<double>& x_vals, const std::vector<double>& f_vals, const std::vector<double>& M_vals) {
    int i = 1;
    while (i < static_cast<int>(x_vals.size()) && x > x_vals[i]) i++;
    i = std::max(1, i);

    double xi_1 = x_vals[i - 1];
    double xi = x_vals[i];
    double hi = xi - xi_1;

    double A = (xi - x) / hi;
    double B = (x - xi_1) / hi;

    double S = M_vals[i - 1] * std::pow(A, 3) * hi / 6.0
        + M_vals[i] * std::pow(B, 3) * hi / 6.0
        + (f_vals[i - 1] - M_vals[i - 1] * hi * hi / 6.0) * A
        + (f_vals[i] - M_vals[i] * hi * hi / 6.0) * B;
    return S;
}

int main() {
    std::ofstream out("output.txt");

    std::vector<double> x_values(n + 1);
    std::vector<double> f_values(n + 1);

    // uniform grid on [a;b], f(x) at nodes
    for (int i = 0; i <= n; ++i) {
        x_values[i] = a + i * h;
        f_values[i] = f(x_values[i]);
    }

    // points of interest for evaluation
    double x_star = x_values[0] + (2.0 / 3.0) * h;
    double x_dstar = x_values[5] + 0.5 * h;
    double x_tstar = x_values[n] - (1.0 / 3.0) * h;

    out << "x*: " << x_star << "\n";
    out << "x**: " << x_dstar << "\n";
    out << "x***: " << x_tstar << "\n";

    out << "1. Grid and function values table:\n";
    out << "------------------------------\n";
    out << std::setw(10) << "x_i" << std::setw(20) << "f(x_i)" << "\n";
    out << "------------------------------\n";
    for (int i = 0; i <= n; ++i) {
        out << std::setw(10) << x_values[i] << std::setw(20) << f_values[i] << "\n";
    }
    out << "------------------------------\n";

    // least squares approximation polynomial degree m = n/2
    int m = n / 2;
    std::vector<std::vector<double>> A(m + 1, std::vector<double>(m + 1));
    std::vector<double> b_vec(m + 1, 0);

    // building linear system Ax = b
    for (int k = 0; k <= m; ++k) {
        for (int i = 0; i <= n; ++i) {
            double xk = std::pow(x_values[i], k);
            b_vec[k] += f_values[i] * xk;
            for (int j = 0; j <= m; ++j) {
                A[k][j] += xk * std::pow(x_values[i], j);
            }
        }
    }

    // solve for polynomial coefficients c_k
    std::vector<double> coeffs = gaussSolve(A, b_vec);

    out << "\nCoefficients c_k of the approximating polynomial phi(x):\n";
    for (int k = 0; k <= m; ++k) {
        out << "c[" << k << "] = " << coeffs[k] << "\n";
    }
    out << "\n";

    // evaluate polynomial at control points
    double f_star_approx = evaluatePolynomial(coeffs, x_star);
    double f_dstar_approx = evaluatePolynomial(coeffs, x_dstar);
    double f_tstar_approx = evaluatePolynomial(coeffs, x_tstar);

    // calculate and print errors for polynomial approximation
    out << "\nErrors in polynomial approximation:\n";
    out << "Error at x*: " << std::fabs(f(x_star) - f_star_approx) << "\n";
    out << "Error at x**: " << std::fabs(f(x_dstar) - f_dstar_approx) << "\n";
    out << "Error at x***: " << std::fabs(f(x_tstar) - f_tstar_approx) << "\n";

    out << std::scientific << "\nErrors in nodes x*, x**, x***:\n";
    out << "r(x*) = " << f(x_star) - f_star_approx << "\n";
    out << "r(x**) = " << f(x_dstar) - f_dstar_approx << "\n";
    out << "r(x***) = " << f(x_tstar) - f_tstar_approx << "\n";

    // mean squared error
    double mse = 0.0;
    for (int i = 0; i <= n; ++i) {
        double phi_val = evaluatePolynomial(coeffs, x_values[i]);
        double diff = f_values[i] - phi_val;
        mse += diff * diff;
    }

    double sigma = std::sqrt(mse / (n + 1));
    out << std::fixed << "\nRoot mean square deviation between f and phi: sigma = " << std::scientific << sigma << "\n";

    double pn_star = lagrangeInterpolation(x_star, x_values, f_values);
    double pn_dstar = lagrangeInterpolation(x_dstar, x_values, f_values);
    double pn_tstar = lagrangeInterpolation(x_tstar, x_values, f_values);

    out << std::fixed << "\nValues of the Lagrange interpolation polynomial:\n";
    out << "Pn(x*) = " << pn_star << "\n";
    out << "Pn(x**) = " << pn_dstar << "\n";
    out << "Pn(x***) = " << pn_tstar << "\n";

    out << std::scientific << "\nInterpolation errors (residuals):\n";
    out << "r(x*) = " << f(x_star) - pn_star << "\n";
    out << "r(x**) = " << f(x_dstar) - pn_dstar << "\n";
    out << "r(x***) = " << f(x_tstar) - pn_tstar << "\n";

    double max_f_derivative_11 = 0.969561615246436; // maximum of eleventh derivative of f(x)
    double lagrange_error_x_star = (max_f_derivative_11 / factorial_n1) * std::fabs(omega(x_values, x_star));
    double lagrange_error_x_dstar = (max_f_derivative_11 / factorial_n1) * std::fabs(omega(x_values, x_dstar));
    double lagrange_error_x_tstar = (max_f_derivative_11 / factorial_n1) * std::fabs(omega(x_values, x_tstar));

    out << "Upper bound estimate of Lagrange interpolation error at x* = " << lagrange_error_x_star << "\n";
    out << "Upper bound estimate of Lagrange interpolation error at x** = " << lagrange_error_x_dstar << "\n";
    out << "Upper bound estimate of Lagrange interpolation error at x*** = " << lagrange_error_x_tstar << "\n";

    std::vector<double> x_cheb = chebyshevNodes(n, a, b);
    std::vector<double> f_cheb(n + 1);
    for (int i = 0; i <= n; ++i) {
        f_cheb[i] = f(x_cheb[i]);
    }

    double pn_cheb_star = lagrangeInterpolation(x_star, x_cheb, f_cheb);
    double pn_cheb_dstar = lagrangeInterpolation(x_dstar, x_cheb, f_cheb);
    double pn_cheb_tstar = lagrangeInterpolation(x_tstar, x_cheb, f_cheb);

    out << "\nLagrange interpolation with Chebyshev nodes:\n";
    out << "Pn(x*) = " << pn_cheb_star << "\n";
    out << "Pn(x**) = " << pn_cheb_dstar << "\n";
    out << "Pn(x***) = " << pn_cheb_tstar << "\n";

    out << std::scientific << "Errors at points for Chebyshev interpolation:\n";
    out << "r(x*) = " << f(x_star) - pn_cheb_star << "\n";
    out << "r(x**) = " << f(x_dstar) - pn_cheb_dstar << "\n";
    out << "r(x***) = " << f(x_tstar) - pn_cheb_tstar << "\n";

    // cubic spline interpolation
    std::vector<double> M = computeSplineMoments(x_values, f_values);

    double s_x_star = evaluateSpline(x_star, x_values, f_values, M);
    double s_x_dstar = evaluateSpline(x_dstar, x_values, f_values, M);
    double s_x_tstar = evaluateSpline(x_tstar, x_values, f_values, M);

    out << "\nCubic spline interpolation values:\n";
    out << "S(x*) = " << s_x_star << "\n";
    out << "S(x**) = " << s_x_dstar << "\n";
    out << "S(x***) = " << s_x_tstar << "\n";

    out << "Cubic spline interpolation errors:\n";
    out << "r(x*) = " << f(x_star) - s_x_star << "\n";
    out << "r(x**) = " << f(x_dstar) - s_x_dstar << "\n";
    out << "r(x***) = " << f(x_tstar) - s_x_tstar << "\n";

    out.close();
    return 0;
}