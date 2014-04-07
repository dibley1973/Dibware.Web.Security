using Dibware.Web.Security.Providers;
using Dibware.Web.Security.Providers.Contracts;
using Dibware.Web.Security.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Security;

namespace Dibware.Web.Security.Tests.Providers
{
    [TestClass]
    public class RepositoryMembershipProviderTests
    {
        #region Declarations

        private Mock<IRepositoryMembershipProviderRepository> _membershipProviderRepository;

        #endregion

        #region Test Initialise

        [TestInitialize]
        public void TestInit()
        {
            // Mock role repository
            _membershipProviderRepository = new Mock<IRepositoryMembershipProviderRepository>();

            // CreateUserAndAccount
            _membershipProviderRepository
                .Setup(r => r.CreateUserAndAccount(
                    UserData.UserDave.Username,
                    UserData.UserDave.Password,
                    true,
                    new Dictionary<String, Object>()))
                .Returns(MembershipProviderData.Token);

            // ValidateUser
            _membershipProviderRepository
                .Setup(r => r.ValidateUser(UserData.InvalidUser.Username, UserData.InvalidUser.Password))
                .Returns(false);

            _membershipProviderRepository
                .Setup(r => r.ValidateUser(UserData.UserDave.Username, UserData.UserDave.Password))
                .Returns(true);
        }

        #endregion

        #region ConfirmAccount

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_ConfirmAccountWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String accountConfirmationToken = UserData.UserDave.AccountConfirmationToken;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.ConfirmAccount(accountConfirmationToken);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_ConfirmAccountUsingNameWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String accountConfirmationToken = UserData.UserDave.AccountConfirmationToken;
            const String username = UserData.UserDave.Username;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.ConfirmAccount(username, accountConfirmationToken);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region CreateAccount

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_CreateAccountUsingNameWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String password = UserData.UserDave.Password;
            const String username = UserData.UserDave.Username;
            const Boolean requireConfirmationToken = true;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.CreateAccount(username, password, requireConfirmationToken);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region CreateUserAndAccount

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_CreateUserAndAccountUsingNameWithNullRepository_ThrowsInvalidOperationException()
        {
            // Arrange
            const String password = UserData.UserDave.Password;
            const String username = UserData.UserDave.Username;
            const Boolean requireConfirmationToken = true;
            IDictionary<string, object> values = new Dictionary<string, object>();
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.CreateUserAndAccount(username, password, requireConfirmationToken, values);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        public void Test_CreateUserAndAccountUsingNameWithValidRepository_ReturnsToken()
        {
            // Arrange
            const String password = UserData.UserDave.Password;
            const String username = UserData.UserDave.Username;
            const Boolean requireConfirmationToken = true;
            IDictionary<string, object> values = new Dictionary<string, object>();
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = _membershipProviderRepository.Object
            };

            // Act
            var result = provider.CreateUserAndAccount(username, password, requireConfirmationToken, values);

            // Assert
            Assert.AreEqual(MembershipProviderData.Token, result);
        }

        #endregion

        #region DeleteAccount

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_DeleteAccountWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.DeleteAccount(username);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region GeneratePasswordResetToken

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_GeneratePasswordResetTokenUsingNameWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            const int tokenExpirationInMinutesFromNow = 10;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.GeneratePasswordResetToken(username, tokenExpirationInMinutesFromNow);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region GetAccountsForUser

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_GetAccountsForUserWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.GetAccountsForUser(username);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region GetCreateDate

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_GetCreateDateWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.GetCreateDate(username);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region GetLastPasswordFailureDate

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_GetLastPasswordFailureDateWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.GetLastPasswordFailureDate(username);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region GetPasswordChangedDate

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_GetPasswordChangedDateWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.GetPasswordChangedDate(username);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region GetPasswordFailuresSinceLastSuccess

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_GetPasswordFailuresSinceLastSuccesseWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.GetPasswordFailuresSinceLastSuccess(username);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region GetUserIdFromPasswordResetToken

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_GetUserIdFromPasswordResetTokenWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String token = UserData.UserDave.Token;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.GetUserIdFromPasswordResetToken(token);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region IsConfirmed

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_IsConfirmedWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.IsConfirmed(username);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region ResetPasswordWithToken

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_ResetPasswordWithTokenWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String token = UserData.UserDave.Token;
            const String newPassword = "NEW Pa55word";
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.ResetPasswordWithToken(token, newPassword);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region ApplicationName

        [TestMethod]
        public void Test_SettingAndGettingApplicationName_ReturnsCorrectName()
        {
            // Arrange
            const String expectedAplicationName = "This App";
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            provider.ApplicationName = expectedAplicationName;
            var result = provider.ApplicationName;

            // Assert
            Assert.AreEqual(expectedAplicationName, result);
        }

        #endregion

