import com.udojava.evalex.Expression;

import org.w3c.dom.Document;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.math.BigDecimal;
import java.nio.file.Path;

public class MathOperationXmlParser {
    private final XmlHandler xmlHandler;

    public MathOperationXmlParser(XmlHandler xmlHandler) {
        this.xmlHandler = xmlHandler;
    }

    protected void processMathExpressions(Document document) {
        NodeList mathElements = document.getElementsByTagName("math");

        for (int i = 0; i < mathElements.getLength(); i++) {
            Node mathNode = mathElements.item(i);

            if (mathNode.getNodeType() == Node.ELEMENT_NODE) {
                String result = parseAndReplaceMathExpression(mathNode.getTextContent());
                mathNode.setTextContent(result);
            }
        }
    }

    protected String parseAndReplaceMathExpression(String input) {
        try {
            if (input.trim().isEmpty()) {
                return input;
            }

            Expression expression = new Expression(input);
            BigDecimal result = expression.eval();

            return String.format("%s = %s", input, result.toString());
        } catch (Exception e) {
            e.printStackTrace();
            return input + " (Error)";
        }
    }

    public void processFile(Path inputFilePath, Path outputFilePath) {
        try {
            Document document = xmlHandler.readXmlFile(inputFilePath);
            processMathExpressions(document);
            xmlHandler.writeXmlFile(outputFilePath, document);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}