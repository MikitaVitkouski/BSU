package org.example;

import java.util.LinkedList;
import java.util.Queue;
import java.util.concurrent.locks.Condition;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;
import java.lang.InterruptedException;

public class Buffer {
    private Queue<Object> dataQueue = new LinkedList<>();
    private int maxSize = 10;
    private Lock lock = new ReentrantLock();
    private Condition notFull = lock.newCondition();
    private Condition notEmpty = lock.newCondition();

    public void produce(Object data) throws InterruptedException {
        lock.lock();
        try{
            while(dataQueue.size() == maxSize) {
                notFull.await();
            }
            dataQueue.add(data);
            System.out.println("Produced" + data);
            notEmpty.signal();
        } finally {
            lock.unlock();
        }
    }

    public Object consume() throws InterruptedException {
        lock.lock();
        try {
            while(dataQueue.isEmpty()) {
                notEmpty.await();
            }
            Object data = dataQueue.poll();
            System.out.println("Consumed" + data);
            notFull.signal();
            return data;
        } finally {
            lock.unlock();
        }
    }
}

class Producer implements Runnable {
    private Buffer buffer;

    public Producer(Buffer buffer) {
        this.buffer = buffer;
    }

    @Override
    public void run() {
        try{
            while(true){
                Object data = generateData();
                buffer.produce(data);
                Thread.sleep(1000);
            }
        }catch(InterruptedException e) {
            e.printStackTrace();
        }
    }

    private Object generateData() {
        return "Data";
    }
}

class Consumer implements Runnable {
    private Buffer buffer;

    public Consumer(Buffer buffer) {
        this.buffer = buffer;
    }

    @Override
    public void run() {
        try{
            while(true){
                Object data = buffer.consume();
                processData(data);
                Thread.sleep(1500);
            }
        }catch(InterruptedException e) {
            e.printStackTrace();
        }
    }

    private void processData(Object data) {
        System.out.println("Processed" + data);
    }
}