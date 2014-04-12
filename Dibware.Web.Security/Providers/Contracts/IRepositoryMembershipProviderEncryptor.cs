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
        /// Creates and returns a new 'salt' for the specified value.
        /// </summary>
        /// <param name="value">The value to create a 'salt' from</param>
        /// <returns></returns>
        String CreateSalt(String value);

        /// <summary>
        /// Encrypts the specified value
        /// </summary>
        /// <param name="value">The value to be encrypted</param>
        /// <returns></returns>
        String EncryptValue(String value);

        /// <summary>
        /// Encrypts the specified value
        /// </summary>
        /// <param name="value">The value to be encrypted</param>
        /// <param name="salt">The 'salt' used to encrypt the value</param>
        /// <returns></returns>
        String EncryptValue(String value, String salt);
    }
}