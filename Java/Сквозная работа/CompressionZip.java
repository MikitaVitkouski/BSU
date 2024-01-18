import java.io.IOException;
import java.nio.file.*;
import java.util.Scanner;

public class CompressionZip {

    public static void decompressAndProcess(String zipFilePath, String extractTo, Scanner scanner) throws IOException {
        ZipHandler zipHandler = new ZipHandler();
        zipHandler.extractAll(zipFilePath, extractTo);

        System.out.println("Enter the source directory path: ");
        String sourceDirectory = scanner.nextLine();

        System.out.println("Enter the type of file to process (txt/json/xml): ");
        String fileType = scanner.nextLine().toLowerCase();

        processFilesInDirectory(Paths.get(sourceDirectory), fileType, scanner);
    }

    public static void processFilesInDirectory(Path directoryPath, String fileType, Scanner scanner) throws IOException {
        try (DirectoryStream<Path> directoryStream = Files.newDirectoryStream(directoryPath)) {
            System.out.println("Files of type " + fileType + " in the directory:");
            int fileNumber = 1;

            for (Path filePath : directoryStream) {
                if (Files.isRegularFile(filePath) && filePath.getFileName().toString().endsWith("." + fileType)) {
                    System.out.println(fileNumber + ". " + filePath.getFileName());
                    fileNumber++;
                }
            }

            System.out.print("Enter the file number to process: ");
            int selectedFileNumber = scanner.nextInt();
            scanner.nextLine(); // Consume the newline character

            Path selectedFilePath = getFilePathByNumber(directoryPath, fileType, selectedFileNumber);
            processFile(selectedFilePath, fileType, scanner);
        }
    }

    private static Path getFilePathByNumber(Path directoryPath, String fileType, int selectedFileNumber) throws IOException {
        try (DirectoryStream<Path> directoryStream = Files.newDirectoryStream(directoryPath)) {
            int fileNumber = 1;

            for (Path filePath : directoryStream) {
                if (Files.isRegularFile(filePath) && filePath.getFileName().toString().endsWith("." + fileType)) {
                    if (fileNumber == selectedFileNumber) {
                        return filePath;
                    }
                    fileNumber++;
                }
            }
        }

        throw new IOException("Invalid file number selected.");
    }

    private static void processFile(Path inputFilePath, String fileType, Scanner scanner) {
        switch (fileType) {
            case "txt":
                processTextFile(inputFilePath, scanner);
                break;
            case "xml":
                processXmlFile(inputFilePath, scanner);
                break;
            case "json":
                processJsonFile(inputFilePath, scanner);
                break;
            default:
                System.out.println("Invalid file type.");
        }
    }

    private static void processTextFile(Path inputFilePath, Scanner scanner) {
        FileHandler textFileHandler = new TextFileHandler();
        MathOperationTextParser textParser = new MathOperationTextParser(textFileHandler);

        System.out.print("Enter the output file path for text file processing: ");
        String outputFilePath = scanner.nextLine();

        textParser.processFile(inputFilePath, Paths.get(outputFilePath));
        System.out.println("Text file processed successfully.");
    }

    private static void processXmlFile(Path inputFilePath, Scanner scanner) {
        XmlHandler xmlFileHandler = new XmlFileHandler();
        MathOperationXmlParser xmlParser = new MathOperationXmlParser(xmlFileHandler);

        System.out.print("Enter the output file path for XML file processing: ");
        String outputFilePath = scanner.nextLine();

        xmlParser.processFile(inputFilePath, Paths.get(outputFilePath));
        System.out.println("XML file processed successfully.");
    }

    private static void processJsonFile(Path inputFilePath, Scanner scanner) {
        JsonHandler jsonFileHandler = new JsonFileHandler();
        MathOperationJsonParser jsonParser = new MathOperationJsonParser(jsonFileHandler);

        System.out.print("Enter the output file path for JSON file processing: ");
        String outputFilePath = scanner.nextLine();

        jsonParser.processFile(inputFilePath, Paths.get(outputFilePath));
        System.out.println("JSON file processed successfully.");
    }
}