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

Construct interpolation nodes and evaluate the function:

$$
x_i = a + i h, \quad i = 0, \dots, n
$$

$$
f_i = f(x_i)
$$

Approximate using the method of least squares. Construct a polynomial of degree:

$$
m = \frac{n}{2} = 5
$$

Evaluate the polynomial at control points:

$$
x^{\ast} = x_0 + \frac{2h}{3}, \quad x^{\ast\ast} = x_{n/2} + \frac{h}{2}, \quad x^{\ast\ast\ast} = x_n - \frac{h}{3}
$$

Compute the approximation errors:

$$
r(x) = f(x) - \varphi(x)
$$

Construct the Lagrange interpolation polynomial with uniform nodes:

$$
P_n(x)
$$

Evaluate it at control points 

$$ 
x^{\ast}, x^{\ast\ast}, x^{\ast\ast\ast} 
$$ 

and compute interpolation errors:

$$
r(x) = f(x) - P_n(x)
$$

Construct the Lagrange interpolation polynomial with Chebyshev nodes:

$$
P_{\text{cheb}}(x)
$$

Evaluate it at control points 

$$ 
x^{\ast}, x^{\ast\ast}, x^{\ast\ast\ast} 
$$ 

and compute interpolation errors:

$$
r(x) = f(x) - P_{\text{cheb}}(x)
$$

Construct the cubic spline interpolation:

$$
S(x)
$$

Evaluate it at control points 

$$ 
x^{\ast}, x^{\ast\ast}, x^{\ast\ast\ast} 
$$ 

and compute interpolation errors:

$$
r(x) = f(x) - S(x)
$$
