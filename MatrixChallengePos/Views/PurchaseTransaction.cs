using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MatrixChallengePos.ViewModels
{
    public partial class PurchaseTransaction : UserControl
    {
        private readonly PurchaseTransactionViewModel _viewModel;

        public PurchaseTransaction(PurchaseTransactionViewModel viewModel)
        {
            _viewModel = viewModel;

            InitializeComponent();
        }


    }
}
