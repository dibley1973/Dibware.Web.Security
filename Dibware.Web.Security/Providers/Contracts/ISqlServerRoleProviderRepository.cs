using System;

namespace Dibware.Web.Security.Providers.Contracts
{
    public interface ISqlServerRoleProviderRepository
    {
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
    }
}