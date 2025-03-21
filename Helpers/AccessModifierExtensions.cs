namespace NRoelfs_Doc.Helpers;

/// <summary>
/// Extensions for the <see cref="AccessModifier"/> enum.
/// </summary>
public static class AccessModifierExtensions
{
    /// <summary>
    /// Converts an AccessModifier enum to a string.
    /// </summary>
    /// <param name="accessModifier"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static string ToString(this AccessModifier accessModifier)
    {
        return accessModifier switch
        {
            AccessModifier.Public => "public",
            AccessModifier.Private => "private",
            AccessModifier.Protected => "protected",
            AccessModifier.Internal => "internal",
            AccessModifier.ProtectedInternal => "protected internal",
            AccessModifier.PrivateProtected => "private protected",
            AccessModifier.File => "file",
            _ => throw new ArgumentOutOfRangeException(nameof(accessModifier), accessModifier, null)
        };
    }

    /// <summary>
    /// Parses a string to an AccessModifier enum.
    /// </summary>
    /// <param name="accessModifier"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static AccessModifier Parse(string accessModifier)
    {
        return accessModifier.ToLower() switch
        {
            "public" => AccessModifier.Public,
            "private" => AccessModifier.Private,
            "protected" => AccessModifier.Protected,
            "internal" => AccessModifier.Internal,
            "protected internal" => AccessModifier.ProtectedInternal,
            "private protected" => AccessModifier.PrivateProtected,
            "file" => AccessModifier.File,
            _ => throw new ArgumentException($"Invalid access modifier: {accessModifier}")
        };
    }
}