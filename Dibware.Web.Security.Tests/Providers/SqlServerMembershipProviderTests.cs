using Dibware.Web.Security.Providers;
using Dibware.Web.Security.Providers.Contracts;
using Dibware.Web.Security.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Dibware.Web.Security.Tests.Providers
{
    [TestClass]
    public class SqlServerMembershipProviderTests
    {
        #region Declarations

        private Mock<ISqlServerMembershipProvider> _membershipProviderRepository;

        #endregion

        #region Test Initialise

        [TestInitialize]
        public void TestInit()
        {
            // Mock role repository
            _membershipProviderRepository = new Mock<ISqlServerMembershipProvider>();



            _membershipProviderRepository
                .Setup(r => r.ValidateUser(UserData.InvalidUser.Username, UserData.InvalidUser.Password))
                .Returns(false);

            _membershipProviderRepository
                .Setup(r => r.ValidateUser(UserData.UserDave.Username, UserData.UserDave.Password))
                .Returns(true);
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
            var provider = new SqlServerMembershipProvider
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
            var provider = new SqlServerMembershipProvider
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
            var provider = new SqlServerMembershipProvider
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