using NRoelfs_Doc.Helpers;

namespace NRoelfs_Doc;

internal static class Dir {

    static Ignore _ignore = new Ignore();
    static DirectoryInfo? _directory;
    static ICollection<DirectoryInfo> _directories = new List<DirectoryInfo>();
    static readonly String[] AcceptedExtensions = new String[] {
        ".cs",
    };
    static ICollection<FileInfo> _files = new List<FileInfo>();
    public static String[] OPTIONS = new String[] {
        "--dir",
        "-d"
    };


    /// <summary>
    /// Handles the directory options.
    /// </summary>
    /// <param name="args"></param>
    /// <param name="verbose"></param>
    public static void Handle(String[] args, bool verbose = false) {
        buildIgoreList(args, verbose);
        int index = args.ToList().FindIndex(arg => OPTIONS.Contains(arg));
        _directory = new DirectoryInfo(args[index + 1]);
        getFiles(verbose);
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
            if(_ignore == null) _ignore = new();
            int ignoreIndex = args.ToList().FindIndex(arg => Ignore.OPTIONS.Contains(arg));
            _ignore.GetIgnoreList(args[ignoreIndex + 1]);
        }
    }

    /// <summary>
    /// Gets the files from the directory.
    /// </summary>
    /// <param name="verbose"></param>
    private static void getFiles(bool verbose = false) {
        if(verbose) {
            Printer.Println("Getting files...");
        }
        if(_directory == null) {
            Printer.Println("Directory not set.");
            Environment.Exit(1);
        }
        _files = _directory
                .GetFiles(AcceptedExtensions, SearchOption.AllDirectories, verbose)
                .Where(x => !_ignore.IsIgnored(x.FullName))
                .ToArray();
        if(verbose) {
            Printer.Println($"Apply Filter for Ignored Files\nFiles Found: {_files.Count}");
        }
        if(_files.Count == 0) {
            Printer.Println($"Directory {_directory.FullName} is empty.");
            Environment.Exit(1);
        }
    }
}