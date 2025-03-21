namespace NRoelfs_Doc.Models;

/// <summary>
/// This class represents a parameter in a method.
/// </summary>
public class Parameter {
    /// <summary>
    /// The name of the parameter.
    /// </summary>
    public required String Name { get; set; }

    /// <summary>
    /// The type of the parameter.
    /// </summary>
    public required Type Type { get; set; }

    /// <summary>
    /// The default value of the parameter.
    /// </summary>
    public String? DefaultValue { get; set; }

    /// <summary>
    /// The description of the parameter.
    /// </summary>
    public String? Description { get; set; }

}