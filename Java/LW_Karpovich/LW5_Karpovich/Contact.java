package org.example;

import java.util.Comparator;
import java.util.Iterator;
import java.util.NoSuchElementException;
public class Contact implements Comparable<Contact>, Iterator<String> {
    private String name;
    private String mobilePhoneNumber;
    private String workPhoneNumber;
    private String homePhoneNumber;
    private String emailAddress;
    private String webpageAddress;
    private String address;

    private int currentIndex = 0;
    public Contact(String name, String mobilePhoneNumber, String workPhoneNumber, String homePhoneNumber,
                   String emailAddress, String webpageAddress, String address) {
        this.name = name;
        this.mobilePhoneNumber = mobilePhoneNumber;
        this.workPhoneNumber = workPhoneNumber;
        this.homePhoneNumber = homePhoneNumber;
        this.emailAddress = emailAddress;
        this.webpageAddress = webpageAddress;
        this.address = address;
    }

    public Contact() {

    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getMobilePhoneNumber() {
        return mobilePhoneNumber;
    }

    public void setMobilePhoneNumber(String mobilePhoneNumber) {
        this.mobilePhoneNumber = mobilePhoneNumber;
    }

    public String getWorkPhoneNumber() {
        return workPhoneNumber;
    }

    public void setWorkPhoneNumber(String workPhoneNumber) {
        this.workPhoneNumber = workPhoneNumber;
    }

    public String getHomePhoneNumber() {
        return homePhoneNumber;
    }

    public void setHomePhoneNumber(String homePhoneNumber) {
        this.homePhoneNumber = homePhoneNumber;
    }

    public String getEmailAddress() {
        return emailAddress;
    }

    public void setEmailAddress(String emailAddress) {
        this.emailAddress = emailAddress;
    }

    public String getWebpageAddress() {
        return webpageAddress;
    }

    public void setWebpageAddress(String webpageAddress) {
        this.webpageAddress = webpageAddress;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public int compareTo(Contact other) {
        return this.name.compareTo(other.name);
    }

    public static Comparator<Contact> getComparatorByField(String field) {
        switch(field) {
            case "name":
                return Comparator.comparing(Contact::getName);
            case "mobilePhoneNumber":
                return Comparator.comparing(Contact::getMobilePhoneNumber);
            case "workPhoneNumber":
                return Comparator.comparing(Contact::getWorkPhoneNumber);
            case "homePhoneNumber":
                return Comparator.comparing(Contact::getHomePhoneNumber);
            case "emailAddress":
                return Comparator.comparing(Contact::getEmailAddress);
            case "webpageAddress":
                return Comparator.comparing(Contact::getWebpageAddress);
            case "Address":
                return Comparator.comparing(Contact::getAddress);
            default:
                throw new IllegalArgumentException("Invalid field for comparison");

        }
    }

    @Override
    public boolean hasNext() {
        return currentIndex < 7;
    }

    @Override
    public String next() {
        if(!hasNext()) {
            throw new NoSuchElementException();
        }
        switch(currentIndex) {
            case 0:
                currentIndex++;
                return name;
            case 1:
                currentIndex++;
                return mobilePhoneNumber;
            case 2:
                currentIndex++;
                return workPhoneNumber;
            case 3:
                currentIndex++;
                return homePhoneNumber;
            case 4:
                currentIndex++;
                return emailAddress;
            case 5:
                currentIndex++;
                return webpageAddress;
            case 6:
                currentIndex++;
                return address;
            default:
                throw new NoSuchElementException();
        }
    }

    // Method to save values of all fields in a text string
    public String toString() {
        return String.format("Name: %s, Mobile: %s, Work: %s, Home: %s, Email: %s, Webpage: %s, Address: %s",
                name,mobilePhoneNumber,workPhoneNumber, homePhoneNumber,emailAddress,webpageAddress,address);
    }

    //Method to init object from a text string
    public static Contact fromString(String text) {
        String[] values = text.split(", ");
        if(values.length != 7) {
            throw new IllegalArgumentException("Invalid format for input string");
        }

        //Create and return a new Contact object
        return new Contact(values[0],values[1], values[2],values[3],values[4],values[5],values[6]);
    }
}