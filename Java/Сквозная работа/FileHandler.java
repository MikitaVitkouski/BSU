import java.io.IOException;
import java.nio.file.Path;
import java.util.List;

public interface FileHandler {
    List<String> readFile(Path filePath) throws IOException;

    void writeFile(Path filePath, List<String> content) throws IOException;
}