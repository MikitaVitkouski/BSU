package org.example;

/*
* Mikita Vitkouski
*  */

import java.util.Arrays;
import java.util.Scanner;

public class ContactsApp {
    public static void main(String[] args) {
        Contact[] contacts = {
                new Contact("Nikita", "375-33-375-41-85", "111-222-3333", "555-555-5555", "vitkovskiynikitos2004@gmail.com", "nikita.com", "Svyazistov 7"),
                new Contact("Jenya", "375-33-667-90-08", "444-555-6666", "777-777-7777", "sovenokrelax@gmail.com", "john.com", "Svyazistov 4"),
                new Contact("Nastya", "375-33-350-73-96", "888-999-0000", "222-222-2222", "nastuhakrutaya@gmail.com", "nastya.com", "Svyazistov 7"),
        };

        Scanner scanner = new Scanner(System.in);

        while (true) {
            System.out.println("\nOptions:");
            System.out.println("1. Print Unsorted Contacts");
            System.out.println("2. Sort Contacts");
            System.out.println("0. Exit");

            System.out.print("Enter option: ");
            int option = scanner.nextInt();
            scanner.nextLine();

            switch (option) {
                case 1:
                    System.out.println("Unsorted Contacts:");
                    printContacts(contacts);
                    break;
                case 2:
                    System.out.println("Enter field for sorting (name, mobilePhoneNumber, workPhoneNumber, homePhoneNumber, emailAddress, webpageAddress, Address):");
                    String field = scanner.nextLine().trim();
                    Arrays.sort(contacts, Contact.getComparatorByField(field));
                    System.out.println("\nSorted Contacts:");
                    printContacts(contacts);
                    break;
                case 0:
                    System.out.println("Exiting...");
                    System.exit(0);
                default:
                    System.out.println("Invalid option. Try again.");
            }
        }
    }

    private static void printContacts(Contact[] contacts) {
        for (Contact contact : contacts) {
            System.out.println(contact);
        }
    }
}