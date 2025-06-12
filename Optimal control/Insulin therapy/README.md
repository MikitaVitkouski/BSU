# Insulin Therapy Model

This model describes the kinetics of glucose and insulin in the body of a Type 1 diabetic patient and consists of three subsystems:

## Insulin Subsystem
The equations governing the insulin subsystem are as follows:

$$
\frac{dS_1(t)}{dt} = u(t) - kS_1(t)
$$

$$
\frac{dS_2(t)}{dt} = kS_1(t) - kS_2(t)
$$

$$
\frac{dI(t)}{dt} = \frac{k}{V_I} S_2(t) - k_e I(t)
$$

## Insulin-Glucose Interaction Subsystem
The equations governing the interaction between insulin and glucose are:

$$
\frac{dx_1(t)}{dt} = -k_{a1} x_1(t) + k_{b1} I(t)
$$

$$
\frac{dx_2(t)}{dt} = -k_{a2} x_2(t) + k_{b2} I(t)
$$

$$
\frac{dx_3(t)}{dt} = -k_{a3} x_3(t) + k_{b3} I(t)
$$

## Glucose Subsystem
The equations governing the glucose subsystem are:

$$
\frac{dQ_1(t)}{dt} = -x_1(t)Q_1(t) + k_{12}Q_2(t) - \left[ F_{c01}(G(t)) + F_R(G(t)) \right] + EGP_0 \left( 1 - x_3(t) \right) + v(t)
$$

$$
\frac{dQ_2(t)}{dt} = x_1(t)Q_1(t) - \left( k_{12} + x_2(t) \right) Q_2(t)
$$

Where:

- \( u(t) \) is the insulin infusion rate
- \( S_1(t) \) is the insulin amount in the bloodstream (mME)
- \( S_2(t) \) is the insulin amount in peripheral tissues (mME)
- \( I(t) \) is the insulin concentration in plasma (mME/L)
- \( x_1(t) \), \( x_2(t) \), and \( x_3(t) \) are coefficients representing the effect of insulin on glucose transport, glucose utilization, and endogenous glucose production, respectively
- \( Q_1(t) \) is the amount of glucose in the bloodstream (mmol)
- \( Q_2(t) \) is the amount of glucose in peripheral tissues (mmol)
- \( G(t) = \frac{Q_1(t)}{V_G} \) is the blood glucose level (mmol/L)

### Constants and Parameters
The constants and parameters in the model are:

- \( k = \frac{1}{55} \) — insulin appearance rate in blood or tissues after injection (1/min)
- \( k_e = 0.2 \) — insulin absorption rate (1/min)
- \( V_I = 7.2 \) — volume of insulin distribution (L)
- \( k_{a1} = 0.006 \), \( k_{a2} = 0.06 \), \( k_{a3} = 0.03 \) — glucose deactivation rates (1/min)
- \( k_{b1} = 3.072 \times 10^{-5} \), \( k_{b2} = 4.92 \times 10^{-5} \), \( k_{b3} = 0.00156 \) — insulin sensitivity for transport, removal, and liver glucose production (1/min)
- \( k_{12} = 0.066 \) — rate of glucose transfer from blood to peripheral tissues (1/min)
- \( EGP_0 = 0.966 \) — rate of endogenous glucose production in the liver when insulin is absent (mmol/min)
- \( F_{c01}(G) \) — glucose consumption rate in the central nervous system (mmol/min)
  - \( F_{c01}(G) = F_{01} \) if \( G \geq 4.5 \), \( F_{c01}(G) = \frac{F_{01} G}{4.5} \) otherwise
  - \( F_{01} = 0.582 \)
- \( F_R(G) \) — glucose production rate in the kidneys (mmol/min)
  - \( F_R(G) = 0.003 (G - 9) V_G \) if \( G \geq 9 \), 0 otherwise
- \( V_G = 9.6 \) — volume of glucose distribution (L)
- \( v(t) \) — glucose absorption rate (mmol/min), given by:

$$
v(t) = \frac{A_G t}{t_{\text{max},G}^2} \exp\left(-\frac{t}{t_{\text{max},G}}\right) \frac{1000 d}{M_w G}
$$

Where:
- \( A_G = 0.8 \) is the carbohydrate bioavailability (dimensionless)
- \( t_{\text{max},G} = 40 \) is the maximum time for glucose appearance in the bloodstream (min)
- \( M_w G = 180 \) is the molecular weight of glucose

### Initial Conditions
The initial conditions for the system of differential equations are:

- \( S_1(0) = 0 \), \( S_2(0) = 0 \), \( I(0) = 6 \)
- \( x_1(0) = 0.0634 \), \( x_2(0) = 0.0005 \), \( x_3(0) = 0.3138 \)
- \( Q_1(0) = 65.28 \), \( Q_2(0) = 10.1271 \)

### Experiments
The following experiments were conducted to track the patient's blood glucose level:

1. The patient did not eat (DG = 0) and did not receive insulin (u(t) ≡ 0).
2. The patient ate 36 XE during the first 18 minutes of the experiment and did not receive insulin.
3. The patient received 6000 units (6 ME) of insulin during the first minute and ate 36 XE during the first 18 minutes.

### Optimal Insulin Therapy
The goal of the insulin therapy is to select the insulin doses to keep the blood glucose level of the patient at a normal level (typically 6 mmol/L). The optimal control problem is formulated and solved to determine the insulin infusion schedule.