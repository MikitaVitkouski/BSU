import javax.json.bind.Jsonb;
import javax.json.bind.JsonbBuilder;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Map;
public class JsonFileHandler {
    /**
     * Reads a JSON file and returns a Map representing the JSON content.
     *
     * @param filePath The path to the JSON file.
     * @return A Map representing the JSON content.
     * @throws IOException If an error occurs while reading the file.
     */
    public static Map<String,Object> readJsonFromFile(Path filePath) throws IOException {
        try {
            Jsonb jsonb = JsonbBuilder.create();
            byte[] jsonData = Files.readAllBytes(filePath);
            return jsonb.fromJson(new String(jsonData), Map.class);
        }catch (IOException e) {
            throw new IOException("Failed to read JSON file", e);
        }
    }

    /**
     * Writes a Map to a JSON file.
     *
     * @param filePath The path to the JSON file.
     * @param jsonMap  The Map to write to the file.
     * @throws IOException If an error occurs while writing to the file.
     */
    public static void writeJsonFile(Path filePath, Map<String,Object> jsonMap) throws IOException {
        try {
            Jsonb jsonb = JsonbBuilder.create();
            String jsonString = jsonb.toJson(jsonMap);
            Files.write(filePath,jsonString.getBytes());
        } catch(IOException e) {
            throw new IOException("Failed to write JSON file", e);
        }
    }

}