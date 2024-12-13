package org.example;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

public class BufferTest {

    @Test
    void testProduceAndConsume() throws InterruptedException{
        Buffer buffer = new Buffer();

        Thread producerThread = new Thread(() -> {
            try{
                buffer.produce("Data1");
                buffer.produce("Data2");
            } catch(InterruptedException e){
                e.printStackTrace();
            }
        });

        Thread consumerThread = new Thread(()->{
           try{
               Object data1 = buffer.consume();
               Object data2 = buffer.consume();
               assertEquals("Data1",data1);
               assertEquals("Data2",data2);
           } catch (InterruptedException e) {
               e.printStackTrace();
           }
        });

        producerThread.start();
        consumerThread.start();

        producerThread.join();
        consumerThread.join();
    }

    @Test
    void testBufferLimit() throws InterruptedException {
        Buffer buffer = new Buffer();
        int maxSize = 3;

        Thread producerThread = new Thread(() -> {
            try {
                buffer.produce("Data1");
                buffer.produce("Data2");
                buffer.produce("Data3");
                buffer.produce("Data4");
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        });

        Thread consumerThread = new Thread(() -> {
            try {
                Thread.sleep(1000);
                Object data1 = buffer.consume();
                Object data2 = buffer.consume();
                Object data3 = buffer.consume();
                assertEquals("Data1", data1);
                assertEquals("Data2", data2);
                assertEquals("Data3", data3);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        });

        producerThread.start();
        consumerThread.start();

        producerThread.join();
        consumerThread.join();
    }
}
