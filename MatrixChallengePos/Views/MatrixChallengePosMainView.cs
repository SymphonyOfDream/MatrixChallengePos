using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MatrixChallengePos.ViewModels;

namespace MatrixChallengePos.Views
{
    public partial class MatrixChallengePosMainView : Form
    {
        private readonly MatrixChallengePosViewModel _viewModel;

        public MatrixChallengePosMainView(MatrixChallengePosViewModel viewModel)
        {
            _viewModel = viewModel;

            InitializeComponent();
        }


    }
}
