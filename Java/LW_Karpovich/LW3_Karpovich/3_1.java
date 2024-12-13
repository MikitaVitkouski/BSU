package org.example;

public class Main {
    public static void main(String[] args) {
        String inputString = "abcdefg, jklmnopqrst, xddd";
        String[] words = inputString.split("[\\s.,:;!?]+");

        String longestWords = findLongestWords(words);
        System.out.println(longestWords);
    }

    public static boolean isIncreasingOrder(String word) {
        for (int i = 0; i < word.length() - 1; i++) {
            if (word.charAt(i) >= word.charAt(i + 1)) {
                return false;
            }
        }
        return true;
    }

    public static String findLongestWords(String[] words) {
        String longestWords = "";
        int maxLength = 0;

        for (String word : words) {
            if (word.length() > maxLength && isIncreasingOrder(word)) {
                longestWords = word;
                maxLength = word.length();
            } else if (word.length() == maxLength && isIncreasingOrder(word)) {
                longestWords += " " + word;
            }
        }

        return longestWords;
    }
}