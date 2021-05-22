using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MatrixChallengePos.Models;
using MatrixChallengePos.ViewModels;
using Ninject;
using static System.Windows.Forms.DataFormats;

namespace MatrixChallengePos.Views
{
    public partial class MatrixChallengePosMainView : Form
    {
        private readonly MatrixChallengePosViewModel _viewModel;
        private PurchaseTransaction _purchaseTransactionView = null;


        public MatrixChallengePosMainView(MatrixChallengePosViewModel viewModel)
        {
            _viewModel = viewModel;

            InitializeComponent();
        }

        private void cmdStartPurchase_Click(object sender, EventArgs e)
        {
            var purchaseTransactionControl = Program.NinjectKernel.Get<PurchaseTransaction>();
            pnlUserControl.Controls.Add(purchaseTransactionControl);
        }

    }
}
