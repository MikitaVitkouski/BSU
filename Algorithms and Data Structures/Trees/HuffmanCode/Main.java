import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class HuffmanCode {

    public static void main(String[] args) {
        try {
            BufferedReader fin = new BufferedReader(new FileReader("huffman.in"));
            int n = Integer.parseInt(fin.readLine());

            String[] numbers = fin.readLine().split(" ");
            List<Long> firstList = new ArrayList<>();
            for (String number : numbers) {
                firstList.add(Long.parseLong(number));
            }

            firstList.add(Long.MAX_VALUE);
            fin.close();

            ArrayList<Long> secondList = new ArrayList<>();
            for (int i = 0; i < n; ++i) {
                secondList.add(0L);
            }

            long indexF = 0, indexS = 0, indexApp = 0;
            for (; indexApp != n - 1; indexApp++) {
                long sum = 0;
                for (long i = 0; i < 2; ++i) {
                    if (indexS >= secondList.size() || (secondList.get((int) indexS) == 0) || (firstList.get((int) indexF) < secondList.get((int) indexS))) {
                        sum += firstList.get((int) indexF);
                        indexF += 1;
                    } else {
                        sum += secondList.get((int) indexS);
                        indexS += 1;
                    }
                }
                secondList.set((int) indexApp, sum);
            }


            BufferedWriter fout = new BufferedWriter(new FileWriter("huffman.out"));
            long sum = 0;
            for (long value : secondList) {
                sum += value;
            }
            fout.write(Long.toString(sum));
            fout.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}