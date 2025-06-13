# Insulin Therapy Model

This model describes the kinetics of glucose and insulin in the body of a Type 1 diabetic patient and consists of three subsystems:

## Insulin Subsystem

The equations governing the insulin subsystem are

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

The equations governing the interaction between insulin and glucose are

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

The equations governing the glucose subsystem are

$$
\frac{dQ_1(t)}{dt} = -x_1(t)Q_1(t) + k_{12}Q_2(t) - \left[ F_{c01}(G(t)) + F_R(G(t)) \right] + EGP_0 \left( 1 - x_3(t) \right) + v(t)
$$

$$
\frac{dQ_2(t)}{dt} = x_1(t)Q_1(t) - \left( k_{12} + x_2(t) \right) Q_2(t)
$$

Where

$$
u(t) \text{ is the insulin infusion rate}
$$

$$
S_1(t) \text{ is the insulin amount in the bloodstream (mME)}
$$

$$
S_2(t) \text{ is the insulin amount in peripheral tissues (mME)}
$$

$$
I(t) \text{ is the insulin concentration in plasma (mME/L)}
$$

$$
x_1(t), x_2(t), x_3(t) \text{ are coefficients representing insulin effects on glucose transport, utilization, and endogenous glucose production}
$$

$$
Q_1(t) \text{ is the amount of glucose in the bloodstream (mmol)}
$$

$$
Q_2(t) \text{ is the amount of glucose in peripheral tissues (mmol)}
$$

$$
G(t) = \frac{Q_1(t)}{V_G} \text{ is the blood glucose level (mmol/L)}
$$

### Constants and Parameters

$$
k = \frac{1}{55} \text{ — insulin appearance rate in blood or tissues after injection (1/min)}
$$

$$
k_e = 0.2 \text{ — insulin absorption rate (1/min)}
$$

$$
V_I = 7.2 \text{ — volume of insulin distribution (L)}
$$

$$
k_{a1} = 0.006, \quad k_{a2} = 0.06, \quad k_{a3} = 0.03 \text{ — glucose deactivation rates (1/min)}
$$

$$
k_{b1} = 3.072 \times 10^{-5}, \quad k_{b2} = 4.92 \times 10^{-5}, \quad k_{b3} = 0.00156 \text{ — insulin sensitivity (1/min)}
$$

$$
k_{12} = 0.066 \text{ — rate of glucose transfer from blood to peripheral tissues (1/min)}
$$

$$
EGP_0 = 0.966 \text{ — rate of endogenous glucose production in the liver without insulin (mmol/min)}
$$

Glucose consumption in CNS:

$$
F_{c01}(G) = \begin{cases} 
F_{01}, & G \geq 4.5 \\
\frac{F_{01} G}{4.5}, & G < 4.5
\end{cases}
$$

where

$$
F_{01} = 0.582
$$

Glucose production in kidneys:

$$
F_R(G) = \begin{cases} 
0.003 (G - 9) V_G, & G \geq 9 \\
0, & G < 9
\end{cases}
$$

$$
V_G = 9.6 \text{ — volume of glucose distribution (L)}
$$

Glucose absorption rate:

$$
v(t) = \frac{A_G t}{t_{\max,G}^2} \exp\left(-\frac{t}{t_{\max,G}}\right) \frac{1000 d}{M_w G}
$$

where

$$
A_G = 0.8 \text{ is the carbohydrate bioavailability (dimensionless)}
$$

$$
t_{\max,G} = 40 \text{ is the maximum time for glucose appearance in the bloodstream (min)}
$$

$$
M_w G = 180 \text{ is the molecular weight of glucose}
$$

### Initial Conditions

$$
S_1(0) = 0, \quad S_2(0) = 0, \quad I(0) = 6
$$

$$
x_1(0) = 0.0634, \quad x_2(0) = 0.0005, \quad x_3(0) = 0.3138
$$

$$
Q_1(0) = 65.28, \quad Q_2(0) = 10.1271
$$

### Experiments
The following experiments were conducted to track the patient's blood glucose level:

1. The patient did not eat (DG = 0) and did not receive insulin (u(t) ≡ 0).
2. The patient ate 36 XE during the first 18 minutes of the experiment and did not receive insulin.
3. The patient received 6000 units (6 ME) of insulin during the first minute and ate 36 XE during the first 18 minutes.

![image](https://github.com/user-attachments/assets/859b7ea4-cec0-4ceb-86fe-ac89ba2f693e)


### Optimal Insulin Therapy
The goal of the insulin therapy is to select the insulin doses to keep the blood glucose level of the patient at a normal level (typically 6 mmol/L). The optimal control problem is formulated and solved to determine the insulin infusion schedule.

#### Food Intake Schedule
The following food intake schedule was used in the optimization experiments:

- **Time steps 1-2:** 18 XE (36 grams of carbohydrates) ingested
- **Time steps 7-8:** 18 XE (36 grams of carbohydrates) ingested
- **Time steps 15-16:** 18 XE (36 grams of carbohydrates) ingested

This carbohydrate intake schedule is implemented in the code as follows:

```matlab
% Food intake schedule for optimization
d_schedule = zeros(N, 1);
d_schedule(1:2) = 18;  % Food intake at time steps 1-2
d_schedule(7:8) = 18;  % Food intake at time steps 7-8
d_schedule(15:16) = 18; % Food intake at time steps 15-16
```

#### Graphics and results

![image](https://github.com/user-attachments/assets/8f8750c0-26f4-4867-936c-bd5e8e13a71c)
![image](https://github.com/user-attachments/assets/68b9f09e-586a-464c-b68e-8e7adf9a3f8a)
![image](https://github.com/user-attachments/assets/1720df17-c425-48ce-b36f-8d8d570ca860)
![image](https://github.com/user-attachments/assets/f904e144-3100-495d-979d-5a01f9ec6b94)
![image](https://github.com/user-attachments/assets/9a615d89-b67c-4e5d-adc0-d9dc8f520c22)
![image](https://github.com/user-attachments/assets/70416781-f474-4ee8-9907-801ec6315515)
