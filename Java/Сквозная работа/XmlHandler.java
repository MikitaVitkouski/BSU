import org.w3c.dom.Document;

import java.io.IOException;
import java.nio.file.Path;

public interface XmlHandler {
    Document readXmlFile(Path filePath) throws IOException;

    void writeXmlFile(Path filePath, Document document) throws IOException;
}