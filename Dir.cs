using NRoelfs_Doc.Helpers;

namespace NRoelfs_Doc;

internal static class Dir {

    public static String[] OPTIONS = new String[] {
        "--dir",
        "-d"
    };
    public static void Handle(String[] args, bool verbose = false) {
        ExportTypeHelper dth = new();
        String? XMLDoc = _ExtractFilePath(args[args.ToList().FindIndex(arg => OPTIONS.Contains(arg)) + 1]);
    }

    #region Extracting From .XML Documentation
     /// <summary>
    /// Extracts the XML documentation file from the specified directory.
    /// </summary>
    /// <param name="directory"></param>
    /// <param name="verbose"></param>
    /// <returns></returns>
    private static String? _ExtractFilePath(String directory, bool verbose = false){
        if(verbose) Printer.Println($"Extracting Project Name from {directory}...");
        String projectName = new DirectoryInfo(directory).GetFiles("*.csproj").First().Name.Replace(".csproj", "");
        return _FindXML(directory, projectName, verbose);
    }

    /// <summary>
    /// Finds the XML documentation file in the specified directory.
    /// </summary>
    /// <param name="directoryInfo"></param>
    /// <param name="projectName"></param>
    /// <param name="verbose"></param>
    /// <returns></returns>
    private static String? _FindXML(String directoryInfo, string projectName, bool verbose = false){
        DirectoryInfo dir = new DirectoryInfo(directoryInfo);
        if(!dir.Exists) {
            Printer.Println($"Directory {dir.FullName} does not exist.");
            Environment.Exit(1);
        }
        if(verbose) {
            Printer.Println($"Searching for XML documentation file in {dir.FullName}...");
        }
        FileInfo? file = dir.GetFiles($"{projectName}.xml", SearchOption.AllDirectories).FirstOrDefault();
        if(verbose) {
            if(file != null) {
                Printer.Println($"Found XML documentation file: {file.FullName}");
            } else {
                Printer.Println($"No XML documentation file found in {dir.FullName}.");
            }
        }
        return file?.FullName;
    }

    #endregion
}