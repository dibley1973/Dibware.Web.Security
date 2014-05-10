using Dibware.Web.Security.Providers.Contracts;
using Dibware.Web.Security.Resources;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Security;
using WebMatrix.WebData;

namespace Dibware.Web.Security.Providers
{
    /// <summary>
    /// Represents a MembershipProvider that uses a repository as a data store
    /// </summary>
    public class RepositoryMembershipProvider : ExtendedMembershipProvider, IRepositoryMembershipProvider
    {
        #region Properties

        /// <summary>
        /// Gets or sets the encryptor for the Pprovider
        /// </summary>
        [Inject]
        public IRepositoryMembershipProviderPasswordService RepositoryMembershipProviderPasswordService { get; set; }

        /// <summary>
        /// Gets or sets the repository for the provider
        /// </summary>
        [Inject]
        public IRepositoryMembershipProviderRepository MembershipProviderRepository { get; set; }

        #endregion

        #region ExtendedMembershipProvider

        /// <summary>
        /// Activates a pending membership account.
        /// </summary>
        /// <param name="accountConfirmationToken">A confirmation token to pass to the authentication provider.</param>
        /// <returns>
        /// true if the account is confirmed; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool ConfirmAccount(String accountConfirmationToken)
        {
            // Validate arguments
            if (MembershipProviderRepository == null)
            {
                throw new InvalidOperationException(ExceptionMessages.MembershipProviderRepositoryIsNull);
            }
            return MembershipProviderRepository.ConfirmAccount(accountConfirmationToken);
        }

        /// <summary>
        /// Activates a pending membership account for the specified user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="accountConfirmationToken">A confirmation token to pass to the authentication provider.</param>
        /// <returns>
        /// true if the account is confirmed; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool ConfirmAccount(String userName, String accountConfirmationToken)
        {
            // Validate arguments
            if (MembershipProviderRepository == null)
            {
                throw new InvalidOperationException(ExceptionMessages.MembershipProviderRepositoryIsNull);
            }
            return MembershipProviderRepository.ConfirmAccount(userName, accountConfirmationToken);
        }

        /// <summary>
        /// When overridden in a derived class, creates a new user account using the specified user name and password, optionally requiring that the new account must be confirmed before the account is available for use.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        /// <param name="requireConfirmationToken">(Optional) true to specify that the account must be confirmed; otherwise, false. The default is false.</param>
        /// <returns>
        /// A token that can be sent to the user to confirm the account.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override string CreateAccount(string userName, string password, bool requireConfirmationToken)
        {
            throw new NotImplementedException();
        }

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
        public override string CreateUserAndAccount(String userName, String password, Boolean requireConfirmation, IDictionary<String, Object> values)
        {
            // Validate arguments
            if (MembershipProviderRepository == null)
            {
                throw new InvalidOperationException(ExceptionMessages.MembershipProviderRepositoryIsNull);
            }
            if (RepositoryMembershipProviderPasswordService == null)
            {
                throw new InvalidOperationException(ExceptionMessages.MembershipProviderPasswordServiceIsNull);
            }

            // Ensure the values dictionary is instanciated
            if (values == null)
            {
                values = new Dictionary<String, Object>();
            }

            // If we require a confirmation email then get the token and add it 
            // to the values dictionary
            if (requireConfirmation)
            {
                var emailConfirmationToken = RepositoryMembershipProviderPasswordService.CreateConfirmationToken();
                values.Add(DictionaryKeys.ConfirmationToken, emailConfirmationToken);
            }
            // Get the hashed value for the password
            var hashedPassword = RepositoryMembershipProviderPasswordService.CreateHash(password);

            return MembershipProviderRepository.CreateUserAndAccount(userName, hashedPassword, requireConfirmation, values);
        }

        /// <summary>
        /// When overridden in a derived class, deletes the specified membership account.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>
        /// true if the user account was deleted; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool DeleteAccount(string userName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// When overridden in a derived class, generates a password reset token that can be sent to a user in email.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="tokenExpirationInMinutesFromNow">(Optional) The time, in minutes, until the password reset token expires. The default is 1440 (24 hours).</param>
        /// <returns>
        /// A token to send to the user.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override string GeneratePasswordResetToken(string userName, int tokenExpirationInMinutesFromNow)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// When overridden in a derived class, returns all OAuth membership accounts associated with the specified user name.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>
        /// A list of all OAuth membership accounts associated with the specified user name.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override ICollection<OAuthAccountData> GetAccountsForUser(string userName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// When overridden in a derived class, returns the date and time when the specified user account was created.
        /// </summary>
        /// <param name="userName">The user name of the account.</param>
        /// <returns>
        /// The date and time the account was created, or <see cref="F:System.DateTime.MinValue" /> if the account creation date is not available.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override DateTime GetCreateDate(string userName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// When overridden in a derived class, returns the date and time when an incorrect password was most recently entered for the specified user account.
        /// </summary>
        /// <param name="userName">The user name of the account.</param>
        /// <returns>
        /// The date and time when an incorrect password was most recently entered for this user account, or <see cref="F:System.DateTime.MinValue" /> if an incorrect password has not been entered for this user account.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override DateTime GetLastPasswordFailureDate(string userName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// When overridden in a derived class, returns the date and time when the password was most recently changed for the specified membership account.
        /// </summary>
        /// <param name="userName">The user name of the account.</param>
        /// <returns>
        /// The date and time when the password was more recently changed for membership account, or <see cref="F:System.DateTime.MinValue" /> if the password has never been changed for this user account.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override DateTime GetPasswordChangedDate(string userName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// When overridden in a derived class, returns the number of times that the password for the specified user account was incorrectly entered since the most recent successful login or since the user account was created.
        /// </summary>
        /// <param name="userName">The user name of the account.</param>
        /// <returns>
        /// The count of failed password attempts for the specified user account.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override int GetPasswordFailuresSinceLastSuccess(string userName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// When overridden in a derived class, returns an ID for a user based on a password reset token.
        /// </summary>
        /// <param name="token">The password reset token.</param>
        /// <returns>
        /// The user ID.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override int GetUserIdFromPasswordResetToken(string token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// When overridden in a derived class, returns a value that indicates whether the user account has been confirmed by the provider.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>
        /// true if the user is confirmed; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool IsConfirmed(String userName)
        {
            // Validate arguments
            if (MembershipProviderRepository == null)
            {
                throw new InvalidOperationException(ExceptionMessages.MembershipProviderRepositoryIsNull);
            }
            return MembershipProviderRepository.IsConfirmed(userName);
        }

