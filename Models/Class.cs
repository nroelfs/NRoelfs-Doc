namespace NRoelfs_Doc.Models;

/// <summary>
/// This class represents a class/struct/record in the codebase.
/// </summary>
public class Class {
    /// <summary>
    /// The name of the class.
    /// </summary>
    public  required String Name { get; set; }

    /// <summary>
    /// The access modifier of the class.
    /// </summary>
    public required String Namespace { get; set; }

    /// <summary>
    /// Collection of Fields in the class.
    /// </summary>
    public required ICollection<Field> Fields { get; set; } = new List<Field>();

    /// <summary>
    /// Collection of Methods in the class.
    /// </summary>
    public required ICollection<Method> Methods { get; set; } = new List<Method>();

}