namespace NRoelfs_Doc.Helpers;


/// <summary>
/// This enum represents the access modifiers in C#.
/// </summary>
public enum AccessModifier
{
    /// <summary>
    /// Code in any assembly can access this type or member. The accessibility level of the containing type controls the accessibility level of public members of the type.
    /// </summary>
    Public,

    /// <summary>
    /// Only code declared in the same class or struct can access this member.
    /// </summary>
    Private,

    /// <summary>
    /// Only code in the same class or in a derived class can access this type or member.
    /// </summary>
    Protected,

    /// <summary>
    /// Only code in the same assembly can access this type or member.
    /// </summary>
    Internal,

    /// <summary>
    /// Only code in the same assembly or in a derived class in another assembly can access this type or member.
    /// </summary>
    ProtectedInternal,

    /// <summary>
    /// Only code in the same assembly and in the same class or a derived class can access the type or member.
    /// </summary>
    PrivateProtected,

    /// <summary>
    /// Only code in the same file can access the type or member
    /// </summary>
    File
}
