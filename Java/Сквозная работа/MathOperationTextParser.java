import com.udojava.evalex.Expression;

import java.math.BigDecimal;
import java.nio.file.Path;
import java.util.List;

public class MathOperationTextParser {
    private final FileHandler fileHandler;

    public MathOperationTextParser(FileHandler fileHandler) {
        this.fileHandler = fileHandler;
    }

    protected void processMathExpressions(List<String> lines) {
        for (int i = 0; i < lines.size(); i++) {
            String line = lines.get(i);
            String result = parseAndReplaceMathExpression(line);
            lines.set(i, result);
        }
    }

    protected String parseAndReplaceMathExpression(String input) {
        try {
            Expression expression = new Expression(input);
            BigDecimal result = expression.eval();

            String resultString = String.format("%s = %s", input, result.toString());
            return resultString;
        } catch (Exception e) {
            e.printStackTrace();
            return input + " (Error)";
        }
    }

    public void processFile(Path inputFilePath, Path outputFilePath) {
        try {
            List<String> lines = fileHandler.readFile(inputFilePath);
            processMathExpressions(lines);
            fileHandler.writeFile(outputFilePath, lines);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}