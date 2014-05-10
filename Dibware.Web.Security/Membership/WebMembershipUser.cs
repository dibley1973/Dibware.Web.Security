using System;

namespace Dibware.Web.Security.Membership
{
    public class WebMembershipUser : System.Web.Security.MembershipUser
    {
        public WebMembershipUser(
            String providerName,
            String name,
            Object providerUserKey,
            String email,
            String passwordQuestion,
            String comment,
            Boolean isApproved,
            Boolean isLockedOut,
            DateTime creationDate,
            DateTime lastLoginDate,
            DateTime lastActivityDate,
            DateTime lastPasswordChangedDate,
            DateTime lastLockoutDate
        )
            : base(providerName,
                name,
                providerUserKey,
                email,
                passwordQuestion,
                comment,
                isApproved,
                isLockedOut,
                creationDate,
                lastLoginDate,
                lastActivityDate,
                lastPasswordChangedDate,
                lastLockoutDate)
        { }
    }
}