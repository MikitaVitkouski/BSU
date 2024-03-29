Contacts Task

a) Develop a Contact class defining an entry in the mobile phone's electronic address book, and containing at least the following fields:

*Name (individual's or organization's name)
*Mobile phone number
Work phone number
Home phone number
Email address
Webpage address
Address
Fields marked with * are mandatory; the rest can be empty.

b) The Contact class should implement:

The Comparable and Comparator interfaces with the ability to choose a specific field for comparison.
The Iterator interface, serving as an indexer for all fields of the Contact object.
A method for saving the values of all fields in a text string (override toString()).
A constructor or method for initializing an object from a text string.
c) To test the Contact class, create a console application (ContactsApp) that allows:

Creating a small array of contacts.
Printing contacts sorted by a selected field.
