import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardOpenOption;
import java.util.List;

public class TextFileHandler implements FileHandler {
    @Override
    public List<String> readFile(Path filePath) throws IOException {
        try {
            return Files.readAllLines(filePath, StandardCharsets.UTF_8);
        } catch (IOException e) {
            throw new IOException("Failed to read text file", e);
        }
    }

    @Override
    public void writeFile(Path filePath, List<String> content) throws IOException {
        try {
            Files.write(filePath, content, StandardCharsets.UTF_8, StandardOpenOption.CREATE, StandardOpenOption.WRITE);
        } catch (IOException e) {
            throw new IOException("Failed to write text file", e);
        }
    }
}