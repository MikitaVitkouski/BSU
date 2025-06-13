# Numerical Solution of the Cauchy Problem

This project implements numerical methods for solving the Cauchy problem using:

- Explicit Euler Method (1st order)
- Explicit Runge–Kutta Method (2nd order, with \( \beta = 1 \))
- Implicit Adams Method (Trapezoidal Rule, using Newton's method for nonlinearity)

## 1. Problem Statement

We consider the Cauchy problem of the form:

\[
u'(t) = f(t, u(t)), \quad t \in [t_0, T], \quad u(t_0) = u_0,
\]

where:

- \( \alpha_j = 0.15 \),
- \( [t_0, T] = [\alpha_j, 1 + \alpha_j] = [0.15, 1.15] \),
- \( f(t) = \alpha_j e^{-t} + (1 - \alpha_j)\sin(t) \),
- \( f'(t) = -\alpha_j e^{-t} + (1 - \alpha_j)\cos(t) \),
- Therefore, the derivative becomes:

\[
u'(t) = ut + t f'(t) = ut + t(-0.15 e^{-t} + 0.85 \cos(t)),
\]

- The exact solution is given by:

\[
u(t) = t f(t) = t \left( \alpha_j e^{-t} + (1 - \alpha_j)\sin(t) \right),
\]

- Initial value:

\[
u_0 = \alpha_j f(\alpha_j) = 0.15 \cdot f(0.15) \approx 0.0384192913599477.
\]

## 2. Methods

### 2.1. Exact Solution (for error estimation)

\[
u(t) = 120 t e^{-t} \left( 3 + 17 e^{t} \sin(t) \right)
\]

(This form may be derived or obtained via symbolic computation in Mathematica or verified numerically.)

### 2.2. Explicit Euler Method (1st Order)

The explicit Euler method is given by:

\[
y_{k+1} = y_k + h f(t_k, y_k), \quad y_0 = u_0,
\]

where:

- \( h = \frac{T - t_0}{N} = 0.1 \),
- \( t_k = t_0 + kh \),
- \( N = 10 \) is the number of intervals.

### 2.3. Runge–Kutta Method (2nd Order, \( \beta = 1 \))

Coefficients:

- \( A_1 = \beta = 1 \),
- \( \alpha_1 = \frac{1}{2} \), \( \beta_{10} = \frac{1}{2} \)

The scheme:

\[
\begin{aligned}
\varphi_0 &= h f(t_k, y_k), \\
\varphi_1 &= h f\left(t_k + \frac{h}{2}, y_k + \frac{1}{2}\varphi_0\right), \\
y_{k+1} &= y_k + \varphi_1.
\end{aligned}
\]

### 2.4. Implicit Adams Method (2nd Order, Newton Implementation)

The trapezoidal rule is:

\[
y_{k+1} = y_k + \frac{h}{2} \left[ f(t_k, y_k) + f(t_{k+1}, y_{k+1}) \right]
\]

Nonlinear equation for \( y_{k+1} \):

\[
\phi(y_{k+1}) = y_{k+1} - y_k - \frac{h}{2} \left[ f(t_k, y_k) + f(t_{k+1}, y_{k+1}) \right] = 0
\]

Solve using Newton's method:

\[
y_{k+1}^{(i+1)} = y_{k+1}^{(i)} - \frac{\phi(y_{k+1}^{(i)})}{\phi'(y_{k+1}^{(i)})}
\]

with:

\[
\phi'(y_{k+1}^{(i)}) = 1 - \frac{h}{2} \cdot \frac{\partial f}{\partial u}(t_{k+1}, y_{k+1}^{(i)}) = 1 - \frac{h}{2} \cdot t_{k+1}
\]

Iteration continues until:

\[
|y_{k+1}^{(i+1)} - y_{k+1}^{(i)}| < \varepsilon, \quad \varepsilon = 10^{-6}
\]

## 3. Evaluation

- Use 10 uniform steps over \( [0.15, 1.15] \)
- At each node, compute the absolute error:

\[
\text{error}_k = |y_k - u(t_k)|
\]

- Tabulate results and compare all three methods.
- Assess global error and method accuracy.
