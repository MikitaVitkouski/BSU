package org.example;

import java.util.Scanner;
import java.util.regex.Pattern;
import java.util.regex.Matcher;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter GUID: ");
        String input = scanner.nextLine();

        if (isValidGUID(input)) {
            System.out.println("GUID.");
        } else {
            System.out.println("not GUID.");
        }

        System.out.print("Enter MAC-address: ");
        String input1 = scanner.nextLine();

        if (isValidMacAddress(input1)) {
            System.out.println("MAC-address.");
        } else {
            System.out.println("not MAC-address.");
        }

        System.out.print("Enter URL-address: ");
        String input2 = scanner.nextLine();

        if (isValidURL(input2)) {
            System.out.println("URL-address.");
        } else {
            System.out.println("not URL-address.");
        }

        System.out.print("Enter Color HTML: ");
        String input3 = scanner.nextLine();

        if (isColorHTML(input3)) {
            System.out.println("Color HTML.");
        } else {
            System.out.println("not Color HTML.");
        }

        System.out.print("Enter DD/MM/YYYY: ");
        String input4 = scanner.nextLine();

        if (isValidDDMMYYYY(input4)) {
            System.out.println("DD/MM/YYYY.");
        } else {
            System.out.println("not DD/MM/YYYY.");
        }

        System.out.print("Enter email in format RFC2822: ");
        String input5 = scanner.nextLine();

        if (isValidEmailRFC2822(input5)) {
            System.out.println("email in format RFC2822.");
        } else {
            System.out.println("not email in format RFC2822.");
        }

        System.out.print("Enter IP-address: ");
        String input6 = scanner.nextLine();

        if (isValidIP(input6)) {
            System.out.println("IP-address.");
        } else {
            System.out.println("not IP-address.");
        }

        System.out.print("Enter strong Password: ");
        String input7 = scanner.nextLine();

        if (isValidPassword(input7)) {
            System.out.println("strong Password.");
        } else {
            System.out.println("not strong Password.");
        }

        System.out.print("Enter a six-digit number without leading zeros: ");
        String input8 = scanner.nextLine();

        if (isValidSixDigit(input8)) {
            System.out.println("The entered string is a six-digit number without leading zeros.");
        } else {
            System.out.println("The entered string is NOT a six-digit number without leading zeros.");
        }

    }

    public static boolean isValidGUID(String input) {
        String GUIDRegex = "^(\\{[0-9A-Fa-f]{8}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{12}\\}|[0-9A-Fa-f]{8}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{12})$";
        Pattern pattern = Pattern.compile(GUIDRegex);
        Matcher matcher = pattern.matcher(input);

        return matcher.matches();
    }

    public static boolean isValidMacAddress(String input) {
        String macAddressRegex = "^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$";
        Pattern pattern = Pattern.compile(macAddressRegex);
        Matcher matcher = pattern.matcher(input);

        return matcher.matches();
    }

    public static boolean isValidURL(String input) {
        String URLRegex = "^(https?://)?(?!-)(?!_)(?!.*\\s)[A-Za-z0-9-]+(\\.[A-Za-z0-9-]+)*(:(0-9{1,5}))?(/\\S*)?(\\?.*)?(#.*)?$";
        Pattern pattern = Pattern.compile(URLRegex);
        Matcher matcher = pattern.matcher(input);

        return matcher.matches();
    }

    public static boolean isColorHTML(String input) {
        String ColorHTMLRegex = "^(\\#[0-9A-Fa-f]{6})$";
        Pattern pattern = Pattern.compile(ColorHTMLRegex);
        Matcher matcher = pattern.matcher(input);

        return matcher.matches();
    }

    public static boolean isValidDDMMYYYY(String input) {
        String DDMMYYYYRegex = "^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/(16[0-9]{2}|[2-9][0-9]{3})$";
        Pattern pattern = Pattern.compile(DDMMYYYYRegex);
        Matcher matcher = pattern.matcher(input);

        return matcher.matches();
    }

    public static boolean isValidEmailRFC2822(String input) {
        String EmailRFC2822Regex = "^(?=.{1,256}$)[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\\\.[a-zA-Z]{2,}$";
        Pattern pattern = Pattern.compile(EmailRFC2822Regex);
        Matcher matcher = pattern.matcher(input);

        return matcher.matches();
    }

    public static boolean isValidIP(String input) {
        String IPRegex = "^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
        Pattern pattern = Pattern.compile(IPRegex);
        Matcher matcher = pattern.matcher(input);

        return matcher.matches();
    }

    public static boolean isValidPassword(String input) {
        String PasswordRegex = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$";
        Pattern pattern = Pattern.compile(PasswordRegex);
        Matcher matcher = pattern.matcher(input);

        return matcher.matches();
    }

    public static boolean isValidSixDigit(String input) {
        String SixDigitRegex = "^([1-9]{6})$";
        Pattern pattern = Pattern.compile(SixDigitRegex);
        Matcher matcher = pattern.matcher(input);

        return matcher.matches();
    }
}