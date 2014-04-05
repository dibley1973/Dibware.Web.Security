using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using WebMatrix.WebData;

namespace Dibware.Web.Security.Providers.Contracts
{
    public interface IRepositoryMembershipProvider
    {
        #region Properties

        IRepositoryMembershipProviderRepository MembershipProviderRepository { get; set; }

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
        /// When overridden in a derived class, creates a new user account using the specified user name and password, optionally requiring that the new account must be confirmed before the account is available for use.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        /// <param name="requireConfirmationToken">(Optional) true to specify that the account must be confirmed; otherwise, false. The default is false.</param>
        /// <returns>
        /// A token that can be sent to the user to confirm the account.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        String CreateAccount(String userName, String password, Boolean requireConfirmationToken);

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
        String CreateUserAndAccount(String userName, String password, Boolean requireConfirmation, IDictionary<String, object> values);

        /// <summary>
        /// When overridden in a derived class, deletes the specified membership account.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>
        /// true if the user account was deleted; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        Boolean DeleteAccount(String userName);

        /// <summary>
        /// When overridden in a derived class, generates a password reset token that can be sent to a user in email.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="tokenExpirationInMinutesFromNow">(Optional) The time, in minutes, until the password reset token expires. The default is 1440 (24 hours).</param>
        /// <returns>
        /// A token to send to the user.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        String GeneratePasswordResetToken(String userName, int tokenExpirationInMinutesFromNow);

        /// <summary>
        /// When overridden in a derived class, returns all OAuth membership accounts associated with the specified user name.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>
        /// A list of all OAuth membership accounts associated with the specified user name.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        ICollection<OAuthAccountData> GetAccountsForUser(String userName);

        /// <summary>
        /// When overridden in a derived class, returns the date and time when the specified user account was created.
        /// </summary>
        /// <param name="userName">The user name of the account.</param>
        /// <returns>
        /// The date and time the account was created, or <see cref="F:System.DateTime.MinValue" /> if the account creation date is not available.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        DateTime GetCreateDate(String userName);

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
        int GetPasswordFailuresSinceLastSuccess(String userName);

        /// <summary>
        /// When overridden in a derived class, returns an ID for a user based on a password reset token.
        /// </summary>
        /// <param name="token">The password reset token.</param>
        /// <returns>
        /// The user ID.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        int GetUserIdFromPasswordResetToken(String token);

        /// <summary>
        /// When overridden in a derived class, returns a value that indicates whether the user account has been confirmed by the provider.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>
        /// true if the user is confirmed; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        Boolean IsConfirmed(String userName);

        /// <summary>
        /// When overridden in a derived class, resets a password after verifying that the specified password reset token is valid.
        /// </summary>
        /// <param name="token">A password reset token.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>
        /// true if the password was changed; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        Boolean ResetPasswordWithToken(String token, String newPassword);

        /// <summary>
        /// The name of the application using the custom membership provider.
        /// </summary>
        /// <returns>The name of the application using the custom membership provider.</returns>
        String ApplicationName { get; set; }

        Boolean ChangePassword(String username, String oldPassword, String newPassword);

        Boolean ChangePasswordQuestionAndAnswer(String username, String password, String newPasswordQuestion, String newPasswordAnswer);

        MembershipUser CreateUser(String username, String password, String email, String passwordQuestion, String passwordAnswer, Boolean isApproved, object providerUserKey, out MembershipCreateStatus status);

        Boolean DeleteUser(String username, Boolean deleteAllRelatedData);

        Boolean EnablePasswordReset { get; }

        Boolean EnablePasswordRetrieval { get; }

        MembershipUserCollection FindUsersByEmail(String emailToMatch, int pageIndex, int pageSize, out int totalRecords);

        MembershipUserCollection FindUsersByName(String usernameToMatch, int pageIndex, int pageSize, out int totalRecords);

        MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords);

        int GetNumberOfUsersOnline();

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
        String GetPassword(String username, String answer);

        MembershipUser GetUser(String username, Boolean userIsOnline);

        MembershipUser GetUser(object providerUserKey, Boolean userIsOnline);

        String GetUserNameByEmail(String email);

        int MaxInvalidPasswordAttempts { get; }

        int MinRequiredNonAlphanumericCharacters { get; }

        int MinRequiredPasswordLength { get; }

        int PasswordAttemptWindow { get; }

        MembershipPasswordFormat PasswordFormat { get; }

        String PasswordStrengthRegularExpression { get; }

        Boolean RequiresQuestionAndAnswer { get; }

        Boolean RequiresUniqueEmail { get; }

        String ResetPassword(String username, String answer);

        Boolean UnlockUser(String userName);

        void UpdateUser(MembershipUser user);

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

        #endregion
    }
}
