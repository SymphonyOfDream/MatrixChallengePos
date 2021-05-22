using System;
using System.Windows.Forms;
using MatrixChallengePos.ViewModels;

namespace MatrixChallengePos.Views
{
    /// <summary>
    /// Form to allow completion of transaction (payment)
    /// </summary>
    public partial class PayTransactionView : Form
    {
        private readonly PurchaseTransactionViewModel _viewModel;

        /// <summary>
        /// Sets up the form and Shows the subtotal, tax, and grand total due for the transaction.
        /// </summary>
        /// <param name="viewModel"></param>
        public PayTransactionView(PurchaseTransactionViewModel viewModel)
        {
            _viewModel = viewModel;

            InitializeComponent();

            var subtotal = _viewModel.TransactionSubTotal;
            lblSubtotal.Text = $"{subtotal:C2}";
            var tax = _viewModel.TransactionTax;
            lblTax.Text = $"{tax:C2}";
            var grandTotal = _viewModel.TransactionGrandTotal;
            lblGrandTotal.Text = $"{grandTotal:C2}";
        }

        /// <summary>
        /// Displays amount due back to the customer, and breaks
        /// that amount down into discrete monetary amounts for the cashier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAmountTendered_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmountTendered.Text, out var amountTendered))
            {
                var amountDueCustomer = amountTendered - _viewModel.TransactionGrandTotal;
                lblChangeDueCustomer.Text = $"{amountDueCustomer:C2}";

                var twenties = (int) (amountDueCustomer / 20);
                amountDueCustomer -= twenties * 20;

                var tens = (int)(amountDueCustomer / 10);
                amountDueCustomer -= tens * 10;

                var fives = (int)(amountDueCustomer / 5);
                amountDueCustomer -= fives * 5;

                var ones = (int)amountDueCustomer;
                amountDueCustomer -= ones;

                var quarters = (int)(amountDueCustomer / (decimal)0.25);
                amountDueCustomer -= (decimal)quarters * (decimal)0.25;
                var dimes = (int)(amountDueCustomer / (decimal)0.10);
                amountDueCustomer -= (decimal)dimes * (decimal)0.10;
                var nickles = (int)(amountDueCustomer / (decimal)0.05);
                amountDueCustomer -= (decimal)nickles * (decimal)0.05;
                var pennies = (int)(amountDueCustomer * (decimal)100.00);

                lblAmountDueCustomerBreakdown.Text
                    = (twenties > 0 ? $"{twenties} $20s  " : "")
                    + (tens > 0     ? $"{tens} $10s  " : "")
                    + (fives > 0    ? $"{fives} $5s  " : "")
                    + (ones > 0     ? $"{ones} $1s  " : "")
                    + (quarters > 0 ? $"{quarters} quarters  " : "")
                    + (dimes > 0    ? $"{dimes} dimes  " : "")
                    + (nickles > 0  ? $"{nickles} nickles  " : "")
                    + (pennies > 0  ? $"{pennies} pennies  " : "");
            }
            else
            {
                MessageBox.Show("Amount tendered value is not a valid amount.", "Invalid entry", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
            }
        }

        private void cmdCancelTransactionPayment_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Currently nothing more than this is done on Payment complete.
        /// Ideally, we'll keep track of the cash in the drawer, take
        /// credit cards and check, in addition to cash.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCompleteTransaction_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
