using Dibware.Web.Security.Providers;
using Dibware.Web.Security.Providers.Contracts;
using Dibware.Web.Security.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Dibware.Web.Security.Tests.Providers
{
    [TestClass]
    public class SqlServerRoleProviderTests
    {
        #region Declarations

        private string[] _allRoles;
        private Mock<ISqlServerRoleProviderRepository> _roleProviderRepository;

        #endregion

        #region Test Initialise

        [TestInitialize]
        public void TestInit()
        {
            // Mock all roles array
            _allRoles = new[] { RoleData.RoleName1, RoleData.RoleName2, RoleData.RoleName3 };

            // Mock role repository
            _roleProviderRepository = new Mock<ISqlServerRoleProviderRepository>();
            _roleProviderRepository
                .Setup(s => s.GetRolesForUser(It.IsAny<String>()))
                .Returns(_allRoles);
        }

        #endregion

        #region Tests

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_AddUsersToRoles_ThrowsNotImplementedException()
        {
            // Arrange
            var usernames = new[] { UserData.UserName1, UserData.UserName2 };
            var roleNames = new[] { RoleData.RoleName1, RoleData.RoleName2 };
            var provider = new SqlServerRoleProvider();

            // Act
            provider.AddUsersToRoles(usernames, roleNames);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        public void Test_ApplicationName_SetValue_ReturnsSameValueForGet()
        {
            // Arrange
            const String expectedApplicationName = RoleProviderData.ApplicationName;
            var provider = new SqlServerRoleProvider();

            // Act
            provider.ApplicationName = expectedApplicationName;
            var actualApplicationName = provider.ApplicationName;

            // Assert
            Assert.AreEqual(expectedApplicationName, actualApplicationName);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_CreateRole_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new SqlServerRoleProvider();

            // Act
            provider.CreateRole(RoleData.RoleName1);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_DeleteRole_ThrowsNotImplementedException()
        {
            // Arrange
            const bool throwOnPopulatedRole = true;
            var provider = new SqlServerRoleProvider();

            // Act
            provider.DeleteRole(RoleData.RoleName1, throwOnPopulatedRole);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void FindUsersInRole_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new SqlServerRoleProvider();

            // Act
            provider.FindUsersInRole(RoleData.RoleName1, UserData.UserName1);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_GetAllRoles_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new SqlServerRoleProvider();

            // Act
            provider.GetAllRoles();

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_GetRolesForUserWithNullRepository_ThrowsInvalidOperationException()
        {
            // Arrange
            var provider = new SqlServerRoleProvider();

            // Act
            provider.RoleProviderRepository = null;
            provider.GetRolesForUser(UserData.UserName1);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        public void Test_GetRolesForUser_ReturnsCorrectRoles()
        {
            // Arrange
            const Int32 expectedRoleCount = RoleData.ExpectedRoleCount;
            var provider = new SqlServerRoleProvider();

            // Act
            provider.RoleProviderRepository = _roleProviderRepository.Object;
            var roles = provider.GetRolesForUser(UserData.UserName1);

            // Assert
            Assert.AreEqual(expectedRoleCount, roles.Length);
            CollectionAssert.Contains(roles, RoleData.RoleName1);
            CollectionAssert.Contains(roles, RoleData.RoleName2);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_GetUsersInRole_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new SqlServerRoleProvider();

            // Act
            provider.GetUsersInRole(RoleData.RoleName1);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_IsUserInRole_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new SqlServerRoleProvider();

            // Act
            provider.IsUserInRole(UserData.UserName1, RoleData.RoleName1);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_RemoveUsersFromRoles_ThrowsNotImplementedException()
        {
            // Arrange

            var usernames = new[] { UserData.UserName1, UserData.UserName2 };
            var roleNames = new[] { RoleData.RoleName1, RoleData.RoleName2 };

            var provider = new SqlServerRoleProvider();

            // Act
            provider.RemoveUsersFromRoles(usernames, roleNames);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_RoleExists_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new SqlServerRoleProvider();

            // Act
            provider.RoleExists(RoleData.RoleName1);

            // Assert
            // Exception should be thrown
        }

        #endregion
    }
}
