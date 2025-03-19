
using NRoelfs_Doc.Helpers;

namespace NRoelfs_Doc;

internal static class Scan {

    static readonly String[] OPTIONS = new String[] {
        "--scan",
        "-s"
    };

    const string USAGE = "Usage: NRoelfs_Doc [options]"
        + "\n\nOptions:"
        + "\n -s, --scan $PATH   Specify the path to scan for files.";


    static Ignore ignore = new Ignore();


    /// <summary>
    /// Handles the scan options.
    /// </summary>
    /// <param name="args"></param>
    /// <param name="verbose"></param>
    internal static void Handle(String[] args, bool verbose = false) {

        if(args.Length <= 1) {
            Console.WriteLine(USAGE);
            Environment.Exit(0);
        }
        buildIgoreList(args, verbose);
        int index = args.ToList().FindIndex(arg => OPTIONS.Contains(arg));
        DirectoryInfo dir = new DirectoryInfo(args[index + 1]);
        if(!dir.Exists) {
            Printer.Println($"Directory {dir.FullName} does not exist.");
            Environment.Exit(1);
        }
        if(verbose) {
            Printer.Println($"Scanning directory: {dir.FullName}");
            Printer.Println($"Files Found: {dir.GetFiles().Length}");
        }
        if(dir.GetFiles().Length == 0) {
            Printer.Println($"Directory {dir.FullName} is empty.");
            Environment.Exit(1);
        }
        PrintDir(dir, 0, verbose);
    }

    /// <summary>
    /// Recursively prints the directory structure.
    /// </summary>
    /// <param name="dir">directory to print</param>
    /// <param name="indent">current number of indents</param>
    /// <param name="verbose"></param>
    static void PrintDir(DirectoryInfo dir, int indent = 0, bool verbose = false) {
        foreach (var file in dir.GetFiles()){
            if(ignore.IsIgnored(file.Name)) {
                if(verbose) {
                    Printer.Println($"Ignoring: {file.Name}");
                }
            } else {
                Printer.Println($"~ {file.Name} :\n", indent);
            }

        }
        foreach (var subDir in dir.GetDirectories()){
            if(ignore.IsIgnored("/"+subDir.Name)) {
                if(verbose) {
                    Printer.Println($"Ignoring: {subDir.Name}");
                }
            } else {
                Printer.Println($"~ {subDir.Name} :\n", indent);
                PrintDir(subDir,++indent, verbose);
                indent--;
            }
        }
    }

    /// <summary>
    /// responsible for building the ignore list.
    /// </summary>
    /// <param name="args"></param>
    /// <param name="verbose"></param>
    private static void buildIgoreList(String[] args, bool verbose = false){
        if(verbose) {
            Printer.Println("Building ignore list...");
        }
        if(args.Any(x => Ignore.OPTIONS.Contains(x))) {
            if(ignore == null) ignore = new();
            int ignoreIndex = args.ToList().FindIndex(arg => Ignore.OPTIONS.Contains(arg));
            ignore.GetIgnoreList(args[ignoreIndex + 1]);
        }
    }
}