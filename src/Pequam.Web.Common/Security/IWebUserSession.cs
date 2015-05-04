using System;
using Pequam.Common.Security;

namespace Pequam.Web.Common.Security
{
    /// <summary>
    ///     Provides access to information pertaining to the current
    ///     web request and security principal.
    /// </summary>
    public interface IWebUserSession : IUserSession
    {
        string ApiVersionInUse { get; }
        Uri RequestUri { get; }
        string HttpRequestMethod { get; }
    }
}
