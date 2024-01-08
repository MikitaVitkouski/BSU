import net.lingala.zip4j.ZipFile;
import net.lingala.zip4j.exception.ZipException;

import java.io.IOException;
import java.nio.file.*;
import java.util.HashMap;
import java.util.Map;

public class CompressionZip {

    public static void decompressAndProcess(String zipFilePath, String extractTo) throws IOException, ZipException {
        ZipHandler zipHandler = new ZipHandler();

        zipHandler.extractAll(zipFilePath, extractTo);

        processFilesInDirectory(Paths.get(extractTo));
    }

    private static void processFilesInDirectory(Path directoryPath) throws IOException {
        try (DirectoryStream<Path> directoryStream = Files.newDirectoryStream(directoryPath)) {
            for (Path filePath : directoryStream) {
                if (Files.isRegularFile(filePath)) {
                    String fileName = filePath.getFileName().toString();

                    if (fileName.endsWith(".txt")) {
                        processTextFile(filePath);
                    } else if (fileName.endsWith(".xml")) {
                        processXmlFile(filePath);
                    } else if (fileName.endsWith(".json")) {
                        processJsonFile(filePath);
                    }
                }
            }
        }
    }

    private static void processTextFile(Path filePath) {
        FileHandler textFileHandler = new TextFileHandler();
        MathOperationTextParser textParser = new MathOperationTextParser(textFileHandler);
        Path outputFilePath = Paths.get("output_extracted.txt");
        textParser.processFile(filePath, outputFilePath);
    }

    private static void processXmlFile(Path filePath) {
        XmlHandler xmlFileHandler = new XmlFileHandler();
        MathOperationXmlParser xmlParser = new MathOperationXmlParser(xmlFileHandler);
        Path outputFilePath = Paths.get("output_extracted.xml");
        xmlParser.processFile(filePath, outputFilePath);
    }

    private static void processJsonFile(Path filePath) {
        JsonHandler jsonFileHandler = new JsonFileHandler();
        MathOperationJsonParser jsonParser = new MathOperationJsonParser(jsonFileHandler);
        Path outputFilePath = Paths.get("output_extracted.json");
        jsonParser.processFile(filePath, outputFilePath);
    }
}