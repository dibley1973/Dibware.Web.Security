using Dibware.Web.Security.Providers;
using Dibware.Web.Security.Providers.Contracts;
using Dibware.Web.Security.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Dibware.Web.Security.Tests.Providers
{
    [TestClass]
    public class SqlServerRoleProviderTests
    {
        #region Declarations

        private List<String> _allRolesList;
        //private string[] _allRoles;
        private Mock<ISqlServerRoleProviderRepository> _roleProviderRepository;

        #endregion

        #region Test Initialise

        [TestInitialize]
        public void TestInit()
        {
            // Mock all roles array
            _allRolesList = new List<String> { RoleData.RoleName1, RoleData.RoleName2, RoleData.RoleName3 };
            //_allRoles = new[] { RoleData.RoleName1, RoleData.RoleName2, RoleData.RoleName3 };

            // Mock role repository
            _roleProviderRepository = new Mock<ISqlServerRoleProviderRepository>();

            _roleProviderRepository
                .Setup(r => r.FindUsersInRole(RoleData.RoleName1, UserData.UserName1))
                .Returns(new[] { UserData.UserName1 });

            _roleProviderRepository
                .Setup(r => r.GetAllRoles())
                .Returns(_allRolesList.ToArray);

            _roleProviderRepository
                .Setup(r => r.GetRolesForUser(It.IsAny<String>()))
                .Returns(_allRolesList.ToArray);

            _roleProviderRepository
                .Setup(r => r.RoleExists(RoleData.RoleName1))
                .Returns(true);

            _roleProviderRepository
                .Setup(r => r.RoleExists(RoleData.RoleName2))
                .Returns(true);

            //_roleProviderRepository
            //    .Setup(r => r.RoleExists(It.Is<String>(roleName)))
            //    .Returns(_allRolesList.Contains(roleName));
        }

        #endregion

        #region Tests

        #region AddUsersToRoles

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

        #endregion

        #region ApplicationName

        [TestMethod]
        public void Test_ApplicationName_SetValue_ReturnsSameValueForGet()
        {
            // Arrange
            const String expectedApplicationName = RoleProviderData.ApplicationName;
            var provider = new SqlServerRoleProvider
            {
                ApplicationName = expectedApplicationName
            };

            // Act
            var actualApplicationName = provider.ApplicationName;

            // Assert
            Assert.AreEqual(expectedApplicationName, actualApplicationName);
        }

        #endregion

        #region CreateRole

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_CreateRoleWithNullRepository_ThrowsInvalidOperationException()
        {
            // Arrange
            var provider = new SqlServerRoleProvider
            {
                RoleProviderRepository = null
            };

            // Act
            provider.CreateRole(RoleData.RoleName1);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_CreateRole_ThrowsNotImplementedException()
        {
            // Arrange
            var provider = new SqlServerRoleProvider
            {
                RoleProviderRepository = _roleProviderRepository.Object
            };

            // Act
            provider.CreateRole(RoleData.RoleName1);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region DeleteRole

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_DeleteRoleWithNullRepository_ThrowsInvalidOperationException()
        {
            // Arrange
            const bool throwOnPopulatedRole = true;
            var provider = new SqlServerRoleProvider
            {
                RoleProviderRepository = null
            };

            // Act
            provider.DeleteRole(RoleData.RoleName1, throwOnPopulatedRole);

            // Assert
            // Exception should be thrown
        }

        [Ignore]    // TODO: Needs work
        [TestMethod]
        public void Test_DeleteRoleNotPopulatedWithUsers_DeletesRole()
        {
            // Arrange
            const bool throwOnPopulatedRole = true;
            var provider = new SqlServerRoleProvider
            {
                RoleProviderRepository = _roleProviderRepository.Object
            };

            // Act
            provider.DeleteRole(RoleData.RoleName3, throwOnPopulatedRole);

            // Assert
            Assert.IsFalse(provider.RoleExists(RoleData.RoleName1));
        }

        [Ignore]    // TODO: Needs work
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_DeleteRolePopulatedWithUsersWithThrowOnPopulatedTrue_ThrowsInvalidOperationException()
        {
            // Arrange
            const bool throwOnPopulatedRole = true;
            var provider = new SqlServerRoleProvider
            {
                RoleProviderRepository = _roleProviderRepository.Object
            };

            // Act
            provider.DeleteRole(RoleData.RoleName1, throwOnPopulatedRole);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        public void Test_DeleteRolePopulatedWithUsersWithThrowOnPopulatedFalse_ThrowsInvalidOperationException()
        {
            // Arrange
            const bool throwOnPopulatedRole = false;
            var provider = new SqlServerRoleProvider
            {
                RoleProviderRepository = _roleProviderRepository.Object
            };

            // Act
            provider.DeleteRole(RoleData.RoleName1, throwOnPopulatedRole);

            // Assert
            // Exception should be thrown
        }

        #endregion

        #region FindUsersInRole

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_FindUsersInRoleWithNullRepository_ThrowsInvalidOperationException()
        {
            // Arrange
            var provider = new SqlServerRoleProvider
            {
                RoleProviderRepository = null
            };

            // Act
            provider.FindUsersInRole(RoleData.RoleName1, UserData.UserName1);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        public void Test_FindUsersInRole_FindsUserForValidUser()
        {
            // Arrange
            const Int32 expectedUserCount = 1;
            var provider = new SqlServerRoleProvider
            {
                RoleProviderRepository = _roleProviderRepository.Object
            };

            // Act
            var users = provider.FindUsersInRole(RoleData.RoleName1, UserData.UserName1);

            // Assert
            Assert.AreEqual(expectedUserCount, users.Length);
            CollectionAssert.Contains(users, UserData.UserName1);
        }

        [TestMethod]
        public void Test_FindUsersInRole_DoesNotFinduserForInvalidUser()
        {
            // Arrange
            const Int32 expectedUserCount = 1;
            var provider = new SqlServerRoleProvider
            {
                RoleProviderRepository = _roleProviderRepository.Object
            };

            // Act
            var users = provider.FindUsersInRole(RoleData.RoleName1, UserData.UserName1);

            // Assert
            Assert.AreEqual(expectedUserCount, users.Length);
            CollectionAssert.DoesNotContain(users, UserData.UserName2);
        }

        #endregion

        #region GetAllRoles

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_GetAllRolesWithNullRepository_ThrowsInvalidOperationException()
        {
            // Arrange
            var provider = new SqlServerRoleProvider
            {
                RoleProviderRepository = null
            };

            // Act
            provider.GetAllRoles();

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        public void Test_GetAllRoles_ReturnsTheCorrectCountOfRoles()
        {
            // Arrange
            const Int32 expectedRoleCount = RoleData.ExpectedRoleCount;
            var provider = new SqlServerRoleProvider
            {
                RoleProviderRepository = _roleProviderRepository.Object
            };

            // Act
            var roles = provider.GetAllRoles();

            // Assert
            Assert.AreEqual(expectedRoleCount, roles.Length);
            CollectionAssert.Contains(roles, RoleData.RoleName1);
            CollectionAssert.Contains(roles, RoleData.RoleName2);
            CollectionAssert.Contains(roles, RoleData.RoleName3);
        }

        #endregion

        #region GetRolesForUser

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
            var provider = new SqlServerRoleProvider
            {
                RoleProviderRepository = _roleProviderRepository.Object
            };

            // Act
            var roles = provider.GetRolesForUser(UserData.UserName1);

            // Assert
            Assert.AreEqual(expectedRoleCount, roles.Length);
            CollectionAssert.Contains(roles, RoleData.RoleName1);
            CollectionAssert.Contains(roles, RoleData.RoleName2);
        }

        #endregion

        #region GetUsersInRole

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

        #endregion

        #region IsUserInRole

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

        #endregion

        #region RemoveUsersFromRoles

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

        #endregion

        #region RoleExists

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_RoleExistsWithNullRepository_ThrowsInvalidOperationException()
        {
            // Arrange
            var provider = new SqlServerRoleProvider();

            // Act
            provider.RoleExists(RoleData.RoleName1);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        public void Test_RoleExists_ReturnsFalseForInvalidRole()
        {
            // Arrange
            var provider = new SqlServerRoleProvider
            {
                RoleProviderRepository = _roleProviderRepository.Object
            };

            // Act
            bool actualResult = provider.RoleExists("AppleEater");

            // Assert
            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void Test_RoleExists_ReturnsTrueForValidRole()
        {
            // Arrange
            var provider = new SqlServerRoleProvider
            {
                RoleProviderRepository = _roleProviderRepository.Object
            };

            // Act
            bool actualResult = provider.RoleExists(RoleData.RoleName1);

            // Assert
            Assert.IsTrue(actualResult);
        }

        #endregion

        #endregion
    }
}
