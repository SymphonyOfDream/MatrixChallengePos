namespace MatrixChallengePos.Services
{

    /// <summary>
    /// Implementors will provide ISecurityService functionality using their specific algorithms/security infrastructure.
    /// </summary>
    public interface ISecurityService
    {
        /// <summary>
        /// Generates a 1-way hash of a clear text password using a random salt value.
        /// </summary>
        /// <param name="clearTextPassword">Password to be hashed</param>
        /// <returns>One-way hash of the specified clear text password along with the salt used.</returns>
        HashedPassword GeneratePassword(string clearTextPassword);

        /// <summary>
        /// Verifies that a clear-text password will create the exact hashed password with the given salt value.
        /// </summary>
        /// <param name="clearTextPassword">Password to be verified</param>
        /// <param name="knownSalt">Salt that was used to create the known hashed password</param>
        /// <param name="knownHashedPassword">Known hashed password.</param>
        /// <returns>True if the clear-text password will generate a 1-way hash password that is exactly
        /// the same as the knownHashedPassword when using the knownSalt. False otherwise.</returns>
        bool VerifyHashedPassword(string clearTextPassword, string knownSalt, string knownHashedPassword);
    }


    /// <summary>
    /// When a password is hashed, the resultant
    /// 1-way hashed password and salt value used
    /// is returned in this class.
    /// </summary>
    public class HashedPassword
    {
        public string Password { get; set; }
        public string Salt { get; set; }
    }

}