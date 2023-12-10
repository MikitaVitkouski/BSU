import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;
import javafx.stage.Stage;

import java.util.Arrays;

public class MatrixSwappingApp extends Application {

    private TextField[][] matrixFields;
    private TextArea resultArea;

    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) {
        primaryStage.setTitle("Matrix Swapping App");

        GridPane grid = new GridPane();
        grid.setPadding(new Insets(10, 10, 10, 10));
        grid.setVgap(5);
        grid.setHgap(5);

        TextField rowsField = new TextField();
        TextField colsField = new TextField();

        Button createMatrixButton = new Button("Create Matrix");
        createMatrixButton.setOnAction(e -> createMatrix(
                Integer.parseInt(rowsField.getText()),
                Integer.parseInt(colsField.getText())
        ));

        grid.add(createMatrixButton, 0, 0, 2, 1);

        grid.add(rowsField, 0, 1);
        grid.add(colsField, 1, 1);

        resultArea = new TextArea();
        resultArea.setEditable(false);
        resultArea.setPrefRowCount(5);
        grid.add(resultArea, 0, 2, 2, 1);

        Scene scene = new Scene(grid, 750, 750);
        primaryStage.setScene(scene);

        primaryStage.show();
    }

    private void createMatrix(int m, int n) {
        matrixFields = new TextField[m][n];

        GridPane matrixGrid = new GridPane();
        matrixGrid.setPadding(new Insets(10, 10, 10, 10));
        matrixGrid.setVgap(5);
        matrixGrid.setHgap(5);

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                matrixFields[i][j] = new TextField();
                matrixFields[i][j].setPrefWidth(50);
                matrixGrid.add(matrixFields[i][j], j, i);
            }
        }

        Button swapButton = new Button("Swap Rows");
        swapButton.setOnAction(event -> swapAndDisplayResult());

        matrixGrid.add(swapButton, 0, m, n, 1);

        GridPane mainGrid = new GridPane();
        mainGrid.add(matrixGrid, 0, 0);
        mainGrid.add(resultArea, 0, 1, 2, 1);

        Scene matrixScene = new Scene(mainGrid, 300, 400);
        Stage matrixStage = new Stage();
        matrixStage.setScene(matrixScene);
        matrixStage.setTitle("Matrix Input");
        matrixStage.show();
    }

    private void swapAndDisplayResult() {
        int m = matrixFields.length;
        int n = matrixFields[0].length;

        int[][] matrix = new int[m][n];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                try {
                    matrix[i][j] = Integer.parseInt(matrixFields[i][j].getText());
                } catch (NumberFormatException e) {
                    resultArea.setText("Invalid input. Please enter integers in all cells.");
                    return;
                }
            }
        }

        int maxRowIndex = 0, minRowIndex = 0;
        int max = matrix[0][0], min = matrix[0][0];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] > max) {
                    max = matrix[i][j];
                    maxRowIndex = i;
                }
                if (matrix[i][j] < min) {
                    min = matrix[i][j];
                    minRowIndex = i;
                }
            }
        }

        int[] temp = matrix[maxRowIndex];
        matrix[maxRowIndex] = matrix[minRowIndex];
        matrix[minRowIndex] = temp;

        for (int i = 0; i < m; i++) {
            if (matrix[i][i] == 0) {
                resultArea.appendText("Row with zero on the main diagonal: " + (i + 1) + "\n");
                int maxInRow = Arrays.stream(matrix[i]).max().getAsInt();
                resultArea.appendText("Maximum element in this row: " + maxInRow + "\n");
            }
        }

        resultArea.appendText("Matrix after swapping rows:\n" + matrixToString(matrix));
    }

    private String matrixToString(int[][] matrix) {
        StringBuilder sb = new StringBuilder();
        for (int[] row : matrix) {
            sb.append(Arrays.toString(row)).append('\n');
        }
        return sb.toString();
    }
}