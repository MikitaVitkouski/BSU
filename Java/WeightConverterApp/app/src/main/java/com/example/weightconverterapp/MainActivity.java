package com.example.weightconverterapp;

import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    private EditText weightInput;
    private Button convertButton;
    private TextView resultText;
    private Spinner fromUnitSpinner, toUnitSpinner;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        weightInput = findViewById(R.id.weightInput);
        convertButton = findViewById(R.id.convertButton);
        resultText = findViewById(R.id.resultText);
        fromUnitSpinner = findViewById(R.id.fromUnitSpinner);
        toUnitSpinner = findViewById(R.id.toUnitSpinner);

        String[] units = {"Килограммы", "Фунты", "Унции"};
        ArrayAdapter<String> adapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_item, units);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        fromUnitSpinner.setAdapter(adapter);
        toUnitSpinner.setAdapter(adapter);

        convertButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                convertWeight();
            }
        });
    }

    private void convertWeight() {
        String fromUnit = fromUnitSpinner.getSelectedItem().toString();
        String toUnit = toUnitSpinner.getSelectedItem().toString();
        String input = weightInput.getText().toString();

        if (input.isEmpty()) {
            resultText.setText("Введите вес!");
            return;
        }

        double weight = Double.parseDouble(input);

        if (weight <= 0) {
            resultText.setText("Вес должен быть больше нуля!");
            return;
        }

        double result = 0.0;

        if (fromUnit.equals("Килограммы")) {
            if (toUnit.equals("Фунты")) {
                result = weight * 2.20462;
            } else if (toUnit.equals("Унции")) {
                result = weight * 35.274;
            } else if (toUnit.equals("Килограммы")) {
                result = weight;
            }
        } else if (fromUnit.equals("Фунты")) {
            if (toUnit.equals("Килограммы")) {
                result = weight * 0.453592;
            } else if (toUnit.equals("Унции")) {
                result = weight * 16.0;
            } else if (toUnit.equals("Фунты")) {
                result = weight;
            }
        } else if (fromUnit.equals("Унции")) {
            if (toUnit.equals("Килограммы")) {
                result = weight * 0.0283495;
            } else if (toUnit.equals("Фунты")) {
                result = weight * 0.0625;
            } else if (toUnit.equals("Унции")) {
                result = weight;
            }
        }

        resultText.setText(String.format("Результат: %.2f %s", result, toUnit));
    }
}