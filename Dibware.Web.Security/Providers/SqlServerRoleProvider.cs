using Dibware.Web.Security.Providers.Contracts;
using Dibware.Web.Security.Resources;
using Ninject;
using System;
using System.Web.Security;

namespace Dibware.Web.Security.Providers
{
    public class SqlServerRoleProvider : RoleProvider
    {


        #region Properties

        /// <summary>
        /// Gets or sets the role provider repository which this provider will use.
        /// </summary>
        /// <value>
        /// The role provider repository.
        /// </value>
        [Inject]
        public ISqlServerRoleProviderRepository RoleProviderRepository { get; set; }

        #endregion

        #region RoleProvider Implementation

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets or sets the name of the application to store and retrieve role information for.
        /// </summary>
        /// <returns>The name of the application to store and retrieve role information for.</returns>
        public override string ApplicationName { get; set; }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            // Validate arguments
            if (RoleProviderRepository == null)
            {
                throw new InvalidOperationException(ExceptionMessages.RoleProviderRepositoryIsNull);
            }

            // Use the repository to return roles for the user
            return RoleProviderRepository.GetRolesForUser(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}