import java.nio.file.Paths;
import java.util.Scanner;

public class MainApp {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        while (true) {
            System.out.println("==== Main Menu ====");
            System.out.println("1. Process Text File");
            System.out.println("2. Process XML File");
            System.out.println("3. Process JSON File");
            System.out.println("4. Decompress and Process ZIP File");
            System.out.println("5. Exit");
            System.out.print("Enter your choice (1-5): ");

            int choice = scanner.nextInt();
            scanner.nextLine(); // Consume the newline character

            switch (choice) {
                case 1:
                    processFileType("txt", scanner);
                    break;
                case 2:
                    processFileType("xml", scanner);
                    break;
                case 3:
                    processFileType("json", scanner);
                    break;
                case 4:
                    try {
                        System.out.print("Enter the ZIP file path: ");
                        String zipFilePath = scanner.nextLine();
                        String extractTo = "extracted/";
                        CompressionZip.decompressAndProcess(zipFilePath, extractTo, scanner);
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                    break;
                case 5:
                    System.out.println("Exiting the program. Goodbye!");
                    System.exit(0);
                default:
                    System.out.println("Invalid choice. Please enter a number between 1 and 5.");
            }
        }
    }

    private static void processFileType(String fileType, Scanner scanner) {
        System.out.print("Enter the source directory path: ");
        String sourceDirectory = scanner.nextLine();

        try {
            CompressionZip.processFilesInDirectory(Paths.get(sourceDirectory), fileType, scanner);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}