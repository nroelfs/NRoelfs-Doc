using NRoelfs_Doc.Helpers;

namespace NRoelfs_Doc.Models;

/// <summary>
/// This class represents a field in a class.
/// </summary>
public class Field : Parameter
{
    /// <summary>
    /// Access modifier of the field.
    /// </summary>
    public required AccessModifier AccessModifier { get; set; }

}