        /// <summary>
        /// When overridden in a derived class, resets a password after verifying that the specified password reset token is valid.
        /// </summary>
        /// <param name="token">A password reset token.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>
        /// true if the password was changed; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool ResetPasswordWithToken(string token, string newPassword)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The name of the application using the custom membership provider.
        /// </summary>
        /// <returns>The name of the application using the custom membership provider.</returns>
        public override string ApplicationName { get; set; }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the password for the specified user name from the data source.
        /// </summary>
        /// <param name="username">The user to retrieve the password for.</param>
        /// <param name="answer">The password answer for the user.</param>
        /// <returns>
        /// The password for the specified user name.
        /// </returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.NotImplementedException"></exception>
        public override string GetPassword(String username, String answer)
        {
            // Validate arguments
            if (MembershipProviderRepository == null)
            {
                throw new InvalidOperationException(ExceptionMessages.MembershipProviderRepositoryIsNull);
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets information from the data source for a user. Provides an option to update the last-activity date/time stamp for the user.
        /// </summary>
        /// <param name="username">The name of the user to get information for.</param>
        /// <param name="userIsOnline">true to update the last-activity date/time stamp for the user; false to return user information without updating the last-activity date/time stamp for the user.</param>
        /// <returns>
        /// A <see cref="T:System.Web.Security.MembershipUser" /> object populated with the specified user's information from the data source.
        /// </returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.NotImplementedException"></exception>
        public override MembershipUser GetUser(String username, Boolean userIsOnline)
        {
            // Validate arguments
            if (MembershipProviderRepository == null)
            {
                throw new InvalidOperationException(ExceptionMessages.MembershipProviderRepositoryIsNull);
            }

            if (string.IsNullOrEmpty(username))
            {
                // No user signed in
                return null;
            }

            var user = MembershipProviderRepository.GetUser(username, userIsOnline);
            return user;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets the minimum required non alphanumeric characters 
        /// from the RepositoryMembershipProviderPasswordService
        /// </summary>
        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                if (RepositoryMembershipProviderPasswordService == null)
                {
                    throw new InvalidOperationException(ExceptionMessages.MembershipProviderPasswordServiceIsNull);
                }
                return RepositoryMembershipProviderPasswordService.MinRequiredNonAlphanumericCharacters;
            }
        }

        /// <summary>
        /// Gets or sets the minimum password length from the 
        /// RepositoryMembershipProviderPasswordService
        /// </summary>
        public override int MinRequiredPasswordLength
        {
            get
            {
                if (RepositoryMembershipProviderPasswordService == null)
                {
                    throw new InvalidOperationException(ExceptionMessages.MembershipProviderPasswordServiceIsNull);
                }
                return RepositoryMembershipProviderPasswordService.MinRequiredPasswordLength;
            }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the password strength regular expression
        /// </summary>
        public override string PasswordStrengthRegularExpression
        {
            get
            {
                if (RepositoryMembershipProviderPasswordService == null)
                {
                    throw new InvalidOperationException(ExceptionMessages.MembershipProviderPasswordServiceIsNull);
                }
                return RepositoryMembershipProviderPasswordService.PasswordStrengthRegularExpression;
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifies that the specified user name and password exist in the data source.
        /// </summary>
        /// <param name="username">The name of the user to validate.</param>
        /// <param name="password">The password for the specified user.</param>
        /// <returns>
        /// true if the specified username and password are valid; otherwise, false.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown if either MembershipProviderRepository or 
        /// RepositoryMembershipProviderEncryptor is null.
        /// </exception>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool ValidateUser(string username, string password)
        {
            // Validate Properties have been set
            if (MembershipProviderRepository == null)
            {
                throw new InvalidOperationException(ExceptionMessages.MembershipProviderRepositoryIsNull);
            }
            if (RepositoryMembershipProviderPasswordService == null)
            {
                throw new InvalidOperationException(ExceptionMessages.MembershipProviderPasswordServiceIsNull);
            }

            // Try and get the hashed password for the supplied username,
            // and set a flag to indicate it was found...
            var actualPasswordHash = MembershipProviderRepository.GetHashedPasswordForUser(username);
            Boolean isValid = String.IsNullOrEmpty(actualPasswordHash);

            // Are we still valid...
            if (isValid)
            {
                // ... we are, so check the hashed password against the
                // hash for the specified password.
                isValid = RepositoryMembershipProviderPasswordService
                    .ValidatePassword(password, actualPasswordHash);
            }

            // Are we still valid...
            if (isValid)
            {
                // ... we are, so update the SUCCESS state for the password
                MembershipProviderRepository.UpdatePasswordSuccessState(username);
            }
            else
            {
                // ... we are not, so update the FAILURE state for the password
                MembershipProviderRepository.UpdatePasswordFailureState(username);
            }

            // Finally return the valid state
            return isValid;
        }

        #endregion
    }
}