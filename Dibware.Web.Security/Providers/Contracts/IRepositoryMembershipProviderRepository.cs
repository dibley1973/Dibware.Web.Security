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
        /// Gets the password strength regular expression
        /// </summary>
        String GetPasswordStrengthRegularExpression();

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
    }
}