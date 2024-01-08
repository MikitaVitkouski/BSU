import net.lingala.zip4j.ZipFile;
import net.lingala.zip4j.exception.ZipException;

import java.io.IOException;
import java.nio.file.Path;

public class ZipHandler {

    public void extractAll(String zipFilePath, String extractTo) throws IOException {
        try {
            ZipFile zipFile = new ZipFile(zipFilePath);
            zipFile.extractAll(extractTo);
        } catch (ZipException e) {
            throw new IOException("Failed to extract files from zip", e);
        }
    }
}