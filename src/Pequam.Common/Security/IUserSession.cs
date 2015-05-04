
namespace Pequam.Common.Security
{
    /// <summary>
    ///     Provides access to information pertaining to the current principal.
    /// </summary>
    public interface IUserSession
    {
        string Firstname { get; }
        string Lastname { get; }
        string Username { get; }
        bool IsInRole(string roleName);
    }
}
