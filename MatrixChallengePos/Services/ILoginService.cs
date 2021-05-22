using MatrixChallengePos.Models;

namespace MatrixChallengePos.Services
{
    /// <summary>
    /// Implementors will provide ILoginService for their specific data store and security infrastructure.
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Gets employee record from the DB, hashes user-entered password
        /// using the salt obtained from the record, and compares hashed
        /// password with what is stored in the DB.
        /// </summary>
        /// <param name="employeeNumber">Employee's unique employee number</param>
        /// <param name="clearTextPassword">Password the user entered</param>
        /// <returns>Employee that has been authenticated, null otherwise.</returns>
        Employee Login(int employeeNumber, string clearTextPassword);
    }
}