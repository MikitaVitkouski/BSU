# Root Finding for Nonlinear Equation

Find the root of

$$
f(x) = e^{-x} - (x - 1)^2 = 0
$$

with accuracy

$$
\varepsilon = 10^{-7}
$$

using three methods:
- Simple Iteration Method
- Newton's Method
- Chebyshev's Method

---

## Initial Approximation

The root is isolated on the interval

$$
s_0 = [-3.25, -2.5]
$$

chosen by the bisection method and Newton's convergence conditions are satisfied at

$$
x_0 = -3.25
$$

---

## Iterative Methods

### 1. Simple Iteration

Iteration function:

$$
g(x) = -\ln \left( (x - 1)^2 \right)
$$

Iteration formula:

$$
x_{k+1} = g(x_k)
$$

Convergence requires:

$$
|g'(x)| < 1 \quad \text{on } s_0
$$

---

### 2. Newton's Method

Iteration formula:

$$
x_{k+1} = x_k - \frac{f(x_k)}{f'(x_k)}
$$

where

$$
f'(x) = -e^{-x} - 2(x - 1)
$$

---

### 3. Chebyshev's Method

Iteration formula:

$$
x_{k+1} = x_k - \frac{f(x_k)}{f'(x_k)} - \frac{f(x_k)^2 f''(x_k)}{2 (f'(x_k))^3}
$$

where

$$
f''(x) = e^{-x} - 2
$$

---

## Stopping Criterion

Stop when

$$
|x_{k+1} - x_k| \leq \varepsilon
$$

---

## Comparison

Compare methods by:
- Rate of convergence (theoretical and practical)
- Accuracy via residual error:

$$
r_k = |f(x_k)|
$$
