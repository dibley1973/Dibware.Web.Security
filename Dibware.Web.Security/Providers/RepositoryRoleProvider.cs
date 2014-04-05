using Dibware.Web.Security.Providers.Contracts;
using Dibware.Web.Security.Resources;
using Ninject;
using System;
using System.Web.Security;

namespace Dibware.Web.Security.Providers
{
    public class RepositoryRoleProvider : RoleProvider, IRepositoryRoleProvider
    {
        #region Properties

        /// <summary>
        /// Gets or sets the role provider repository which this provider will use.
        /// </summary>
        /// <value>
        /// The role provider repository.
        /// </value>
        [Inject]
        public IRepositoryRoleProviderRepository RoleProviderRepository { get; set; }

        #endregion

        #region RoleProvider Implementation

        /// <summary>
        /// Adds the specified user names to the specified roles for the configured applicationName.
        /// </summary>
        /// <param name="usernames">A string array of user names to be added to the specified roles.</param>
        /// <param name="roleNames">A string array of the role names to add the specified user names to.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void AddUsersToRoles(String[] usernames, String[] roleNames)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets or sets the name of the application to store and retrieve role information for.
        /// </summary>
        /// <returns>The name of the application to store and retrieve role information for.</returns>
        public override string ApplicationName { get; set; }

        /// <summary>
        /// Adds a new role to the data source for the configured applicationName.
        /// </summary>
        /// <param name="roleName">The name of the role to create.</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void CreateRole(String roleName)
        {
            // Validate arguments
            if (RoleProviderRepository == null)
            {
                throw new InvalidOperationException(ExceptionMessages.RoleProviderRepositoryIsNull);
            }

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
        public override bool DeleteRole(String roleName, bool throwOnPopulatedRole)
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
        public override String[] FindUsersInRole(String roleName, String usernameToMatch)
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
        public override String[] GetAllRoles()
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
        public override String[] GetRolesForUser(String username)
        {
            // Validate arguments
            if (RoleProviderRepository == null)
            {
                throw new InvalidOperationException(ExceptionMessages.RoleProviderRepositoryIsNull);
            }

            // Use the repository to return roles for the user
            return RoleProviderRepository.GetRolesForUser(username);
        }

        /// <summary>
        /// Gets a list of users in the specified role for the configured applicationName.
        /// </summary>
        /// <param name="roleName">The name of the role to get the list of users for.</param>
        /// <returns>
        /// A string array containing the names of all the users who are members of the specified role for the configured applicationName.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override String[] GetUsersInRole(String roleName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a value indicating whether the specified user is in the specified role for the configured applicationName.
        /// </summary>
        /// <param name="username">The user name to search for.</param>
        /// <param name="roleName">The role to search in.</param>
        /// <returns>
        /// true if the specified user is in the specified role for the configured applicationName; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool IsUserInRole(String username, String roleName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specified user names from the specified roles for the configured applicationName.
        /// </summary>
        /// <param name="usernames">A string array of user names to be removed from the specified roles.</param>
        /// <param name="roleNames">A string array of role names to remove the specified user names from.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void RemoveUsersFromRoles(String[] usernames, String[] roleNames)
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
        public override bool RoleExists(String roleName)
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