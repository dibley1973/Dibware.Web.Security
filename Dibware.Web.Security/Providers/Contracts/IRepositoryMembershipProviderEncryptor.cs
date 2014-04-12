using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dibware.Web.Security.Providers.Contracts
{
    /// <summary>
    /// Defines the expected members for the encryptor to use with the membership provider
    /// </summary>
    public interface IRepositoryMembershipProviderEncryptor
    {
        /// <summary>
        /// Encrypts the specified value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        String EncryptValue(String value);
    }
}