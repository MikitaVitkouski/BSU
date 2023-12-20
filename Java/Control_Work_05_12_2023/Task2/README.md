Write a fill method that accepts an array of objects and an implementation of the Function interface (or its own).
The fill method should fill the array by getting a new value at the index using the implementation of the Function interface. That is, I want to use it like this:

public static void main(String[] args) {
Integer[] squares = new Integer[100];
fill(squares, integer -> integer * integer); // 0, 1, 4, 9, 16
}
