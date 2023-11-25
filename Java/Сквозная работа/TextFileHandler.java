import java.io.BufferedWriter;
import java.io.BufferedReader;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardOpenOption;
import java.util.List;

public class TextFileHandler {

    /**
     * Reads the content of a text file.
     *
     * @param filePath The path to the text file.
     * @return A list of strings representing the lines of the text file.
     * @throws IOException If an error occurs while reading the file.
     */
    public static List<String> readTextFile(Path filePath) throws IOException {
        try {
            return Files.readAllLines(filePath, StandardCharsets.UTF_8);
        } catch (IOException e) {
            throw new IOException("Failed to read text file", e);
        }
    }

    /**
     * Writes content to a text file.
     *
     * @param filePath The path to the text file.
     * @param content  The content to write to the file.
     * @throws IOException If an error occurs while writing to the file.
     */
    public static void writeTextFile(Path filePath, List<String> content) throws IOException {
        try {
            Files.write(filePath, content, StandardCharsets.UTF_8, StandardOpenOption.CREATE, StandardOpenOption.WRITE);
        } catch (IOException e) {
            throw new IOException("Failed to write text file", e);
        }
    }
}