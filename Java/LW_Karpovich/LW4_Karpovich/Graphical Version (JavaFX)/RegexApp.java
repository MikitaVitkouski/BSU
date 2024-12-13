import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ScrollPane;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;
import javafx.stage.Stage;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class RegexApp extends Application {
    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) {
        primaryStage.setTitle("Regex checker");

        GridPane grid = new GridPane();
        grid.setPadding(new Insets(10, 10, 10, 10));
        grid.setVgap(10);
        grid.setHgap(10);

        addPatternButton(grid, "MAC Address", "^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$");
        addPatternButton(grid, "Color HTML", "^(\\\\#[0-9A-Fa-f]{6})$");
        addPatternButton(grid, "DD/MM/YYYY", "^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/(16[0-9]{2}|[2-9][0-9]{3})$");
        addPatternButton(grid, "Email", "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
        addPatternButton(grid, "Six digit", "^([1-9]{6})$");

        ScrollPane scrollPane = new ScrollPane(grid);

        Scene scene = new Scene(scrollPane, 750, 750);
        primaryStage.setScene(scene);

        primaryStage.show();
    }

    private void addPatternButton(GridPane grid, String patternName, String regex) {
        Button button = new Button(patternName);
        grid.add(button, 0, grid.getRowCount());

        TextField inputField = new TextField();
        inputField.setPrefWidth(200);
        grid.add(inputField, 1, grid.getRowCount());

        Label resultLabel = new Label();
        grid.add(resultLabel, 2, grid.getRowCount());

        button.setOnAction(event -> {
            String input = inputField.getText();
            boolean isValid;

            try {
                isValid = isValidPattern(input, regex);
            } catch (Exception e) {
                isValid = false;
                e.printStackTrace();
            }

            if (isValid) {
                resultLabel.setText("Valid");
            } else {
                resultLabel.setText("Not Valid");
            }

            inputField.clear();
            inputField.requestFocus();
        });
    }

    private boolean isValidPattern(String input, String regex) {
        Pattern pattern = Pattern.compile(regex);
        Matcher matcher = pattern.matcher(input);
        return matcher.matches();
    }
}