package org.example;

import java.util.function.Function;

public class ArrayFiller {
    public static<T> void fill(T[] array, Function<Integer,T> function) {
        for(int i =0;i<array.length;i++){
            array[i] = function.apply(i);
        }
    }
}