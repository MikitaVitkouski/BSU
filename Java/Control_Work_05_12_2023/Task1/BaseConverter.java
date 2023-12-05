package org.example;

import java.util.Locale;

public class BaseConverter {
    private double celsius;

    BaseConverter() { celsius = 0.0; }

    public BaseConverter(double celsius) {
        this.celsius = celsius;
    }

    public double convertToKelvin(){
        return celsius + 273.15;
    }

    public double convertToFahrenheit(){
        return ((celsius *9/5) + 32);
    }

    public static BaseConverter createWithLocale(double celsius, Locale locale) {
        String country = locale.getCountry();
        if(isFahrenheitCountry(country)) {
            return new FahrenheitConverter(celsius);
        }

        return new BaseConverter(celsius);
    }

    public static boolean isFahrenheitCountry(String country) {
        String[] fahrenheitCountries = {"BS","US","BZ","KY","PW"};
        for(String fahrenheitCountry : fahrenheitCountries) {
            if(fahrenheitCountry.equals(country)) {
                return true;
            }
        }

        return false;
    }

    private static class FahrenheitConverter extends BaseConverter {
        public FahrenheitConverter(double celsius) {
            super(celsius);
        }


        @Override
        public double convertToFahrenheit() {
            return super.convertToFahrenheit();
        }
    }
}