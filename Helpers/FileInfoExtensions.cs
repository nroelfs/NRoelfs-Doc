namespace NRoelfs_Doc.Helpers;


/// <summary>
/// Class tgat extends the FileInfo Class
/// </summary>
public static class FileInfoExtensions
{
    /// <summary>
    /// Gets all files in a directory with the specified extensions.
    /// </summary>
    /// <param name="directory"></param>
    /// <param name="extensions">List of file extensions to filter</param>
    /// <param name="searchOption">filter option</param>
    /// <param name="verbose">if true, the method will print the number of files found</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static FileInfo[] GetFiles(this DirectoryInfo directory, String[] extensions, SearchOption searchOption, bool verbose = false)
    {
        if (directory == null) throw new ArgumentNullException(nameof(directory));
        if (extensions == null || extensions.Length == 0) throw new ArgumentNullException(nameof(extensions));
        List<FileInfo> files = new List<FileInfo>();
        foreach ( String ext in extensions){
            String extension = ext;
            if(!ext.StartsWith("*")) extension  = "*" + ext;
            FileInfo[] tmp  = directory.GetFiles(extension, searchOption).ToArray();
            if(verbose) {
                Printer.Println($"Searching for {extension}...\nFound {tmp.Length} files.");
            }
            files.AddRange(tmp);
        }
        return files.ToArray();
    }
}