import java.nio.file.Path;

public class MainApp {

    public static void main(String[] args) {
        // Text file
        FileHandler textFileHandler = new TextFileHandler();
        MathOperationTextParser textParser = new MathOperationTextParser(textFileHandler);
        Path inputTextFilePath = Path.of("input.txt");
        Path outputTextFilePath = Path.of("output.txt");
        textParser.processFile(inputTextFilePath, outputTextFilePath);

        // XML file
        XmlHandler xmlFileHandler = new XmlFileHandler();
        MathOperationXmlParser xmlParser = new MathOperationXmlParser(xmlFileHandler);
        Path inputXmlFilePath = Path.of("input.xml");
        Path outputXmlFilePath = Path.of("output.xml");
        xmlParser.processFile(inputXmlFilePath, outputXmlFilePath);

        // JSON file
        JsonHandler jsonFileHandler = new JsonFileHandler();
        MathOperationJsonParser jsonParser = new JsonFileParser(jsonFileHandler);
        Path inputJsonFilePath = Path.of("input.json");
        Path outputJsonFilePath = Path.of("output.json");
        jsonParser.processFile(inputJsonFilePath, outputJsonFilePath);
    }
}