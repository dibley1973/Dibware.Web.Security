using Dibware.Web.Security.Principal;
using Dibware.Web.Security.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Security.Principal;

namespace Dibware.Web.Security.Tests.Principal
{
    /// <summary>
    /// Tests for Dibware.Web.Security.Principal.WebIdentity
    /// </summary>
    [TestClass]
    public class WebIdentityTest
    {
        #region Declarations

        //private 

        #endregion

        #region Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_WebIdentityConstructedWithNullIdentity_ThrowsArgumentNullException()
        {
            // Arrange

            // Act
            var webIdentity = new WebIdentity(null, null);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_WebIdentityConstructedWithNullRoles_ThrowsArgumentNullException()
        {
            // Arrange
            var identity = (IIdentity)WindowsIdentity.GetCurrent();

            // Act
            var webIdentity = new WebIdentity(identity, null);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_WebIdentityConstructedWithEmptyRoles_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var roles = new String[] { };
            var identity = (IIdentity)WindowsIdentity.GetCurrent();

            // Act
            var webIdentity = new WebIdentity(identity, roles);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        public void Test_WebIdentityConstructedWithOneRole_ResultsInIdentityHavingOneRole()
        {
            // Arrange
            const Int32 expectedRoleCount = 1;
            var roles = new[] { RoleData.RoleName1 };
            var identity = (IIdentity)WindowsIdentity.GetCurrent();

            // Act
            var webIdentity = new WebIdentity(identity, roles);

            // Assert
            Assert.AreEqual(expectedRoleCount, webIdentity.Roles.Count());
            Assert.AreEqual(RoleData.RoleName1, webIdentity.Roles[0]);
        }

        [TestMethod]
        public void Test_WebIdentityConstructedWithThreeRoles_ResultsInIdentityHavingThreeRoles()
        {
            // Arrange
            const Int32 expectedRoleCount = 3;
            var roles = new[] { RoleData.RoleName1, RoleData.RoleName2, RoleData.RoleName3 };
            var identity = (IIdentity)WindowsIdentity.GetCurrent();

            // Act
            var webIdentity = new WebIdentity(identity, roles);

            // Assert
            Assert.AreEqual(expectedRoleCount, webIdentity.Roles.Count());
            Assert.AreEqual(RoleData.RoleName1, webIdentity.Roles[0]);
            Assert.AreEqual(RoleData.RoleName2, webIdentity.Roles[1]);
            Assert.AreEqual(RoleData.RoleName3, webIdentity.Roles[2]);
        }

        #endregion
    }
}