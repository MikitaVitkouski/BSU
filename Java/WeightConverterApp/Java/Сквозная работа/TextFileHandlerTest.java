import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.List;

import static org.testng.AssertJUnit.assertEquals;
import static org.testng.AssertJUnit.assertTrue;

public class TextFileHandlerTest {

    private Path testDirectory;

    @BeforeMethod
    public void setUp() throws IOException {
        testDirectory = Files.createTempDirectory("test");
    }

    @AfterMethod
    public void tearDown() throws IOException {
        Files.walk(testDirectory)
                .sorted((a, b) -> b.compareTo(a))
                .forEach(path -> {
                    try {
                        Files.delete(path);
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                });
    }

    @Test
    void testReadTextFile() throws IOException {
        Path testFilePath = createTestFile("test.txt", List.of("Line 1", "Line 2", "Line 3"));

        FileHandler fileHandler = new TextFileHandler();
        List<String> lines = fileHandler.readFile(testFilePath);
        assertEquals(List.of("Line 1", "Line 2", "Line 3"), lines);
    }

    @Test
    void testWriteTextFile() throws IOException {
        Path testFilePath = testDirectory.resolve("test.txt");
        List<String> content = List.of("Line 1", "Line 2", "Line 3");

        FileHandler fileHandler = new TextFileHandler();
        fileHandler.writeFile(testFilePath, content);

        List<String> lines = Files.readAllLines(testFilePath);
        assertEquals(content, lines);
    }

    @Test
    void testReadEmptyFile() throws IOException {
        Path testFilePath = createTestFile("empty.txt", List.of());

        FileHandler fileHandler = new TextFileHandler();
        List<String> lines = fileHandler.readFile(testFilePath);
        assertTrue(lines.isEmpty());
    }

    @Test
    void testWriteToNonexistentFile() throws IOException {
        Path testFilePath = testDirectory.resolve("nonexistent.txt");
        Files.deleteIfExists(testFilePath); //Ensuring file doesn't exist :)

        List<String> content = List.of("Line 1", "Line 2");

        FileHandler fileHandler = new TextFileHandler();
        fileHandler.writeFile(testFilePath, content);

        List<String> lines = Files.readAllLines(testFilePath);
        assertEquals(content, lines);
    }

    @Test
    void testFileWithSpecialCharacters() throws IOException {
        Path testFilePath = testDirectory.resolve("special_chars.txt");
        List<String> content = List.of("Line with $pecial characters! @#");

        FileHandler fileHandler = new TextFileHandler();
        fileHandler.writeFile(testFilePath, content);

        List<String> lines = fileHandler.readFile(testFilePath);
        assertEquals(content, lines);
    }

    private Path createTestFile(String fileName, List<String> lines) throws IOException {
        Path testFilePath = testDirectory.resolve(fileName);
        Files.write(testFilePath, lines);
        return testFilePath;
    }
}