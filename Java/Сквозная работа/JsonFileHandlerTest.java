import org.testng.annotations.Test;

import javax.json.bind.Jsonb;
import javax.json.bind.JsonbBuilder;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.HashMap;
import java.util.Map;

import static org.testng.AssertJUnit.assertEquals;
import static org.testng.AssertJUnit.assertNotNull;

public class JsonFileHandlerTest {

    @Test
    void testReadJsonFile() throws IOException {
        Path testFilePath = Path.of("test.json");
        createSampleJsonFile(testFilePath);

        Map<String, Object> jsonMap = JsonFileHandler.readJsonFromFile(testFilePath);

        assertNotNull(jsonMap);
        assertEquals("value1", jsonMap.get("key1"));
        assertEquals(42, jsonMap.get("key2"));
    }

    @Test
    void testWriteJsonFile() throws IOException {
        Path testFilePath = Path.of("test_write.json");

        Map<String, Object> jsonMap = createSampleJsonMap();

        JsonFileHandler.writeJsonFile(testFilePath, jsonMap);

        Map<String, Object> readJsonMap = JsonFileHandler.readJsonFromFile(testFilePath);
        assertNotNull(readJsonMap);
        assertEquals(jsonMap, readJsonMap);
    }

    private void createSampleJsonFile(Path filePath) throws IOException {
        String jsonContent = "{\"key1\":\"value1\",\"key2\":42}";

        Files.write(filePath, jsonContent.getBytes());
    }

    private Map<String, Object> createSampleJsonMap() {
        Map<String, Object> jsonMap = new HashMap<>();
        jsonMap.put("key1", "value1");
        jsonMap.put("key2", 42);

        return jsonMap;
    }

    @Test
    void testWriteAndReadJsonFileWithJsonb() throws IOException {
        Path testFilePath = Path.of("test_jsonb.json");

        Map<String, Object> jsonMap = createSampleJsonMap();

        // Use Jsonb for writing
        Jsonb jsonb = JsonbBuilder.create();
        String jsonContent = jsonb.toJson(jsonMap);
        Files.write(testFilePath, jsonContent.getBytes());

        // Use Jsonb for reading
        String jsonString = Files.readString(testFilePath);
        Map<String, Object> readJsonMap = jsonb.fromJson(jsonString, Map.class);

        assertNotNull(readJsonMap);
        assertEquals(jsonMap, readJsonMap);
    }
}