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

        /// <summary>
        /// Removes a role from the data source for the configured applicationName.
        /// </summary>
        /// <param name="roleName">The name of the role to delete.</param>
        /// <param name="throwOnPopulatedRole">If true, throw an exception if <paramref name="roleName" /> has one or more members and do not delete <paramref name="roleName" />.</param>
        /// <returns>
        /// true if the role was successfully deleted; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            // Validate arguments
            if (RoleProviderRepository == null)
            {
                throw new InvalidOperationException(ExceptionMessages.RoleProviderRepositoryIsNull);
            }

            // Use the repository to Delete the role
            return RoleProviderRepository.DeleteRole(roleName, throwOnPopulatedRole);
        }

        /// <summary>
        /// Gets an array of user names in a role where the user name contains the specified user name to match.
        /// </summary>
        /// <param name="roleName">The role to search in.</param>
        /// <param name="usernameToMatch">The user name to search for.</param>
        /// <returns>
        /// A string array containing the names of all the users where the user name matches <paramref name="usernameToMatch" /> and the user is a member of the specified role.
        /// </returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            // Validate arguments
            if (RoleProviderRepository == null)
            {
                throw new InvalidOperationException(ExceptionMessages.RoleProviderRepositoryIsNull);
            }

            // Use the repository to return roles
            return RoleProviderRepository.FindUsersInRole(roleName, usernameToMatch);
        }

        /// <summary>
        /// Gets a list of all the roles for the configured applicationName.
        /// </summary>
        /// <returns>
        /// A string array containing the names of all the roles stored in the data source for the configured applicationName.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override string[] GetAllRoles()
        {
            // Validate arguments
            if (RoleProviderRepository == null)
            {
                throw new InvalidOperationException(ExceptionMessages.RoleProviderRepositoryIsNull);
            }

            // Use the repository to return roles
            return RoleProviderRepository.GetAllRoles();
        }

        /// <summary>
        /// Gets a list of the roles that a specified user is in for the configured applicationName.
        /// </summary>
        /// <param name="username">The user to return a list of roles for.</param>
        /// <returns>
        /// A string array containing the names of all the roles that the specified user is in for the configured applicationName.
        /// </returns>
        /// <exception cref="System.InvalidOperationException"></exception>
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

        /// <summary>
        /// Gets a value indicating whether the specified role name already exists in the role data source for the configured applicationName.
        /// </summary>
        /// <param name="roleName">The name of the role to search for in the data source.</param>
        /// <returns>
        /// true if the role name already exists in the data source for the configured applicationName; otherwise, false.
        /// </returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public override bool RoleExists(string roleName)
        {
            // Validate arguments
            if (RoleProviderRepository == null)
            {
                throw new InvalidOperationException(ExceptionMessages.RoleProviderRepositoryIsNull);
            }

            // Use the repository to check if a role exist
            return RoleProviderRepository.RoleExists(roleName);
        }

        #endregion
    }
}