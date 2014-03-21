using System;
using System.Linq;
using System.Security.Principal;
using Dibware.Web.Security.Resources;

namespace Dibware.Web.Security.Principal
{
    /// <summary>
    /// A Principle object specifically for the web.
    /// </summary>
    public class WebPrincipal : IPrincipal
    {
        #region Declarations

        private readonly WebIdentity _identity;

        #endregion

        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="WebPrincipal"/> class from being created.
        /// </summary>
        private WebPrincipal() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPrincipal"/> class.
        /// </summary>
        /// <param name="identity">The identity.</param>
        public WebPrincipal(WebIdentity identity)
            : this()
        {
            // Validate arguments
            if (identity == null)
            {
                throw new ArgumentNullException("identity", ExceptionMessages.IdentityMustNotBeNull);
            }

            // Set member
            _identity = identity;
        }

        #endregion

        #region IPrincipal Members

        /// <summary>
        /// Gets the identity of the current principal.
        /// </summary>
        /// <returns>The <see cref="T:System.Security.Principal.IIdentity" /> object associated with the current principal.</returns>
        public virtual IIdentity Identity
        {
            get { return _identity; }
        }

        /// <summary>
        /// Determines whether the current principal belongs to the specified role.
        /// </summary>
        /// <param name="role">The name of the role for which to check membership.</param>
        /// <returns>
        /// true if the current principal is a member of the specified role; otherwise, false.
        /// </returns>
        public Boolean IsInRole(String role)
        {
            return _identity.Roles.Contains(role);
        }

        #endregion
    }
}