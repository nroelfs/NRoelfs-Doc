using System.Runtime.InteropServices;

namespace NRoelfs_Doc.Helpers;


/// <summary>
/// Wrapper for styled console Outputs.
/// </summary>
public struct Printer {
    /// <summary>
    /// Represents an indent for console output.
    /// <para> \t was to big for a small readable output.</para>
    /// </summary>
    const String INDENT = "  ";

    /// <summary>
    /// Print a line to the console with a given indent.
    /// <para>Indent is used to create a tree structure.</para>
    /// </summary>
    /// <param name="message">message to be printed</param>
    /// <param name="indent">number of indents</param>
    public static void Println(string message, int indent = 0) {
        addIndents(indent);
        Console.Write(message);
    }

    /// <summary>
    /// Print a line to the console without indent.
    /// </summary>
    /// <param name="message"></param>
    public static void Println(string message) {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Helper method to add indents to the console output.
    /// </summary>
    /// <param name="indent">number of indents</param>
    private static void addIndents(int indent) {
        for (int i = 0; i < indent; i++) {
            Console.Write(INDENT);
        }
    }
}