using System;
using System.Windows.Forms;
using MatrixChallengePos.ViewModels;
using Ninject;

namespace MatrixChallengePos.Views
{
    /// <summary>
    /// Main form of application. Right now it has a single functionality, and
    /// that is to add products to a transaction.
    /// Ideally, there will be buttons to bring up a returns usercontrol, among
    /// other functions.
    /// </summary>
    public partial class MatrixChallengePosMainView : Form
    {
        private readonly MatrixChallengePosViewModel _viewModel;
        private PurchaseTransactionControl _purchaseTransactionControl = null;


        public MatrixChallengePosMainView(MatrixChallengePosViewModel viewModel)
        {
            _viewModel = viewModel;

            InitializeComponent();
        }

        private void cmdStartPurchase_Click(object sender, EventArgs e)
        {
            if (_purchaseTransactionControl != null)
            {
                _purchaseTransactionControl.Show();
                return;
            }

            _purchaseTransactionControl = Program.NinjectKernel.Get<PurchaseTransactionControl>();
            _purchaseTransactionControl.TransactionCanceled += PurchaseTransactionControl_TransactionCanceled;
            _purchaseTransactionControl.TransactionCompleted += PurchaseTransactionControl_TransactionCompleted;
            pnlUserControl.Controls.Add(_purchaseTransactionControl);
        }


        private void UnwirePurchaseTransactionControl()
        {
            _purchaseTransactionControl.TransactionCanceled -= PurchaseTransactionControl_TransactionCompleted;
            _purchaseTransactionControl.TransactionCanceled -= PurchaseTransactionControl_TransactionCanceled;
        }


        private void PurchaseTransactionControl_TransactionCompleted(object sender, EventArgs e)
        {
            pnlUserControl.Controls.Remove(_purchaseTransactionControl);
            UnwirePurchaseTransactionControl();
            _purchaseTransactionControl = null;
        }

        private void PurchaseTransactionControl_TransactionCanceled(object sender, EventArgs e)
        {
            pnlUserControl.Controls.Remove(_purchaseTransactionControl);
            UnwirePurchaseTransactionControl();
            _purchaseTransactionControl = null;
        }


        private void DoLogon()
        {
            Program.NinjectKernel.Get<LoginView>().ShowDialog();
            if (MatrixChallengePosSystem.Instance.CurrentEmployeeLoggedIn == null)
            {
                Close();
                return;
            }

            lblLoggedOnEmployee.Text = MatrixChallengePosSystem.Instance.CurrentEmployeeLoggedIn.ToString();
        }


        private void MatrixChallengePosMainView_Shown(object sender, EventArgs e)
        {
            if (MatrixChallengePosSystem.Instance.CurrentEmployeeLoggedIn == null)
            {
                DoLogon();
            }
        }


        private void CmdLogout_Click(object sender, System.EventArgs e)
        {
            MatrixChallengePosSystem.Instance.CurrentEmployeeLoggedIn = null;
            lblLoggedOnEmployee.Text = "NONE";
            DoLogon();
        }

    }
}
