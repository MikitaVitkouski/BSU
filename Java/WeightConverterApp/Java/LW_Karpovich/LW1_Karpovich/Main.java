package org.example;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Scanner;
import java.text.NumberFormat;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Enter x:");
        double x = scanner.nextDouble();

        System.out.println("Enter k:");
        int k = scanner.nextInt();

        scanner.close();

        double resultStandard = calculateTaylorSeriesStandard(x, k);
        BigDecimal resultBigDecimal = calculateTaylorSeriesBigDecimal(x, k);

        System.out.println("Result by Standard functions: " + resultStandard);
        System.out.println("Result with the help of BigDecimal: " + resultBigDecimal);
    }

    private static String getInput() throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        return br.readLine();
    }

    private static double calculateTaylorSeriesStandard(double x, int k) {
        double epsilon = Math.pow(10, -k);
        double result = 1.0;
        double term = 1.0;

        for (int i = 1; Math.abs(term) > epsilon; i++) {
            term *= x / i;
            result += term;
        }

        return result;
    }

    private static BigDecimal calculatePower(BigDecimal base, int exponent) {
        BigDecimal result = BigDecimal.ONE;

        for (int i = 0; i < Math.abs(exponent); i++) {
            result = result.multiply(base);
        }

        return exponent >= 0 ? result : BigDecimal.ONE.divide(result, 25, BigDecimal.ROUND_HALF_UP);
    }

    private static BigDecimal calculateTaylorSeriesBigDecimal(double x, int k) {
        BigDecimal epsilon = BigDecimal.ONE.divide(calculatePower(BigDecimal.TEN, k), 25, BigDecimal.ROUND_HALF_UP);
        BigDecimal result = BigDecimal.ONE;
        BigDecimal term = BigDecimal.ONE;
        BigDecimal xBigDecimal = BigDecimal.valueOf(x);

        for (int i = 1; term.abs().compareTo(epsilon) > 0; i++) {
            term = term.multiply(xBigDecimal).divide(BigDecimal.valueOf(i), 25, BigDecimal.ROUND_HALF_UP);
            result = result.add(term);
        }

        return result.setScale(25, BigDecimal.ROUND_HALF_UP);
    }
}