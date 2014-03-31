using System;

namespace Dibware.Web.Security.Providers.Contracts
{
    /// <summary>
    /// Defines the expected members of a RepositoryRoleProvider repository
    /// </summary>
    public interface IRepositoryRoleProviderRepository
    {
        /// <summary>
        /// Adds the specified user names to the specified roles for the configured applicationName.
        /// </summary>
        /// <param name="usernames">A string array of user names to be added to the specified roles.</param>
        /// <param name="roleNames">A string array of the role names to add the specified user names to.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        void AddUsersToRoles(String[] usernames, String[] roleNames);
        
            /// <summary>
        /// Adds a new role to the data source for the configured applicationName.
        /// </summary>
        /// <param name="roleName">The name of the role to create.</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.NotImplementedException"></exception>
        void CreateRole(String roleName);
        
        /// <summary>
        /// Removes a role from the data source for the configured applicationName.
        /// </summary>
        /// <param name="roleName">The name of the role to delete.</param>
        /// <param name="throwOnPopulatedRole">If true, throw an exception if <paramref name="roleName" /> has one or more members and do not delete <paramref name="roleName" />.</param>
        /// <returns>
        /// true if the role was successfully deleted; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        Boolean DeleteRole(String roleName, Boolean throwOnPopulatedRole);

        /// <summary>
        /// Finds the users in the specified role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="usernameToMatch">The username to match.</param>
        /// <returns></returns>
        String[] FindUsersInRole(String roleName, String usernameToMatch);

        /// <summary>
        /// Gets an array of all of the roles.
        /// </summary>
        /// <returns></returns>
        String[] GetAllRoles();

        /// <summary>
        /// Gets an array of all the roles for the user specified by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        String[] GetRolesForUser(String username);

        /// <summary>
        /// Gets a list of users in the specified role for the configured applicationName.
        /// </summary>
        /// <param name="roleName">The name of the role to get the list of users for.</param>
        /// <returns>
        /// A string array containing the names of all the users who are members of the specified role for the configured applicationName.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        String[] GetUsersInRole(String roleName);

        /// <summary>
        /// Gets a value indicating whether the specified user is in the specified role for the configured applicationName.
        /// </summary>
        /// <param name="username">The user name to search for.</param>
        /// <param name="roleName">The role to search in.</param>
        /// <returns>
        /// true if the specified user is in the specified role for the configured applicationName; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        Boolean IsUserInRole(String username, String roleName);

        /// <summary>
        /// Removes the specified user names from the specified roles for the configured applicationName.
        /// </summary>
        /// <param name="usernames">A string array of user names to be removed from the specified roles.</param>
        /// <param name="roleNames">A string array of role names to remove the specified user names from.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        void RemoveUsersFromRoles(String[] usernames, String[] roleNames);

        /// <summary>
        /// Gets a value indicating whether the specified role name already exists in the role data source for the configured applicationName.
        /// </summary>
        /// <param name="roleName">The name of the role to search for in the data source.</param>
        /// <returns>
        /// true if the role name already exists in the data source for the configured applicationName; otherwise, false.
        /// </returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        Boolean RoleExists(string roleName);
    }
}