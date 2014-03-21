using System;

namespace Dibware.Web.Security.Providers.Contracts
{
    public interface ISqlServerRoleProviderRepository
    {
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