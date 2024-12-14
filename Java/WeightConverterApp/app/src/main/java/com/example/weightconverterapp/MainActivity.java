package com.example.weightconverterapp;

import android.os.Bundle;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;
import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    private EditText weightInput;
    private Button convertButton;
    private TextView resultText;
    private CheckBox kgToLbCheckBox;
    private RadioGroup unitSelectionGroup;
    private RadioButton radioKgToLb, radioLbToKg, radioKgToOz;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        weightInput = findViewById(R.id.weightInput);
        convertButton = findViewById(R.id.convertButton);
        resultText = findViewById(R.id.resultText);
        kgToLbCheckBox = findViewById(R.id.kgToLbCheckBox);
        unitSelectionGroup = findViewById(R.id.unitSelectionGroup);
        radioKgToLb = findViewById(R.id.radioKgToLb);
        radioLbToKg = findViewById(R.id.radioLbToKg);
        radioKgToOz = findViewById(R.id.radioKgToOz);

        convertButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                convertWeight();
            }
        });
    }


}