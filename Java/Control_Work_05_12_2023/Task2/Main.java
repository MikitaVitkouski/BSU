package org.example;

public class Main {
    public static void main(String[] args) {
        Integer[] squares = new Integer[10];
        ArrayFiller.fill(squares,integer->integer*integer);

        System.out.println("Squares array: ");
        printArray(squares);

        Double[] doubles = new Double[5];
        ArrayFiller.fill(doubles,integer->integer*2.0);

        System.out.println("Doubles array: ");
        printArray(doubles);
    }

    private static<T> void printArray(T[] array) {
        for(T value : array) {
            System.out.print(value + " ");
        }
        System.out.println();
    }
}