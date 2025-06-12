% Model definition for the Hovorka model.
function dydt = hovorka_model(t, y, u, d)

    % Parameters for the Hovorka model.
    k = 1/55; ke = 0.2; VI = 7.2;
    ka1 = 0.006; ka2 = 0.06; ka3 = 0.03;
    kb1 = 3.072e-5; kb2 = 4.92e-5; kb3 = 0.00156;
    k12 = 0.066; EGP0 = 0.966;
    F01 = 0.582; VG = 9.6;
    AG = 0.8; tmax_G = 40; MwG = 180;

    % Assign variables for the state variables (y) from the input vector.
    S1 = y(1); S2 = y(2); I = y(3);
    x1 = y(4); x2 = y(5); x3 = y(6);
    Q1 = y(7); Q2 = y(8);

    % Calculating glucose concentration in the blood (G) and other variables.
    G = Q1 / VG; % Glucose concentration in blood
    Fc01 = F01 * min(G / 4.5, 1); % First-phase insulin secretion
    FR = max(0, 0.003 * (G - 9) * VG); % Rate of glucose release

    % Glucose appearance from meal (v), modeled as an exponential function.
    v = AG * t / (tmax_G)^2 * exp(-t / tmax_G) * (1000 * d / MwG);

    % Initialize the rate of change vector dydt.
    dydt = zeros(8,1);

    % Differential equations defining the rate of change for each state variable.
    dydt(1) = u - k * S1;          % Subcutaneous insulin (S1)
    dydt(2) = k * S1 - k * S2;     % Subcutaneous insulin (S2)
    dydt(3) = (k / VI) * S2 - ke * I;  % Plasma insulin (I)
    dydt(4) = -ka1 * x1 + kb1 * I;   % x1 dynamics
    dydt(5) = -ka2 * x2 + kb2 * I;   % x2 dynamics
    dydt(6) = -ka3 * x3 + kb3 * I;   % x3 dynamics
    dydt(7) = -x1 * Q1 + k12 * Q2 - (Fc01 + FR) + EGP0 * (1 - x3) + v; % Glucose in blood (Q1)
    dydt(8) = x1 * Q1 - (k12 + x2) * Q2; % Glucose in tissues (Q2)

end

% Experimental setup parameters
VG = 9.6; % Volume of distribution for glucose
y0 = [0; 0; 6; 0.0634; 0.0005; 0.3138; 65.28; 10.1271]; % Initial conditions
T_exp = 300; % Total experimental time (minutes)
dt_exp = 15; % Time step for the experiment (minutes)
N_exp = T_exp / dt_exp; % Number of steps
time_exp = 0:dt_exp:T_exp; % Time vector for the experiment

% Pre-allocate array for storing glucose values for each experiment
G_all = zeros(N_exp+1, 3);

% Simulate three different experiments with different insulin and food input
for exp_num = 1:3
    y = y0; % Reset the initial conditions for each experiment
    G_vals = zeros(N_exp+1, 1); % Store glucose values over time
    G_vals(1) = y(7) / VG; % Initial glucose concentration

    % Schedules for insulin (u_schedule) and food intake (d_schedule)
    u_schedule = zeros(N_exp,1);
    d_schedule = zeros(N_exp,1);

    % Experiment-specific modifications to the schedules
    switch exp_num
        case 2
            d_schedule(1:2) = 18; % Food intake for experiment 2
        case 3
            d_schedule(1:2) = 18; % Food intake for experiment 3
            u_schedule(1) = 6000; % Insulin dose for experiment 3
    end

    % Run the simulation for the specified number of steps
    for k = 1:N_exp
        uk = u_schedule(k); % Current insulin dose
        dk = d_schedule(k); % Current food intake
        tspan = [0 dt_exp]; % Time span for the ODE solver
        [~, ysol] = ode45(@(t, y) hovorka_model(t, y, uk, dk), tspan, y); % Solve the ODE
        y = ysol(end,:)'; % Update the state variables
        G_vals(k+1) = max(0, y(7)/VG); % Store the glucose value
    end
    G_all(:, exp_num) = G_vals; % Store glucose data for this experiment
end

% Plot the results for glucose dynamics across the experiments
figure;
plot(time_exp, G_all(:,1), 'b', 'LineWidth', 2); hold on;
plot(time_exp, G_all(:,2), 'r', 'LineWidth', 2);
plot(time_exp, G_all(:,3), 'g', 'LineWidth', 2);
yline(6, 'k--', 'Target level'); % Target glucose level
xlabel('Time (min)');
ylabel('Glucose (mmol/L)');
legend('Exp. 1: no food and insulin', ...
       'Exp. 2: 36 XE, no insulin', ...
       'Exp. 3: 36 XE + 6ME insulin', ...
       'Target', 'Location', 'best');
title('Glucose dynamics: experiments');
grid on;

% Cost function definition for optimal insulin dosage optimization
function J = cost_function(u_vec, y0, N, dt, d_schedule, lambda)
    J = 0; y = y0; VG = 9.6;
    uk1 = 0;

    % Loop over each time step to calculate the cost function
    for k = 1:N
        uk = u_vec(k); % Insulin dose at step k
        d = d_schedule(k); % Food intake at step k
        tspan = [0 dt]; % Time span for the ODE solver
        [~, ysol] = ode45(@(t, y) hovorka_model(t, y, uk, d), tspan, y); % Solve ODE
        y = ysol(end,:)'; % Update the state variables
        G = y(7) / VG; % Calculate glucose concentration
        J = J + (G - 6)^2 + lambda * (uk - uk1)^2; % Add to the cost function

        uk1 = uk; % Store the previous insulin dose for smoothness penalty
    end
