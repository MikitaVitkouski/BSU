package org.example;

import java.util.Locale;

public class Main {
    public static void main(String[] args) {
        double celsiusTemperature = 25.0;
        Locale defaultLocale = Locale.getDefault();

        BaseConverter baseConverter = BaseConverter.createWithLocale(celsiusTemperature, defaultLocale);
        System.out.println("Temperature in Celsius: " + celsiusTemperature);
        System.out.println("Temperature in Kelvin: " + baseConverter.convertToKelvin());
        System.out.println("Temperature in Fahrenheit: " + baseConverter.convertToFahrenheit());

        Locale usLocale = new Locale("en","US");
        BaseConverter usConverter = BaseConverter.createWithLocale(celsiusTemperature,usLocale);

        System.out.println("\nTemperature in Celsius: " + celsiusTemperature);
        System.out.println("Temperature in Kelvin: " + usConverter.convertToKelvin());
        System.out.println("Temperature in Fahrenheit: " + usConverter.convertToFahrenheit());
    }
}