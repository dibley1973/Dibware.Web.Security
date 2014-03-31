using System.Collections.Generic;
using System.Web.Security;
using Dibware.Web.Security.Providers;
using Dibware.Web.Security.Providers.Contracts;
using Dibware.Web.Security.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

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
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_CreateUserAndAccountUsingNameWithNullRepository_ThrowsNotImplementedException()
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