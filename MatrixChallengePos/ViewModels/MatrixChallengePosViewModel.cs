using MatrixChallengePos.Models;

namespace MatrixChallengePos.ViewModels
{
    public class MatrixChallengePosViewModel
    {
        private Employee _loggedInEmployee;


        public Employee LoggedInEmployee
        {
            get => _loggedInEmployee;
            set => _loggedInEmployee = value;
        }
    }
}