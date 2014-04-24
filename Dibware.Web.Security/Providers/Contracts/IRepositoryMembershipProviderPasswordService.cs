using System;

namespace Dibware.Web.Security.Providers.Contracts
{
    /// <summary>
    /// Defines the expected members for the service which a 
    /// RepositoryMembershipProvider requires for PASSWORD based operations
    /// </summary>
    public interface IRepositoryMembershipProviderPasswordService
    {
        #region Properties

        /// <summary>
        /// Gets the minimum password length
        /// </summary>
        Int32 MinRequiredPasswordLength { get; }

        /// <summary>
        /// Gets the minimum required non alphanumeric characters
        /// </summary>
        Int32 MinRequiredNonAlphanumericCharacters { get; }

        /// <summary>
        /// Gets the regular expression for the password strength
        /// </summary>
        String PasswordStrengthRegularExpression { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the confirmation token.
        /// </summary>
        /// <returns></returns>
        String CreateConfirmationToken();

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

        #endregion
    }
}