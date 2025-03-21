using NRoelfs_Doc.Helpers;

namespace NRoelfs_Doc.Models;

/// <summary>
/// Represents a method in a class.
/// </summary>
public class Method {
    /// <summary>
    /// The name of the method. <br/>
    /// Empty string if the method is a constructor.
    /// </summary>
    public required String Name { get; set; } = String.Empty;

    /// <summary>
    /// The access modifier of the method.
    /// </summary>
    public required AccessModifier AccessModifier { get; set; }

    /// <summary>
    /// The return type of the method.
    /// </summary>
    public required Type ReturnType { get; set; }

    /// <summary>
    /// The parameters of the method.
    /// </summary>
    public required ICollection<Parameter> Parameters { get; set; } = new List<Parameter>();
}