end

% Optimization setup using fmincon to find optimal insulin schedule
clc; clear;
Tol = 1e-8; % Tolerance for optimization
optoff  = optimset('Display','off', 'TolFun', Tol,'TolX', Tol, 'TolCon', Tol);

VG = 9.6; % Volume of distribution for glucose
y0 = [0; 0; 6; 0.0634; 0.0005; 0.3138; 65.28; 10.1271]; % Initial conditions
T = 300; N = 20; dt = T / N; % Total time, number of steps, and time step

u0 = ones(N,1); % Initial guess for the insulin doses
lb = zeros(N,1); % Lower bound for insulin doses (cannot be negative)
ub = 1000*ones(N,1); % Upper bound for insulin doses
lambda = 1e-6; % Weight for the smoothness penalty

% Food intake schedule for optimization
d_schedule = zeros(N, 1);
d_schedule(1:2) = 18; % Food intake at time steps 1-2
d_schedule(7:8) = 18; % Food intake at time steps 7-8
d_schedule(15:16) = 18; % Food intake at time steps 15-16

% Optimize the insulin schedule using fmincon
[u_opt, J] = fmincon(@(u) cost_function(u, y0, N, dt, d_schedule, lambda), ...
                    u0, [], [], [], [], lb, ub, [], optoff);

disp(u_opt); % Display the optimized insulin doses
disp(J); % Display the final cost function value

% Simulation to get glucose dynamics using optimized insulin doses
y = y0;
time = 0:dt:T;

% Pre-allocate arrays to store values over time
G_vals = zeros(N+1,1);
Q1_vals = zeros(N+1,1);
Q2_vals = zeros(N+1,1);
I_vals  = zeros(N+1,1);
S1_vals = zeros(N+1,1);
S2_vals = zeros(N+1,1);
x1_vals = zeros(N+1,1);
x2_vals = zeros(N+1,1);
x3_vals = zeros(N+1,1);
insulin_doses = zeros(N, 1);

G_vals(1)  = y(7)/VG;
Q1_vals(1) = y(7);
Q2_vals(1) = y(8);
I_vals(1)  = y(3);
S1_vals(1) = y(1);
S2_vals(1) = y(2);
x1_vals(1) = y(4);
x2_vals(1) = y(5);
x3_vals(1) = y(6);

% Simulate glucose dynamics with optimal insulin doses
for k = 1:N
    uk = u_opt(k); % Insulin dose at step k
    insulin_doses(k) = uk;
    tspan = [0 dt]; % Time span for the ODE solver
    d = d_schedule(k); % Food intake at step k
    [~, ysol] = ode45(@(t, y) hovorka_model(t, y, uk, d), tspan, y); % Solve ODE
    y = ysol(end,:)'; % Update the state variables
    G_vals(k+1) = y(7)/VG; % Store glucose value
    Q1_vals(k+1) = y(7);
    Q2_vals(k+1) = y(8);
    I_vals(k+1)  = y(3);
    S1_vals(k+1) = y(1);
    S2_vals(k+1) = y(2);
    x1_vals(k+1) = y(4);
    x2_vals(k+1) = y(5);
    x3_vals(k+1) = y(6);
end

% Plot glucose dynamics with optimal insulin schedule
figure;
plot(time, G_vals, 'b-', 'LineWidth', 2);
hold on;
yline(6, '--k', 'Target glucose level');
xlabel('Time (min)'); ylabel('Glucose (mmol/L)');
title('Optimal control: glucose level'); grid on; legend('Glucose','Target');

% Plot insulin doses
figure;
plot(time(1:N), insulin_doses, 'b-','LineWidth',2);
xlabel('Time (min)'); ylabel('Insulin dose (mME)'); 
title('Optimal insulin doses'); grid on;

% Plot plasma insulin over time
figure;
plot(time, I_vals, 'm', 'LineWidth', 2);
xlabel('Time (min)'); ylabel('Insulin (mME/L)');
title('Plasma insulin (I)'); grid on;

% Plot glucose dynamics in blood and tissues
figure;
plot(time, Q1_vals, 'b', 'LineWidth', 2); hold on;
plot(time, Q2_vals, 'g', 'LineWidth', 2);
xlabel('Time (min)'); ylabel('Mass (mmol)');
legend('Q1 (blood)', 'Q2 (tissues)');
title('Glucose dynamics (Q1 and Q2)'); grid on;

% Plot subcutaneous insulin
figure;
plot(time, S1_vals, 'c', 'LineWidth', 2); hold on;
plot(time, S2_vals, 'k', 'LineWidth', 2);
xlabel('Time (min)'); ylabel('Insulin amount (mME)');
legend('S1', 'S2');
title('Subcutaneous insulin (S1 and S2)'); grid on;

% Plot insulin effects
figure;
plot(time, x1_vals, 'r', 'LineWidth', 2); hold on;
plot(time, x2_vals, 'g', 'LineWidth', 2);
plot(time, x3_vals, 'b', 'LineWidth', 2);
xlabel('Time (min)'); ylabel('(1/min)');
legend('x1', 'x2', 'x3');
title('Insulin effects (x1, x2, x3)'); grid on;