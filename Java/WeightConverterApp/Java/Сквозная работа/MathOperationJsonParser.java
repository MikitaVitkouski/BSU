import com.udojava.evalex.Expression;
import java.math.BigDecimal;
import java.nio.file.Path;
import java.util.Map;

public class MathOperationJsonParser {
    private final JsonHandler jsonHandler;

    public MathOperationJsonParser(JsonHandler jsonHandler) {
        this.jsonHandler = jsonHandler;
    }

    protected void processMathExpressions(Map<String, Object> jsonMap) {
        for (Map.Entry<String, Object> entry : jsonMap.entrySet()) {
            if (entry.getValue() instanceof String) {
                String result = parseAndReplaceMathExpression((String) entry.getValue());
                jsonMap.put(entry.getKey(), result);
            }
        }
    }

    protected String parseAndReplaceMathExpression(String input) {
        try {
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
            Map<String, Object> jsonMap = jsonHandler.readJsonFile(inputFilePath);
            processMathExpressions(jsonMap);
            jsonHandler.writeJsonFile(outputFilePath, jsonMap);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}