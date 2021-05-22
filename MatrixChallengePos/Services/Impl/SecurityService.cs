using System;
using System.Security.Cryptography;

namespace MatrixChallengePos.Services.Impl
{
    /// <summary>
    /// Implements ISecurityService using Rfc2898DeriveBytes class.
    /// Hash size 50
    /// Salt size 16
    /// Iterations 1000
    /// </summary>
    public class SecurityService : ISecurityService
    {
        public const int PASSWORD_MINIMUM_LENGTH = 3;

        // Hashed password's size in bytes
        private const int HASH_SIZE = 50;
        // Salt size in bytes
        private const int SALT_SIZE = 16;
        private const int ITERATIONS = 1000;


        ///<inheritdoc/>
        public HashedPassword GeneratePassword(string clearTextPassword)
        {
            using var algorithm
                = new Rfc2898DeriveBytes(clearTextPassword,
                                         SALT_SIZE,
                                         ITERATIONS,
                                         HashAlgorithmName.SHA256);

            return new HashedPassword
            {
                Password = Convert.ToBase64String(algorithm.GetBytes(HASH_SIZE)),
                Salt = Convert.ToBase64String(algorithm.Salt)
            };
        }


        ///<inheritdoc/>
        public bool VerifyHashedPassword(string clearTextPassword, string knownSalt, string knownHashedPassword)
        {
            if (string.IsNullOrWhiteSpace(clearTextPassword)
                || string.IsNullOrWhiteSpace(knownSalt)
                || string.IsNullOrWhiteSpace(knownHashedPassword))
            {
                return false;
            }

            using var algorithm
                = new Rfc2898DeriveBytes(clearTextPassword,
                                         Convert.FromBase64String(knownSalt),
                                         ITERATIONS,
                                         HashAlgorithmName.SHA256);

            var password = Convert.ToBase64String(algorithm.GetBytes(HASH_SIZE));
            return password.Equals(knownHashedPassword);
        }


    }

}