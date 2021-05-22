using MatrixChallengePos.Services;

namespace MatrixChallengePos.ViewModels
{
    public class LoginViewModel
    {
        private readonly ILoginService _loginService;


        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Attempts to login the user using the employee number and password they entered.
        /// </summary>
        /// <param name="employeeNbr"></param>
        /// <param name="clearTextPassword"></param>
        /// <returns>True if logged in, false otherwise.</returns>
        public bool AttemptLogon(int employeeNbr, string clearTextPassword)
        {
            MatrixChallengePosSystem.Instance.CurrentEmployeeLoggedIn = _loginService.Login(employeeNbr, clearTextPassword);
            return MatrixChallengePosSystem.Instance.CurrentEmployeeLoggedIn != null;
        }

    }
}