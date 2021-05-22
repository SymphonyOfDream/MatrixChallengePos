using MatrixChallengePos.Models;

namespace MatrixChallengePos.ViewModels
{
    public class MatrixChallengePosViewModel
    {
        private Employee _loggedInEmployee;

        /// <summary>
        /// The employee who is currently logged in, or null if no one logged in.
        /// </summary>
        public Employee LoggedInEmployee
        {
            get => _loggedInEmployee;
            set => _loggedInEmployee = value;
        }
    }
}