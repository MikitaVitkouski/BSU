import org.testng.annotations.Test;
import org.w3c.dom.Document;
import org.w3c.dom.Element;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardOpenOption;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import static org.testng.AssertJUnit.assertNotNull;

public class XmlFileHandlerTest {

    @Test
    void testReadXmlFile() throws IOException {
        Path testFilePath = Path.of("test.xml");
        createSampleXmlFile(testFilePath);

        XmlHandler xmlFileHandler = new XmlFileHandler();
        Document document = xmlFileHandler.readXmlFile(testFilePath);

        assertNotNull(document);
    }

    @Test
    void testWriteXmlFile() throws Exception {
        Path testFilePath = Path.of("test_write.xml");

        XmlHandler xmlFileHandler = new XmlFileHandler();
        Document document = createSampleDocument();

        xmlFileHandler.writeXmlFile(testFilePath, document);

        XmlHandler xmlFileHandlerForRead = new XmlFileHandler();
        Document readDocument = xmlFileHandlerForRead.readXmlFile(testFilePath);
        assertNotNull(readDocument);
    }

    private void createSampleXmlFile(Path filePath) throws IOException {
        String xmlContent = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                "<root>\n" +
                "    <element>Test</element>\n" +
                "</root>";

        Files.write(filePath, xmlContent.getBytes(), StandardOpenOption.CREATE, StandardOpenOption.WRITE);
    }

    private Document createSampleDocument() throws Exception {
        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
        DocumentBuilder builder = factory.newDocumentBuilder();
        Document document = builder.newDocument();

        // Create a sample XML structure within the document
        Element rootElement = document.createElement("root");
        document.appendChild(rootElement);

        Element element = document.createElement("element");
        element.appendChild(document.createTextNode("Test"));
        rootElement.appendChild(element);

        return document;
    }
}