        #region ChangePassword

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_ChangePasswordWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            const String oldPassword = UserData.UserDave.Password;
            const String newPassword = "NEW Pa55word";
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.ChangePassword(username, oldPassword, newPassword);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region ChangePasswordQuestionAndAnswer

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_ChangePasswordQuestionAndAnswerWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            const String password = UserData.UserDave.Password;
            const String newPasswordQuestion = UserData.UserDave.PasswordQuestion;
            const String newPasswordAnswer = UserData.UserDave.PasswordAnswer;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.ChangePasswordQuestionAndAnswer(username,
                password, newPasswordQuestion, newPasswordAnswer);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region CreateUser

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_CreateUserWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            const String password = UserData.UserDave.Password;
            const String email = UserData.UserDave.Email;
            const String passwordQuestion = UserData.UserDave.PasswordQuestion;
            const String passwordAnswer = UserData.UserDave.PasswordAnswer;
            const Boolean isApproved = true;
            object providerUserKey = null;
            MembershipCreateStatus status;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.CreateUser(username, password, email, passwordQuestion,
                passwordAnswer, isApproved, providerUserKey, out status);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region DeleteUser

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_DeleteUserWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            const Boolean deleteAllRelatedData = false;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.DeleteUser(username, deleteAllRelatedData);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region EnablePasswordReset

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_EnablePasswordResetWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.EnablePasswordReset;

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region EnablePasswordRetrieval

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_EnablePasswordRetrievalWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.EnablePasswordRetrieval;

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region FindUsersByEmail

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_FindUsersByEmailWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String emailToMatch = UserData.UserDave.Email;
            const int pageIndex = 1;
            const int pageSize = 10;
            int totalRecords;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.FindUsersByEmail(emailToMatch,
                pageIndex, pageSize, out totalRecords);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region FindUsersByName

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_FindUsersByNameWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String usernameToMatch = UserData.UserDave.Username;
            const int pageIndex = 1;
            const int pageSize = 10;
            int totalRecords;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.FindUsersByName(usernameToMatch,
                pageIndex, pageSize, out totalRecords);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region GetAllUsers

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_GetAllUsersWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            int pageIndex = 1;
            int pageSize = 10;
            int totalRecords;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.GetAllUsers(pageIndex, pageSize, out totalRecords);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region GetNumberOfUsersOnline

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_GetNumberOfUsersOnlineWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.GetNumberOfUsersOnline();

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region GetPassword

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_GetPasswordWithNullRepository_ThrowsInvalidOperationException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            const String answer = UserData.UserDave.Answer;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.GetPassword(username, answer);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_GetPasswordWithValidRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            const String answer = UserData.UserDave.Answer;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = _membershipProviderRepository.Object
            };

            // Act
            var result = provider.GetPassword(username, answer);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region GetUser

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_GetUserUsingUsernameWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.GetUser(username, true);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_GetUserUsingProviderUserKeyWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            object providerKey = null;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.GetUser(providerKey, true);

            // Assert
            // Exception should be thrown
        }


        #endregion

        #region GetUserNameByEmail

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_GetUserNameByEmailWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String email = UserData.UserDave.Email;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.GetUserNameByEmail(email);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region MaxInvalidPasswordAttempts

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_MaxInvalidPasswordAttemptsWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.MaxInvalidPasswordAttempts;

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region MinRequiredNonAlphanumericCharacters

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_MinRequiredNonAlphanumericCharactersWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.MinRequiredNonAlphanumericCharacters;

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region MinRequiredPasswordLength

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_MinRequiredPasswordLengthWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.MinRequiredPasswordLength;

            // Assert
            // Exception should be thrown
        }


        #endregion

        #region PasswordAttemptWindow

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_PasswordAttemptWindowWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.PasswordAttemptWindow;

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region PasswordFormat

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_PasswordFormatWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.PasswordFormat;

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region PasswordStrengthRegularExpression

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_PasswordStrengthRegularExpressionWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.PasswordStrengthRegularExpression;

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region RequiresQuestionAndAnswer

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_RequiresQuestionAndAnswerWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.RequiresQuestionAndAnswer;

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region RequiresUniqueEmail

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_RequiresUniqueEmailWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.RequiresUniqueEmail;

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region ResetPassword

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_ResetPasswordWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            const String answer = UserData.UserDave.Answer;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            provider.ResetPassword(username, answer);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region UnlockUser

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_UnlockUserWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            provider.UnlockUser(username);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region UpdateUser

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_UpdateUserWithNullRepository_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            provider.UpdateUser(null);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region ValidateUser

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_ValidateUserWithNullRepository_ThrowsInvalidOperationException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            const String password = UserData.UserDave.Password;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            provider.ValidateUser(username, password);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        public void Test_ValidateUserWithValidCredentials_ReturnsTrue()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            const String password = UserData.UserDave.Password;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = _membershipProviderRepository.Object
            };

            // Act
            var result = provider.ValidateUser(username, password);

            // Assert
            Assert.IsTrue(result);
            // Exception should be thrown
        }

        [TestMethod]
        public void Test_ValidateUserWithInvalidCredentials_ReturnsFalse()
        {
            // Arrange
            const String username = UserData.InvalidUser.Username;
            const String password = UserData.InvalidUser.Password;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = _membershipProviderRepository.Object
            };

            // Act
            var result = provider.ValidateUser(username, password);

            // Assert
            Assert.IsFalse(result);
            // Exception should be thrown
        }

        #endregion
    }
}