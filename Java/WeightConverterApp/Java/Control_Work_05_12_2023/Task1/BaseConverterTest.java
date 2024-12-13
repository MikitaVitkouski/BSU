package org.example;

import java.util.Locale;

import org.junit.jupiter.api.*;
import static org.junit.jupiter.api.Assertions.*;

public class BaseConverterTest {
    @Test
    public void testBaseConverter() {
        double celsiusTemperature = 25.0;
        BaseConverter baseConverter = new BaseConverter(celsiusTemperature);

        assertEquals(298.15, baseConverter.convertToKelvin(), 0.01);

        assertEquals(77.0, baseConverter.convertToFahrenheit(), 0.01);
    }

    @Test
    public void testFahrenheitConverter() {
        double celsiusTemperature = 25.0;
        Locale usLocale = new Locale("en", "US");
        BaseConverter usConverter = BaseConverter.createWithLocale(celsiusTemperature, usLocale);

        assertEquals(298.15, usConverter.convertToKelvin(), 0.01);
        
        assertEquals(77.0, usConverter.convertToFahrenheit(), 0.01);
    }
}
