import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.IOException;
import java.nio.file.Path;
import java.util.Map;

public class JsonFileHandler implements JsonHandler {

    private final ObjectMapper objectMapper = new ObjectMapper();

    @Override
    public Map<String, Object> readJsonFile(Path filePath) throws IOException {
        try {
            return objectMapper.readValue(filePath.toFile(), Map.class);
        } catch (IOException e) {
            throw new IOException("Failed to read JSON file", e);
        }
    }

    @Override
    public void writeJsonFile(Path filePath, Map<String, Object> jsonMap) throws IOException {
        try {
            objectMapper.writeValue(filePath.toFile(), jsonMap);
        } catch (IOException e) {
            throw new IOException("Failed to write JSON file", e);
        }
    }

    @Override
    public String toJsonString(Map<String, Object> jsonMap) {
        try {
            return objectMapper.writeValueAsString(jsonMap);
        } catch (IOException e) {
            throw new RuntimeException("Failed to convert JSON to string", e);
        }
    }
}