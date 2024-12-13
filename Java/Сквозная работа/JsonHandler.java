import java.io.IOException;
import java.nio.file.Path;
import java.util.Map;

public interface JsonHandler {
    Map<String, Object> readJsonFile(Path filePath) throws IOException;

    void writeJsonFile(Path filePath, Map<String, Object> jsonMap) throws IOException;

    String toJsonString(Map<String, Object> jsonMap);
}