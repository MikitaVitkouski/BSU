import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardOpenOption;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;
import org.w3c.dom.Document;
import org.xml.sax.SAXException;

public class XmlFileHandler implements XmlHandler {
    /**
     * Reads an XML file and returns a Document object.
     *
     * @param filePath The path to the XML file.
     * @return The Document object representing the XML content.
     * @throws IOException If an error occurs while reading the file.
     */
    @Override
    public Document readXmlFile(Path filePath) throws IOException {
        try {
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            DocumentBuilder builder = factory.newDocumentBuilder();
            return builder.parse(filePath.toFile());
        } catch (ParserConfigurationException | SAXException e) {
            throw new IOException("Failed to read XML file", e);
        }
    }

    /**
     * Writes a Document object to an XML file.
     *
     * @param filePath The path to the XML file.
     * @param document The Document object to write to the file.
     * @throws IOException If an error occurs while writing to the file.
     */
    @Override
    public void writeXmlFile(Path filePath, Document document) throws IOException {
        try {
            TransformerFactory transformerFactory = TransformerFactory.newInstance();
            Transformer transformer = transformerFactory.newTransformer();
            DOMSource source = new DOMSource(document);
            StreamResult result = new StreamResult(Files.newBufferedWriter(filePath, StandardOpenOption.CREATE, StandardOpenOption.WRITE));

            transformer.transform(source, result);
        } catch (Exception e) {
            throw new IOException("Failed to write XML file", e);
        }
    }
}