using MatrixChallengePos.Models;
using Microsoft.Data.Sqlite;

namespace MatrixChallengePos.Services.Impl.Sqlite
{
    /// <summary>
    /// Implements the ILoginService against a SQLite database.
    /// </summary>
    public class LoginServiceSqlite : ILoginService
    {
        private readonly ISecurityService _securityService;
        private readonly IEmployeeService _employeeService;

        public LoginServiceSqlite(ISecurityService securityService,
                                  IEmployeeService employeeService)
        {
            _securityService = securityService;
            _employeeService = employeeService;
        }


        ///<inheritdoc/>
        public Employee Login(int employeeNumber, string clearTextPassword)
        {
            if (employeeNumber < 1 || string.IsNullOrWhiteSpace(clearTextPassword))
                return null;
            if (clearTextPassword.Length < SecurityService.PASSWORD_MINIMUM_LENGTH)
                return null;

            using var command = ((SqliteConnection) DbServiceSqlite.Instance.SqlConnection).CreateCommand();
            command.CommandText = "SELECT * FROM Employees WHERE employee_id = $id";
            command.Parameters.AddWithValue("$id", employeeNumber);

            using var reader = command.ExecuteReader();

            // employee_id is the PK, so will either return a single record or none
            if (reader.Read())
            {
                var knownHashedPassword = reader["hashed_password_tx"].ToString();
                var knownSalt = reader["salt_tx"].ToString();

                if (_securityService.VerifyHashedPassword(clearTextPassword, knownSalt, knownHashedPassword))
                {
                    return _employeeService.Get(employeeNumber);
                }
            }

            return null;
        }
    }
}