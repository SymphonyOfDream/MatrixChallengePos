using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatrixChallengePos.Services;
using MatrixChallengePos.Services.Impl.Sqlite;
using MatrixChallengePos.ViewModels;

namespace MatrixChallengePos.Views
{
    public partial class Logon : Form
    {
        private readonly LoginViewModel _loginViewModel;


        public Logon(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;

            InitializeComponent();
        }


        private void cmdLogon_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtEmployeeNumber.Text, out var employeeNbr))
            {
                MessageBox.Show("Employee Number entered is not a valid Employee Number. It must be a number.");
            }

            if (_loginViewModel.AttemptLogon(employeeNbr, txtPassword.Text))
            {
                Close();
            }

            MessageBox.Show("Invalid Employee Number and/or Password.");
        }
    }
}
