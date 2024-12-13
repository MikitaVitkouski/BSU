package org.example;

import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the number of rows (m): ");
        int m = scanner.nextInt();
        System.out.print("Enter the number of columns (n): ");
        int n = scanner.nextInt();

        int[][] matrix = new int[m][n];
        Random random = new Random();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                matrix[i][j] = random.nextInt(101);
            }
        }

        System.out.println("Original matrix:");
        for (int[] row : matrix) {
            System.out.println(Arrays.toString(row));
        }

        int maxRowIndex = 0, minRowIndex = 0;
        int max = matrix[0][0], min = matrix[0][0];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] > max) {
                    max = matrix[i][j];
                    maxRowIndex = i;
                }
                if (matrix[i][j] < min) {
                    min = matrix[i][j];
                    minRowIndex = i;
                }
            }
        }

        int[] temp = matrix[maxRowIndex];
        matrix[maxRowIndex] = matrix[minRowIndex];
        matrix[minRowIndex] = temp;

        System.out.println("Matrix after swapping rows:");
        for (int[] row : matrix) {
            System.out.println(Arrays.toString(row));
        }

        for (int i = 0; i < m; i++) {
            if (matrix[i][i] == 0) {
                System.out.println("Row with zero: " + (i + 1));
                int maxInRow = Arrays.stream(matrix[i]).max().getAsInt();
                System.out.println("Maximum element: " + maxInRow);
            }
        }
    }
}