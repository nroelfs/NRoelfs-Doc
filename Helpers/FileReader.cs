using System.Text;
using NRoelfs_Doc.Models;

namespace NRoelfs_Doc.Helpers;

/// <summary>
/// Helper class to read file contents and return it as Class object
/// </summary>
public class FileReader(){

    /// <summary>
    /// Reads the file and returns a Class object.
    /// </summary>
    /// <param name="file"><see cref="FileInfo"/></param>
    /// <param name="verbose"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static Class ReadFile(FileInfo file, bool verbose = false ) {
        // Class? output = null; ;
        if(verbose) {
            Printer.Println($"Reading file: {file.FullName}");
        }
        using var reader = new StreamReader(file.FullName);
        String text = reader.ReadToEnd();

        throw new NotImplementedException("FileReader.ReadFile not implemented");
    }
}