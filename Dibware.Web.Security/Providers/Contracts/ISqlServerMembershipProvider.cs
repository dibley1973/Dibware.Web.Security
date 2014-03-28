using System;

namespace Dibware.Web.Security.Providers.Contracts
{
    /// <summary>
    /// defines the expected members for a SqlServerMembershipProvider
    /// </summary>
    public interface ISqlServerMembershipProvider
    {

        /// <summary>
        /// Verifies that the specified user name and password exist in the data source.
        /// </summary>
        /// <param name="username">The name of the user to validate.</param>
        /// <param name="password">The password for the specified user.</param>
        /// <returns>
        /// true if the specified username and password are valid; otherwise, false.
        /// </returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.NotImplementedException"></exception>
        Boolean ValidateUser(String username, String password);
    }
}
