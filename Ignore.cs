namespace NRoelfs_Doc;

/// <summary>
/// This class is responsible for handling the ignore options.
/// It allows you to ignore certain files or directories during the scan.
/// </summary>
internal class Ignore {
    public static readonly String[] OPTIONS = new String[] {
        "--ignore",
        "-I"
    };

    private const string GITIGNORE = ".gitignore";
    String[] _igorelist;
    public Ignore() {
        _igorelist = new String[] { };
    }

    const string USAGE = "Usage: NRoelfs_Doc [options] -I $PATH"
                            + "\n\nOptions:"
                            + "\n -s, --scan $PATH   Specify the path to scan for files."
                            + "\n -I, --ignore $PATH   Specify the path to ignore files."
                            + "\n valid Input are a .gitignore file or a comma separated list of files or directories to ignore."
                            + "\n * works as a Wildcard for all files and directories in the current directory.";

    internal void GetIgnoreList(string arg) {
        if(arg.EndsWith(GITIGNORE))
            _ExtractFromGitIgnore(arg);
        else{
            String[] args = arg.Split(',');
            _igorelist = _igorelist.Concat(args).ToArray();
        }
        foreach (var item in _igorelist){
            Console.WriteLine($"Ignoring: {item}");
        }
    }

    private void _ExtractFromGitIgnore(string path) {
        using StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream) {
            string? line = reader.ReadLine();
            if (String.IsNullOrEmpty(line)) continue;
            _igorelist = _igorelist.Append(line).ToArray();
        }
    }

    internal bool IsIgnored(string file) {
        return _igorelist.Contains(file);
    }
}