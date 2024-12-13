package org.example;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.assertArrayEquals;

public class ArrayFillerTest {

    @Test
    void testFillSquares() {
        Integer[] expected = {0,1,4,9,16,25,36,49,64,81};
        Integer[] actual = new Integer[10];

        ArrayFiller.fill(actual,integer->integer*integer);
        assertArrayEquals(expected,actual);
    }

    @Test
    void testFillDoubles() {
        Double[] expected = {0.0,2.0,4.0,6.0,8.0,10.0,12.0};
        Double[] actual = new Double[7];
        ArrayFiller.fill(actual,integer ->integer*2.0);
        assertArrayEquals(expected,actual);
    }
}
