using System;

namespace Dibware.Web.Security.Providers.Contracts
{
    /// <summary>
    /// Defines the expected members for the service which a 
    /// RepositoryMembershipProvider requires for PASSWORD based operations
    /// </summary>
    public interface IRepositoryMembershipProviderPasswordService
    {
        /// <summary>
        /// Creates a salted PBKDF2 hash of the password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hash of the password.</returns>
        String CreateHash(String password);

        /// <summary>
        /// Validates the specified password given a hash of the correct one.
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <param name="correctHash">A hash of the correct password.</param>
        /// <returns><c>true</c> if the password is correct; otherwise <c>false</c>.</returns>
        Boolean ValidatePassword(String password, String correctHash);
    }
}