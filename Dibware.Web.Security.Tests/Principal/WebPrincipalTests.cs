using Dibware.Web.Security.Principal;
using Dibware.Web.Security.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Principal;

namespace Dibware.Web.Security.Tests.Principal
{
    /// <summary>
    /// Tests for Dibware.Web.Security.Principal.WebPrincipal
    /// </summary>
    [TestClass]
    public class WebPrincipalTests
    {
        #region Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_WebPrincipalConstructedWithNullIdentity_ThrowsArgumentNullException()
        {
            // Arrange

            // Act
            var webPrinciple = new WebPrincipal(null);

            // Assert
            // Exception should be thrown
        }

        [TestMethod]
        public void Test_WebPrincipalConstructedWithWebIdentity_ReturnsSameReferenceInProperty()
        {
            // Arrange
            var roles = new[] { RoleData.RoleName1 };
            var identity = (IIdentity)WindowsIdentity.GetCurrent();
            var webIdentity = new WebIdentity(identity, roles);

            // Act
            var webPrinciple = new WebPrincipal(webIdentity);

            // Assert
            Assert.AreEqual(webIdentity, webPrinciple.Identity);
        }

        [TestMethod]
        public void Test_WebPrincipalConstructedWithWebIdentityAndOneRoleCheckForRole_ReturnsTrue()
        {
            // Arrange
            var roles = new[] { RoleData.RoleName1 };
            var identity = (IIdentity)WindowsIdentity.GetCurrent();
            var webIdentity = new WebIdentity(identity, roles);

            // Act
            var webPrinciple = new WebPrincipal(webIdentity);

            // Assert
            Assert.IsTrue(webPrinciple.IsInRole(RoleData.RoleName1));
        }

        [TestMethod]
        public void Test_WebPrincipalConstructedWithWebIdentityAndOneRoleCheckForAnotherRole_ReturnsFalse()
        {
            // Arrange
            var roles = new[] { RoleData.RoleName2 };
            var identity = (IIdentity)WindowsIdentity.GetCurrent();
            var webIdentity = new WebIdentity(identity, roles);

            // Act
            var webPrinciple = new WebPrincipal(webIdentity);

            // Assert
            Assert.IsFalse(webPrinciple.IsInRole(RoleData.RoleName1));
        }

        [TestMethod]
        public void Test_WebPrincipalConstructedWithWebIdentityAndThreeRolesCheckForRoles_ReturnsTrue()
        {
            // Arrange
            var roles = new[] { RoleData.RoleName1, RoleData.RoleName2, RoleData.RoleName3 };
            var identity = (IIdentity)WindowsIdentity.GetCurrent();
            var webIdentity = new WebIdentity(identity, roles);

            // Act
            var webPrinciple = new WebPrincipal(webIdentity);

            // Assert
            Assert.IsTrue(webPrinciple.IsInRole(RoleData.RoleName1));
            Assert.IsTrue(webPrinciple.IsInRole(RoleData.RoleName2));
            Assert.IsTrue(webPrinciple.IsInRole(RoleData.RoleName3));
        }

        #endregion
    }
}