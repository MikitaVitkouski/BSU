import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;
import javafx.stage.Stage;

import java.util.Arrays;

public class MatrixSumApp extends Application {

    private TextArea resultArea;

    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) {
        primaryStage.setTitle("Matrix Sum App");

        GridPane grid = new GridPane();
        grid.setPadding(new Insets(10, 10, 10, 10));
        grid.setVgap(5);
        grid.setHgap(5);

        TextField sizeField = new TextField();
        Button generateButton = new Button("Generate Matrix");

        resultArea = new TextArea();
        resultArea.setEditable(false);
        resultArea.setPrefRowCount(10);

        grid.add(sizeField, 0, 0);
        grid.add(generateButton, 1, 0);
        grid.add(resultArea, 0, 1, 2, 1);

        generateButton.setOnAction(event -> generateMatrix(Integer.parseInt(sizeField.getText())));

        Scene scene = new Scene(grid, 400, 300);
        primaryStage.setScene(scene);

        primaryStage.show();
    }

    private void generateMatrix(int n) {
        int[][] matrix = new int[n][n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                matrix[i][j] = (int) (Math.random() * 101);
            }
        }

        resultArea.setText("Original matrix:\n");
        printMatrix(matrix);

        int maxSum = findMaxSum(matrix);

        resultArea.appendText("\nMaximum sum of elements in diagonals parallel to the main diagonal: " + maxSum);
    }

    private void printMatrix(int[][] matrix) {
        for (int[] row : matrix) {
            resultArea.appendText(Arrays.toString(row) + "\n");
        }
    }

    private int findMaxSum(int[][] matrix) {
        int n = matrix.length;
        int maxSum = Integer.MIN_VALUE;

        for (int i = 0; i < n; i++) {
            int sum = 0;
            for (int j = 0; j < n - i; j++) {
                sum += matrix[j][i + j];
            }
            maxSum = Math.max(maxSum, sum);
        }

        for (int i = 1; i < n; i++) {
            int sum = 0;
            for (int j = 0; j < n - i; j++) {
                sum += matrix[i + j][j];
            }
            maxSum = Math.max(maxSum, sum);
        }

        return maxSum;
    }
}