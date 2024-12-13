import org.testng.annotations.Test;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.HashMap;
import java.util.Map;

import static org.testng.Assert.assertEquals;
import static org.testng.Assert.assertTrue;

public class JsonFileHandlerTest {

    @Test
    void testReadJsonFile() throws IOException {
        Path testFilePath = Path.of("test.json");
        createSampleJsonFile(testFilePath);

        JsonHandler jsonFileHandler = new JsonFileHandler();
        Map<String, Object> jsonMap = jsonFileHandler.readJsonFile(testFilePath);

        assertEquals(jsonMap.get("key1"), "value1");
        assertEquals(jsonMap.get("key2"), 42);
    }

    @Test
    void testWriteJsonFile() throws IOException {
        Path testFilePath = Path.of("test_write.json");

        JsonHandler jsonFileHandler = new JsonFileHandler();
        Map<String, Object> jsonMap = createSampleJsonMap();

        jsonFileHandler.writeJsonFile(testFilePath, jsonMap);

        JsonHandler jsonFileHandlerForRead = new JsonFileHandler();
        Map<String, Object> readJsonMap = jsonFileHandlerForRead.readJsonFile(testFilePath);

        assertEquals(readJsonMap, jsonMap);
    }

    @Test
    void testToJsonString() {
        JsonHandler jsonFileHandler = new JsonFileHandler();
        Map<String, Object> jsonMap = createSampleJsonMap();

        String jsonString = jsonFileHandler.toJsonString(jsonMap);

        assertEquals(jsonString, "{\"key1\":\"value1\",\"key2\":42}");
    }

    private void createSampleJsonFile(Path filePath) throws IOException {
        Map<String, Object> jsonMap = new HashMap<>();
        jsonMap.put("key1", "value1");
        jsonMap.put("key2", 42);

        String jsonString = new JsonFileHandler().toJsonString(jsonMap);
        Files.write(filePath, jsonString.getBytes());
    }

    private Map<String, Object> createSampleJsonMap() {
        Map<String, Object> jsonMap = new HashMap<>();
        jsonMap.put("key1", "value1");
        jsonMap.put("key2", 42);
        return jsonMap;
    }
}