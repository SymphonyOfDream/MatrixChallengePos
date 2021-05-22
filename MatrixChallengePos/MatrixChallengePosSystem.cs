using MatrixChallengePos.Models;
using MatrixChallengePos.Services.Impl.Sqlite;

namespace MatrixChallengePos
{
    public class MatrixChallengePosSystem
    {
        private static MatrixChallengePosSystem _instance = null;
        private static readonly object _lock = new object();

        private Employee _currentEmployeeLoggedIn = null;

        private MatrixChallengePosSystem()
        {
            // We just ping our db service to make sure it is up and running before we 
            // allow the application to fully startup.
            // NOTE: in debug mode this will prepopulate the DB with test values if
            // the DB is empty.
            var dbServiceSqlite = DbServiceSqlite.Instance;
        }


        public static MatrixChallengePosSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MatrixChallengePosSystem();
                        }
                    }
                }
                return _instance;
            }
        }


        public Employee CurrentEmployeeLoggedIn
        {
            get => _currentEmployeeLoggedIn;
            set => _currentEmployeeLoggedIn = value;
        }
    }
}