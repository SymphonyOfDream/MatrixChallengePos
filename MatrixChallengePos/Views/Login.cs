using System;
using System.Windows.Forms;
using MatrixChallengePos.ViewModels;

namespace MatrixChallengePos.Views
{
    public partial class LoginView : Form
    {
        private readonly LoginViewModel _loginViewModel;


        public LoginView(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;

            InitializeComponent();
        }


        /// <summary>
        /// Attempts to log the user on given the password they entered and their employee number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdLogon_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtEmployeeNumber.Text, out var employeeNbr))
            {
                MessageBox.Show("Employee Number entered is not a valid Employee Number. It must be a number.");
                return;
            }

            if (_loginViewModel.AttemptLogon(employeeNbr, txtPassword.Text))
            {
                Close();
                return;
            }

            MessageBox.Show("Invalid Employee Number and/or Password.");
        }
    }
}
