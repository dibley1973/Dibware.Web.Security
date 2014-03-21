using System;

namespace Dibware.Web.Security.Providers.Contracts
{
    public interface ISqlServerRoleProviderRepository
    {
        /// <summary>
        /// Gets the roles for the user specified by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        String[] GetRolesForUser(String username);
    }
}