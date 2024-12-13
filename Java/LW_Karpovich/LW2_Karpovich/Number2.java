package org.example;

import java.util.Scanner;
import java.util.Arrays;
import java.util.Random;
import java.util.Vector;
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the number of rows and columns (n): ");
        int n = scanner.nextInt();

        int[][] matrix = new int[n][n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                matrix[i][j] = (int) (Math.random() * 101);
            }
        }

        System.out.println("Original matrix:");
        for (int[] row : matrix) {
            System.out.println(Arrays.toString(row));
        }

        int maxSum = Integer.MIN_VALUE;

        for (int i = 0; i < n; i++) {
            int sum = 0;
            for (int j = 0; j < n - i; j++) {
                sum += matrix[j][i + j];
            }
            maxSum = Math.max(maxSum, sum);
        }

        for (int i = 1; i < n; i++) {
            int sum = 0;
            for (int j = 0; j < n - i; j++) {
                sum += matrix[i + j][j];
            }
            maxSum = Math.max(maxSum, sum);
        }

        System.out.println("Maximum sum of elements in diagonals parallel to the main diagonal: " + maxSum);
    }
}