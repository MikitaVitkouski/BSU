# Interpolation and Approximation of a Function

We consider the function:

$$
f(x) = \alpha_j e^{-x} + (1 - \alpha_j) \sin(x), \quad \text{where } \alpha_j = 0.1 + 0.05j, \quad j = 1
$$

Thus:

$$
\alpha_j = 0.15
$$

The interpolation interval is:

$$
[a; b] = [\alpha_j; 1 + \alpha_j] = [0.15; 1.15]
$$

This interval is divided into \( n = 10 \) equal parts with a step size:

$$
h = \frac{b - a}{n} = 0.1
$$

---

## Objectives

1. **Construct interpolation nodes and evaluate the function:**

   - Nodes:
     $$
     x_i = a + i h, \quad i = 0, \dots, n
     $$
   - Function values at nodes:
     $$
     f_i = f(x_i)
     $$

2. **Approximation using the method of least squares:**

   - Construct a polynomial of degree \( m = \frac{n}{2} = 5 \) that approximates \( f(x) \)
   - Evaluate the polynomial at control points:
     $$
     x^* = x_0 + \frac{2h}{3}, \quad x^{****} = x_{n/2} + \frac{h}{2}, \quad x^{*********} = x_n - \frac{h}{3}
     $$
   - Compute the approximation errors:
     $$
     r(x) = f(x) - \varphi(x)
     $$

3. **Interpolation using the Lagrange polynomial with uniform nodes:**

   - Construct the interpolation polynomial \( P_n(x) \)
   - Evaluate it at the control points \( x^*, x^{****}, x^{*********} \)
   - Compute interpolation errors:
     $$
     r(x) = f(x) - P_n(x)
     $$

4. **Interpolation using the Lagrange polynomial with Chebyshev nodes:**

   - Compute Chebyshev nodes on the interval \([a; b]\)
   - Construct the Chebyshev interpolation polynomial \( P_{\text{cheb}}(x) \)
   - Evaluate it at control points \( x^*, x^{****}, x^{*********} \)
   - Compute interpolation errors:
     $$
     r(x) = f(x) - P_{\text{cheb}}(x)
     $$

5. **Cubic spline interpolation:**

   - Use uniform nodes
   - Construct the spline \( S(x) \)
   - Evaluate it at control points \( x^*, x^{****}, x^{*********} \)
   - Compute interpolation errors:
     $$
     r(x) = f(x) - S(x)
     $$
