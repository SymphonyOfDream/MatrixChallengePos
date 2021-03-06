using System;
using System.Windows.Forms;
using MatrixChallengePos.Models;

namespace MatrixChallengePos.Views
{
    /// <summary>
    /// User control that holds a single transaction line item, with controls
    /// to delete it, and add/remove quantity.
    /// </summary>
    public partial class TransactionLineItemControl : UserControl
    {
        private TransactionLineItem _transactionLineItem;
        public event EventHandler TransactionLineItemChanged;
        public event EventHandler TransactionLineItemDeleted;

        public TransactionLineItemControl()
        {
            InitializeComponent();
        }


        public TransactionLineItem TransactionLineItem
        {
            get => _transactionLineItem;
            set
            {
                _transactionLineItem = value;
                UpdateVisualization();
            }
        }


        protected virtual void OnTransactionLineItem(EventArgs eventArgs)
        {
            UpdateVisualization();
            RaiseEvent(TransactionLineItemChanged, eventArgs);
        }


        protected virtual void OnTransactionLineItemDeleted(EventArgs e)
        {
            if (TransactionLineItemDeleted != null)
                TransactionLineItemDeleted(this, e);
        }


        protected void UpdateVisualization()
        {
            SuspendLayout();

            lblTransactionDetails.Text = _transactionLineItem.ToString();
            cmdRemoveOne.Enabled = _transactionLineItem.Quantity > 1;

            ResumeLayout();
        }


        private void RaiseEvent(EventHandler eventHandler, EventArgs eventArgs)
        {
            var temp = eventHandler;

            if (temp != null)
                temp(this, eventArgs);
        }

        private void cmdDeleteTransaction_Click(object sender, EventArgs e)
        {
            OnTransactionLineItemDeleted(new EventArgs());
        }

        private void cmdRemoveOne_Click(object sender, EventArgs e)
        {
            _transactionLineItem.Quantity--;
            UpdateVisualization();
        }

        private void cmdAddOne_Click(object sender, EventArgs e)
        {
            _transactionLineItem.Quantity++;
            UpdateVisualization();
        }
    }
}
