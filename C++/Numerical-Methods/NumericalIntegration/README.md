# Quadrature Integration Problem on \([0.1; 2]\)

Approximate the integral

$$
\int_{0.1}^{2} \sqrt{e^x - 1} \, dx
$$

with accuracy \(\varepsilon = 10^{-5}\).

---

### 1. Composite Right Rectangle Rule

The step size \(h\) and number of partitions \(N\) for the integration interval \([a, b] = [0.1, 2]\) are estimated by

$$
N \geq \frac{(b - a)^2}{2\varepsilon} M_1, \quad M_1 = \max_{x \in [a,b]} |f'(x)|
$$

---

### 2. Composite Midpoint Rule

Step size and partition count given by

$$
N \geq \sqrt{\frac{(b - a)^3}{24\varepsilon} M_2}, \quad M_2 = \max_{x \in [a,b]} |f''(x)|
$$

---

### 3. Composite Simpson’s Rule

Step size and number of subintervals estimated by

$$
N \geq \sqrt[4]{\frac{(b - a)^5}{2880\varepsilon} M_4}, \quad M_4 = \max_{x \in [a,b]} |f^{(4)}(x)|
$$

---

### 4. Gaussian Quadrature Formula (Gauss)

For \(n = 4\), the formula degree of exactness is \(2n + 1 = 9\). Weight function \(p(x) = 1\).

The quadrature

$$
\int_a^b f(x) \, dx \approx \sum_{k=0}^n A_k f(x_k)
$$

is exact for all polynomials of degree \(\leq 2n + 1\) if:

$$
A_k = \int_a^b \frac{\omega_{n+1}(x)}{(x - x_k) \omega'_{n+1}(x_k)} dx, \quad k=0, \ldots, n
$$

where \(\omega_{n+1}(x)\) is orthogonal w.r.t. \(p(x) = 1\) on \([a,b]\) to all polynomials \(Q_m(x)\) of degree \(\leq n\):

$$
\int_a^b \omega_{n+1}(x) Q_m(x) dx = 0, \quad m=0,1,\ldots,n
$$

Nodes \(x_k\) are roots of Legendre polynomial \(P_{n+1}(x)\).

For \(n=4\) the roots on \([-1,1]\) are:

$$
x_0 = 0.906179845938664, \quad x_1 = 0.538469310105683, \quad x_2 = 0, \quad x_3 = -0.538469310105683, \quad x_4 = -0.906179845938664
$$

Linear transform for \([0.1, 2]\):

$$
x_k^{new} = \frac{b - a}{2} x_k + \frac{b + a}{2} = 0.95 x_k + 1.05, \quad k=0,\ldots,4
$$

Weights on \([-1,1]\):

$$
A_0 = A_4 = 0.236926885036189, \quad A_1 = A_3 = 0.478628670499366, \quad A_2 = 0.568888888888889
$$

Rescaled weights:

$$
A_k^{new} = \frac{b - a}{2} A_k = 0.95 A_k
$$

Final quadrature formula:

$$
\int_{0.1}^{2} f(x) dx \approx \sum_{k=0}^4 A_k^{new} f\big(x_k^{new}\big)
$$
