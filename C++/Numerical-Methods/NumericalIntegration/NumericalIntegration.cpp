#include <iostream>
#include <cmath>
#include <iomanip>
#include <vector>
#include <algorithm>
#include <fstream>

const double a{ 0.1 };
const double b{ 2.0 };

// evaluate f(x)
double f(double x) {
    return std::sqrt(std::exp(x) - 1.0);
}

// quadratic formula of right rectangles (algebraic degree of precision = 0)
double right_rectangle(double a, double b, int N) {
    double h = (b - a) / N;
    double sum{ 0.0 };
    for (int i = 1; i <= N; ++i) {
        double x = a + i * h;
        sum += f(x);
    }
    return h * sum;
}

// count N, h with the help of Runge's rule
double right_rectangle_runge(double a, double b, double epsilon, int& final_N, double& final_h) {
    int N = 4;
    double I_h = right_rectangle(a, b, N);
    double I_h2 = right_rectangle(a, b, 2 * N);

    while (std::fabs(I_h2 - I_h) > epsilon) {
        N *= 2;
        I_h = I_h2;
        I_h2 = right_rectangle(a, b, 2 * N);
    }

    final_N = 2 * N;
    final_h = (b - a) / final_N;

    return I_h2;
}

// quadratic formula of middle rectangles (algebraic degree of precision = 1)
double middle_rectangle(double a, double b, int N) {
    double h = (b - a) / N;
    double sum{ 0.0 };
    for (int i = 0; i < N; ++i) {
        double x = a + (i + 0.5) * h;
        sum += f(x);
    }
    return h * sum;
}

// quadratic Simpson formula (algebraic degree of precision = 3)
double simpson(double a, double b, int N) {
    if (N % 2 != 0) ++N;
    double h = (b - a) / N;
    double sum = f(a) + f(b);
    for (int i = 1; i < N; ++i) {
        double x = a + i * h;
        sum += (i % 2 == 0 ? 2.0 : 4.0) * f(x);
    }
    return h / 3.0 * sum;
}

// return sum_i=0->i=n(A_k*f(x_k))
double Gauss(const std::vector<double>& xk, const std::vector<double>& Ak, const int& N) {
    double result{ 0.0 };
    for (int i = 0; i < N; ++i) {
        double mul = Ak[i] * f((b-a)/2.0*xk[i] + (b+a)/2.0);
        result += mul;
    }
    return (b - a) / 2.0 * result;
}

// compound Gauss formula
double GaussComposite(double a, double b, int K, const std::vector<double>& xk, const std::vector<double>& Ak) {
    double h = (b - a) / K;
    double result = 0.0;

    for (int i = 0; i < K; ++i) {
        double a_i = a + i * h;
        double midpoint = a_i + h / 2.0;

        for (int k = 0; k < xk.size(); ++k) {
            double x_local = (h / 2.0) * xk[k] + midpoint;
            double A_local = (h / 2.0) * Ak[k];
            result += A_local * f(x_local);
        }
    }

    return result;
}

int main() {
    std::ofstream out("output.txt");

    int N_right{};
    double h_right{};
    double epsilon{ 1e-5 };

    double result_right = right_rectangle_runge(a, b, epsilon, N_right, h_right);

    int N_middle{ 456 }; // found from error's formula (epsilon = 1e-5)
    int N_simpson{ 40 }; // found from error's formula (epsilon = 1e-5)

    double result_middle = middle_rectangle(a, b, N_middle);
    double result_simpson = simpson(a, b, N_simpson);

    out << std::fixed << std::setprecision(10);
    out << "Right rectangles (Runge, epsilon=" << epsilon << ", N=" << N_right << ", h=" << h_right << "): " << result_right << std::endl;
    out << "Middle rectangles (N=" << N_middle << "):  " << result_middle << std::endl;
    out << "Simpson (N=" << N_simpson << "):                " << result_simpson << std::endl;

    std::vector<double> x_k{ -0.906179845938664, -0.538469310105683, 0.0, 0.538469310105683, 0.906179845938664 }; // x_k for [a;b] = [-1;1] and n = 4 (5 in old literature)
    std::vector<double> A_k{ 0.236926885036189, 0.47862870499366, 0.5688888888888889, 0.47862870499366, 0.236926885036189 }; // A_k for [a;b] = [-1;1] and n = 4 (5 in old literature)
    std::vector<double> x_k5 {-0.932469514203152, -0.661209386466264, -0.238619186083190, 0.238619186083190, 0.661209386466264, 0.932469514203152 }; // x_k for [a;b] = [-1;1] and n = 5 (6 in old literature)
    std::vector<double> A_k5 {0.171324492379170, 0.360761573048138, 0.4679139345722691, 0.4679139345722691, 0.360761573048138, 0.171324492379170}; // A_k for [a;b] = [-1;1\ and n = 5 (6 in old literature)

    int K = 8;
    double result_Gauss4 = Gauss(x_k, A_k, 5);
    double result_Gausscompound = GaussComposite(0.1, 2.0, K, x_k, A_k);
    out << "Gauss (n = 4): " << result_Gauss4 << "\n";
    out << "Gauss compound (n = 4, K = 8): " << result_Gausscompound << "\n";
    double result_Gauss5 = Gauss(x_k5, A_k5, 6);
    out << "Gauss (n = 5): " << result_Gauss5 << "\n";

    double real_value{ 2.64577597114955282788543162027 }; // real value of integral f(x)dx on [0.1;2] to find real errors of the methods, tolerance is 30 signs after .
    out << std::scientific << "Real error for right rectangles method: " << real_value - result_right << std::endl;
    out << "Real error for middle rectangles method: " << real_value - result_middle << std::endl;
    out << "Real error for Simpson formula: " << real_value - result_simpson << std::endl;
    out << "Real error for Gauss formula (n = 4): " << real_value - result_Gauss4 << std::endl;
    out << "Real error for Gauss formula (n = 5): " << real_value - result_Gauss5 << std::endl;
    out << "Real error for compound Gauss formula: " << real_value - result_Gausscompound << std::endl;

    return 0;
}