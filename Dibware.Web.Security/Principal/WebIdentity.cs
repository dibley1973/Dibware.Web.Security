using System;
using System.Security.Principal;
using Dibware.Web.Security.Resources;

namespace Dibware.Web.Security.Principal
{
    /// <summary>
    /// A basic identity for ue with web applications
    /// </summary>
    public class WebIdentity : IIdentity
    {
        #region Properties

        /// <summary>
        /// Gets the roles that the identity is a member of.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public String[] Roles { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="WebIdentity"/> class from being created.
        /// </summary>
        /// <param name="identity">The identity.</param>
        private WebIdentity(IIdentity identity)
        {
            // Validate arguments
            if (identity == null)
            {
                throw new ArgumentNullException("identity", ExceptionMessages.IdentityMustNotBeNull);
            }

            // Set properties
            Name = identity.Name;
            IsAuthenticated = identity.IsAuthenticated;
            AuthenticationType = identity.AuthenticationType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebIdentity"/> class.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <param name="roles">The roles.</param>
        /// <exception cref="System.ArgumentNullException">roles</exception>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public WebIdentity(IIdentity identity, String[] roles)
            : this(identity)
        {
            // Validate arguments
            if (roles == null)
            {
                throw new ArgumentNullException("roles", ExceptionMessages.IdentityMustNotBeNull);
            }
            if (roles.Length == 0)
            {
                throw new ArgumentOutOfRangeException("roles", roles.Length, ExceptionMessages.RolesMustNotBeEmpty); 
            }

            // Set properties
            Roles = roles;
        }

        #endregion

        #region IIdentity Members

        /// <summary>
        /// Gets the type of authentication used.
        /// </summary>
        /// <returns>The type of authentication used to identify the user.</returns>
        public String AuthenticationType { get; private set; }

        /// <summary>
        /// Gets a value that indicates whether the user has been authenticated.
        /// </summary>
        /// <returns>true if the user was authenticated; otherwise, false.</returns>
        public Boolean IsAuthenticated { get; private set; }

        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <returns>The name of the user on whose behalf the code is running.</returns>
        public String Name { get; private set; }

        #endregion
    }
}