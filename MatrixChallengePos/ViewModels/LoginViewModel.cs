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

        public bool AttemptLogon(int employeeNbr, string clearTextPassword)
        {
            MatrixChallengePosSystem.Instance.CurrentEmployeeLoggedIn = _loginService.Login(employeeNbr, clearTextPassword);
            return MatrixChallengePosSystem.Instance.CurrentEmployeeLoggedIn != null;
        }

    }
}