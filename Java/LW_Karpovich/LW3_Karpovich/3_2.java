package org.example;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

public class Main {
    public static void main(String[] args) {
        try {
            BufferedReader reader = new BufferedReader(new FileReader("input.txt"));
            String line;

            Map<String, Integer> wordCount = new HashMap<>();

            while ((line = reader.readLine()) != null) {
                String[] words = line.split("\\s+");
                for (String word : words) {
                    word = word.trim().toLowerCase();
                    wordCount.put(word, wordCount.getOrDefault(word, 0) + 1);
                }
            }


            reader.close();

            int maxCount = 0;
            String mostFrequentWord = null;

            for (Map.Entry<String, Integer> entry : wordCount.entrySet()) {
                if (entry.getValue() > maxCount) {
                    maxCount = entry.getValue();
                    mostFrequentWord = entry.getKey();
                }
            }

            System.out.println("Most frequently occurring word: " + mostFrequentWord);
            System.out.println("Number of occurrences: " + maxCount);


        } catch (IOException e) {
            System.err.println("Error when reading a text file: " + e.getMessage());
        }
    }
}