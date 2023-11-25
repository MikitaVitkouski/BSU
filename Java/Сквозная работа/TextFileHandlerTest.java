import org.testng.annotations.Test;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.List;

import static org.testng.AssertJUnit.assertEquals;
import static org.testng.AssertJUnit.assertTrue;
import static org.testng.AssertJUnit.assertNotNull;

public class TextFileHandlerTest {

    @Test
    void testReadTextFile() throws IOException {
        Path testFilePath = Path.of("test.txt");
        Files.write(testFilePath, List.of("Line 1", "Line 2", "Line 3"));

        List<String> lines = TextFileHandler.readTextFile(testFilePath);
        assertEquals(List.of("Line 1", "Line 2", "Line 3"), lines);
    }

    @Test
    void testWriteTextFile() throws IOException {
        Path testFilePath = Path.of("test.txt");
        List<String> content = List.of("Line 1", "Line 2", "Line 3");

        TextFileHandler.writeTextFile(testFilePath, content);

        List<String> lines = Files.readAllLines(testFilePath);
        assertEquals(content, lines);
    }

    @Test
    void testReadEmptyFile() throws IOException {
        Path testFilePath = Path.of("empty.txt");

        Files.deleteIfExists(testFilePath);

        Files.createFile(testFilePath);

        List<String> lines = TextFileHandler.readTextFile(testFilePath);
        assertTrue(lines.isEmpty());
    }

    @Test
    void testWriteToNonexistentFile() throws IOException {
        Path testFilePath = Path.of("nonexistent.txt");
        Files.deleteIfExists(testFilePath); //Ensuring file doesn't exist :)

        List<String> content = List.of("Line 1", "Line 2");

        TextFileHandler.writeTextFile(testFilePath,content);

        List<String> lines = Files.readAllLines(testFilePath);
        assertEquals(content, lines);
    }

    @Test
    void testFileWithSpecialCharacters() throws IOException {
        Path testFilePath = Path.of("special_chars.txt");
        List<String> content = List.of("Line with $pecial characters! @#");

        TextFileHandler.writeTextFile(testFilePath,content);

        List<String> lines = TextFileHandler.readTextFile(testFilePath);
        assertEquals(content, lines);
    }
}