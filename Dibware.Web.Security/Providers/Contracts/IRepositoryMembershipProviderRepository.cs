using Dibware.Web.Security.Membership;
using System;
using System.Collections.Generic;

namespace Dibware.Web.Security.Providers.Contracts
{
    /// <summary>
    /// Defines the expected members for a RepositoryMembershipProvider repository
    /// </summary>
    public interface IRepositoryMembershipProviderRepository
    {
        /// <summary>
        /// Activates a pending membership account.
        /// </summary>
        /// <param name="accountConfirmationToken">A confirmation token to pass to the authentication provider.</param>
        /// <returns>
        /// true if the account is confirmed; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        Boolean ConfirmAccount(String accountConfirmationToken);

        /// <summary>
        /// Activates a pending membership account for the specified user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="accountConfirmationToken">A confirmation token to pass to the authentication provider.</param>
        /// <returns>
        /// true if the account is confirmed; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        Boolean ConfirmAccount(String userName, String accountConfirmationToken);

        /// <summary>
        /// When overridden in a derived class, creates a new user profile and a new membership account.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        /// <param name="requireConfirmation">(Optional) true to specify that the user account must be confirmed; otherwise, false. The default is false.</param>
        /// <param name="values">(Optional) A dictionary that contains additional user attributes to store in the user profile. The default is null.</param>
        /// <returns>
        /// A token that can be sent to the user to confirm the user account.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        String CreateUserAndAccount(String userName, String password,
            Boolean requireConfirmation, IDictionary<String, Object> values);

        /// <summary>
        /// Gets the hashed password for the specified username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        String GetHashedPasswordForUser(String username);

        /// <summary>
        /// When overridden in a derived class, returns the date and time when an incorrect password was most recently entered for the specified user account.
        /// </summary>
        /// <param name="userName">The user name of the account.</param>
        /// <returns>
        /// The date and time when an incorrect password was most recently entered for this user account, or <see cref="F:System.DateTime.MinValue" /> if an incorrect password has not been entered for this user account.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        DateTime GetLastPasswordFailureDate(String userName);

        /// <summary>
        /// When overridden in a derived class, returns the date and time when the password was most recently changed for the specified membership account.
        /// </summary>
        /// <param name="userName">The user name of the account.</param>
        /// <returns>
        /// The date and time when the password was more recently changed for membership account, or <see cref="F:System.DateTime.MinValue" /> if the password has never been changed for this user account.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        DateTime GetPasswordChangedDate(String userName);

        /// <summary>
        /// When overridden in a derived class, returns the number of times that the password for the specified user account was incorrectly entered since the most recent successful login or since the user account was created.
        /// </summary>
        /// <param name="userName">The user name of the account.</param>
        /// <returns>
        /// The count of failed password attempts for the specified user account.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        Int32 GetPasswordFailuresSinceLastSuccess(String userName);

        /// <summary>
        /// Gets the password strength regular expression
        /// </summary>
        String GetPasswordStrengthRegularExpression();

        /// <summary>
        /// Gets the user for the specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="userIsOnline">if set to <c>true</c> [user is online].</param>
        /// <returns></returns>
        WebMembershipUser GetUser(String providername, String username, Boolean userIsOnline);

        WebMembershipUser GetUser(String providername, object providerUserKey, Boolean userIsOnline);

        /// <summary>
        /// Returns a value that indicates whether the user account has been confirmed by the provider.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>
        /// true if the user is confirmed; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        Boolean IsConfirmed(String userName);

        ///// <summary>
        ///// Verifies that the specified user name and password exist in the data source.
        ///// </summary>
        ///// <param name="username">The name of the user to validate.</param>
        ///// <param name="password">The password for the specified user.</param>
        ///// <returns>
        ///// true if the specified username and password are valid; otherwise, false.
        ///// </returns>
        ///// <exception cref="System.InvalidOperationException"></exception>
        ///// <exception cref="System.NotImplementedException"></exception>
        //Boolean ValidateUser(String username, String password);

        /// <summary>
        /// Updates the state of the password success.
        /// </summary>
        /// <param name="username">The username.</param>
        void UpdatePasswordSuccessState(String username);

        /// <summary>
        /// Updates the state of the password failure.
        /// </summary>
        /// <param name="username">The username.</param>
        void UpdatePasswordFailureState(String username);
    }
}