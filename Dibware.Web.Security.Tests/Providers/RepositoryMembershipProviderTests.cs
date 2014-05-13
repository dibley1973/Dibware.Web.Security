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

        private Mock<IRepositoryMembershipProviderPasswordService> _membershipProviderPasswordService;
        private Mock<IRepositoryMembershipProviderRepository> _membershipProviderRepository;

        #endregion

        #region Test Initialise

        [TestInitialize]
        public void TestInit()
        {
            // Mock the encryptor
            _membershipProviderPasswordService = new Mock<IRepositoryMembershipProviderPasswordService>();

            // .ValidatePassword
            _membershipProviderPasswordService
                .Setup(e => e.ValidatePassword(
                    UserData.UserDave.Password,
                    UserData.UserDave.HashedPassword))
                .Returns(true);

            // CreateConfirmationToken
            _membershipProviderPasswordService
                .Setup(e => e.CreateConfirmationToken())
                .Returns(MembershipProviderData.Token);

            // Mock role repository
            _membershipProviderRepository = new Mock<IRepositoryMembershipProviderRepository>();

            // ConfirmAccount
            _membershipProviderRepository
                .Setup(e => e.ConfirmAccount(
                    UserData.UserDave.Username,
                    UserData.UserDave.AccountConfirmationToken))
                .Returns(true);
            _membershipProviderRepository
                .Setup(e => e.ConfirmAccount(
                    UserData.InvalidUser.Username,
                    UserData.InvalidUser.AccountConfirmationToken))
                .Returns(false);

            // .CreateUserAndAccount
            _membershipProviderRepository
                .Setup(r => r.CreateUserAndAccount(
                    UserData.UserDave.Username,
                    UserData.UserDave.Password,
                    true,
                    new Dictionary<String, Object>()))
                .Returns(MembershipProviderData.Token);

            // .GetHashedPasswordForUser
            _membershipProviderRepository
                .Setup(r => r.GetHashedPasswordForUser(
                    UserData.UserDave.Username))
                .Returns(UserData.UserDave.HashedPassword);

            // GetPasswordChangedDate
            _membershipProviderRepository
                .Setup(r => r.GetPasswordChangedDate(
                    UserData.UserJane.Username))
                .Returns(UserData.UserJane.PasswordChangedDate);

            // GetPasswordFailuresSinceLastSuccess
            _membershipProviderRepository
                .Setup(r => r.GetPasswordFailuresSinceLastSuccess(
                    UserData.UserJane.Username))
                .Returns(UserData.UserJane.PasswordFailuresSinceLastSuccess);

            // GetLastPasswordFailureDate
            _membershipProviderRepository
                .Setup(r => r.GetLastPasswordFailureDate(
                    UserData.UserJane.Username))
                .Returns(UserData.UserJane.LastPasswordFailureDate);

            // .IsConfirmed
            _membershipProviderRepository
                .Setup(r => r.IsConfirmed(UserData.UserDave.Username))
                .Returns(true);

            // .IsConfirmed
            _membershipProviderRepository
                .Setup(r => r.IsConfirmed(UserData.InvalidUser.Username))
                .Returns(false);

            // .ValidateUser
            //_membershipProviderRepository
            //    .Setup(r => r.ValidateUser(UserData.InvalidUser.Username, UserData.InvalidUser.Password))
            //    .Returns(false);

            //_membershipProviderRepository
            //    .Setup(r => r.ValidateUser(UserData.UserDave.Username, UserData.UserDave.HashedPassword))
            //    .Returns(true);
        }

        #endregion

        #region ConfirmAccount

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_ConfirmAccountWithNullRepositoryAndJustToken_ThrowsInvalidOperationException()
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_ConfirmAccountUsingNameWithNullRepositoryAndNameAndToken_ThrowsInvalidOperationException()
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

        [TestMethod]
        public void Test_ConfirmAccountUsingNameWithValidRepositoryAndValidNameAndToken_ReturnsTrue()
        {
            // Arrange
            const String accountConfirmationToken = UserData.UserDave.AccountConfirmationToken;
            const String username = UserData.UserDave.Username;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = _membershipProviderRepository.Object
            };

            // Act
            var result = provider.ConfirmAccount(username, accountConfirmationToken);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_ConfirmAccountUsingNameWithValidRepositoryAndInvalidNameAndToken_ReturnsFalse()
        {
            // Arrange
            const String accountConfirmationToken = UserData.InvalidUser.AccountConfirmationToken;
            const String username = UserData.InvalidUser.Username;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = _membershipProviderRepository.Object
            };

            // Act
            var result = provider.ConfirmAccount(username, accountConfirmationToken);

            // Assert
            Assert.IsFalse(result);
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_CreateUserAndAccountUsingNameWithNullRepositoryAndPasswordService_ThrowsInvalidOperationException()
        {
            // Arrange
            const String password = UserData.UserDave.Password;
            const String username = UserData.UserDave.Username;
            const Boolean requireConfirmationToken = true;
            IDictionary<string, object> values = new Dictionary<string, object>();
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null,
                RepositoryMembershipProviderPasswordService = null
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
            IDictionary<String, Object> values = new Dictionary<String, Object>();
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = _membershipProviderRepository.Object,
                RepositoryMembershipProviderPasswordService = _membershipProviderPasswordService.Object
            };

            // Act
            var token = provider.CreateUserAndAccount(username, password, requireConfirmationToken, values);

            // Assert
            Assert.AreEqual(MembershipProviderData.Token, token);
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

        #region EnablePasswordReset

        [TestMethod]
        public void Test_EnablePasswordReset_ReturnsTrue()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.EnablePasswordReset;

            // Assert
            Assert.IsTrue(result);
        }

        #endregion

        #region EnablePasswordRetrieval

        [TestMethod]
        public void Test_EnablePasswordRetrieval_ReturnsTrue()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.EnablePasswordRetrieval;

            // Assert
            Assert.IsFalse(result);
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_GetLastPasswordFailureDateWithNullRepository_ThrowsInvalidOperationException()
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

        [TestMethod]
        public void Test_GetLastPasswordFailureDateWithValidRepository_ReturnsCorrectDate()
        {
            // Arrange
            const String username = UserData.UserJane.Username;
            var expectedResult = UserData.UserJane.LastPasswordFailureDate;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = _membershipProviderRepository.Object
            };

            // Act
            var result = provider.GetLastPasswordFailureDate(username);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        #endregion

        #region GetPasswordChangedDate

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_GetPasswordChangedDateWithNullRepository_ThrowsInvalidOperationException()
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

        [TestMethod]
        public void Test_GetPasswordChangedDateWithValidRepository_ReturnsCorrectDate()
        {
            // Arrange
            const String username = UserData.UserJane.Username;
            var expectedResult = UserData.UserJane.PasswordChangedDate;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = _membershipProviderRepository.Object
            };

            // Act
            var result = provider.GetPasswordChangedDate(username);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        #endregion

        #region GetPasswordFailuresSinceLastSuccess

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_GetPasswordFailuresSinceLastSuccesseWithNullRepository_ThrowsInvalidOperationException()
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

        [TestMethod]
        public void Test_GetPasswordFailuresSinceLastSuccesseWithValidRepository_ReturnsCorrectAccount()
        {
            // Arrange
            const String username = UserData.UserJane.Username;
            const Int32 expectedResult = UserData.UserJane.PasswordFailuresSinceLastSuccess;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = _membershipProviderRepository.Object
            };

            // Act
            var result = provider.GetPasswordFailuresSinceLastSuccess(username);

            // Assert
            Assert.AreEqual(expectedResult, result);
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_IsConfirmedWithNullRepository_ThrowsInvalidOperationException()
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

        [TestMethod]
        public void Test_IsConfirmedWithValidRepository_ReturnsTrueForValidUser()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = _membershipProviderRepository.Object
            };

            // Act
            var result = provider.IsConfirmed(username);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_IsConfirmedWithValidRepository_ReturnsFalseForInvalidUser()
        {
            // Arrange
            const String username = UserData.InvalidUser.Username;
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = _membershipProviderRepository.Object
            };

            // Act
            var result = provider.IsConfirmed(username);

            // Assert
            Assert.IsFalse(result);
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
        public void Test_EnablePasswordResetWithValidRepository_ReturnsFalse()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = _membershipProviderRepository.Object
            };

            // Act
            var result = provider.EnablePasswordReset;

            // Assert
            Assert.IsTrue(result);
        }

        #endregion

        #region EnablePasswordRetrieval

        [TestMethod]
        public void Test_EnablePasswordRetrievalWithValidRepository_ReturnsFalse()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null
            };

            // Act
            var result = provider.EnablePasswordRetrieval;

            // Assert
            Assert.IsFalse(result);
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_GetUserUsingUsernameWithNullRepository_ThrowsInvalidOperationException()
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
        public void Test_GetUserUsingUsernameWithNullUsername_ReturnsNull()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = _membershipProviderRepository.Object
            };

            // Act
            var result = provider.GetUser(null, true);

            // Assert
            Assert.IsNull(result);
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_MinRequiredNonAlphanumericCharactersWithNullRepository_ThrowsInvalidOperationException()
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_MinRequiredPasswordLengthWithNullPasswordService_ThrowsInvalidOperationException()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null,
                RepositoryMembershipProviderPasswordService = null
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_PasswordStrengthRegularExpressionWithNullPasswordService_ThrowsInvalidOperationException()
        {
            // Arrange
            var provider = new RepositoryMembershipProvider
            {
                MembershipProviderRepository = null,
                RepositoryMembershipProviderPasswordService = null
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_ValidateUserWithNullEncrypytor_ThrowsInvalidOperationException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            const String password = UserData.UserDave.Password;
            var provider = new RepositoryMembershipProvider
            {
                RepositoryMembershipProviderPasswordService = null,
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
                RepositoryMembershipProviderPasswordService = _membershipProviderPasswordService.Object,
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
                RepositoryMembershipProviderPasswordService = _membershipProviderPasswordService.Object,
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