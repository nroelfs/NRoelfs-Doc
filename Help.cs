using System.Security.Cryptography.X509Certificates;
using NRoelfs_Doc.Helpers;
namespace NRoelfs_Doc;


/// <summary>
/// This class is a placeholder for help-related functionality.
/// </summary>
internal static class Help
{
    /// <summary>
    /// A dictionary that contains the help text for various command-line options.
    /// </summary>
    private static readonly Dictionary<string[], string> HelpText = new()
    {
        { new[] {"--help", "-h", "-?"} , "Displays this help message." },
        { new[] {"--verbose", "-v"}, "Enables verbose output." },
        { new[] {"--dir", "-d"}, "Specifies the directory to scan." },
        { new[] {"-output", "-o"}, "Specifies the directory for the output." },
        { new[] {"-i", "--info"}, "Displays information about the program." },
        { new[] {"-s, --scan"}, "Scans the specified directory for files and prints a report"},
        { new[] {"-I", "--ignore"}, "Allows you to ignore certain files or directories during the scan.\n Can Get a Blacklist of files or directories to ignore., also accepts a .gitognore file or comma separated list of files or directories."},
    };

    /// <summary>
    /// Prints the help message for all options.
    /// </summary>
    private static void PrintHelp()
    {
        Printer.Println("Usage: NRoelfs_Doc [options]");
        Printer.Println("Options:");
        foreach (var option in HelpText)
        {
            Printer.Println($"  {option.Key}: {option.Value}");
        }
    }

    /// <summary>
    /// Prints the help message for a specific option.
    /// </summary>
    /// <param name="option"></param>
    private static void PrintHelp(string option)
    {
        if (HelpText.Keys.Any(x => x.Contains(option)))
        {
            Printer.Println(HelpText.First(x => x.Key.Contains(option)).Value);
        }
        else
        {
            Printer.Println($"No help available for option: {option}");
        }
    }

    /// <summary>
    /// Handles the command-line arguments and prints the help message if necessary.
    /// </summary>
    /// <param name="args"></param>
    internal static void Handle(string[] args){
        String[] helpOptions = HelpText.Keys.First();
        if(args.Any(x => helpOptions.Contains(x)))
        {
            int index = args.ToList().FindIndex(arg => helpOptions.Contains(arg));
            if(index > 0)
            {
                Help.PrintHelp(args[index - 1]);
            } else {
                Help.PrintHelp();
            }
            Environment.Exit(0);
        }
    }
}