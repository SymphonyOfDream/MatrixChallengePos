using System;
using System.ComponentModel.Design;
using System.Windows.Forms;
using MatrixChallengePos.Models;
using MatrixChallengePos.Services;
using MatrixChallengePos.ViewModels;
using Ninject;

namespace MatrixChallengePos.Views
{
    public partial class PurchaseTransactionControl : UserControl
    {
        private readonly PurchaseTransactionViewModel _viewModel;

        private readonly IProductCategoryService _productCategoryService;
        
        private readonly TransactionLineItemsListControl _transactionLineItemsListControl;

        public event EventHandler TransactionCanceled;
        public event EventHandler TransactionCompleted;


        public PurchaseTransactionControl(PurchaseTransactionViewModel viewModel,
                                          IProductCategoryService productCategoryService)
        {
            _viewModel = viewModel;
            _productCategoryService = productCategoryService;

            InitializeComponent();

            // Create the user control that will hold all of our TransactionLineItem controls.
            // Quick and dirty sizing due to time constraints.
            _transactionLineItemsListControl = new TransactionLineItemsListControl();
            _transactionLineItemsListControl.Anchor =
                AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            _transactionLineItemsListControl.Left = 10;
            _transactionLineItemsListControl.Top = 20;
            _transactionLineItemsListControl.Width = grpTransaction.Width - 21;
            _transactionLineItemsListControl.Height = grpTransaction.Height - 31;
            _transactionLineItemsListControl.TransactionLineItemListChanged += TransactionLineItemsListControl_TransactionLineItemListChanged;
            
            grpTransaction.Controls.Add(_transactionLineItemsListControl);

            // Add all of our categories to the dropdown
            _productCategoryService.All.ForEach( c => cboSearchProductCategories.Items.Add(c));
            // Create a blank ProductCategory so we have an item we can select to DE-select filtering by Categories.
            cboSearchProductCategories.Items.Insert(0, new ProductCategory(){Name = ""});
        }

        private void TransactionLineItemsListControl_TransactionLineItemListChanged(object sender, EventArgs e)
        {
            var subtotal = _viewModel.TransactionSubTotal;
            lblTransactionSubtotal.Text = $"{subtotal:C2}";
            var tax = _viewModel.TransactionTax;
            lblTransactionTax.Text = $"{tax:C2}";
            var grandTotal = _viewModel.TransactionGrandTotal;
            lblTransactionTotal.Text = $"{grandTotal:C2}";
        }

        protected virtual void OnTransactionCanceled(EventArgs eventArgs)
        {
            if (TransactionCanceled != null)
                TransactionCanceled(this, eventArgs);
        }

        protected virtual void OnTransactionCompleted(EventArgs eventArgs)
        {
            if (TransactionCompleted != null)
                TransactionCompleted(this, eventArgs);
        }

        
        private void lstProductSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdAddFoundProductsToTransaction.Enabled = lstProductSearchResults.SelectedItems.Count > 0;
        }


        private void cmdAddFoundProductsToTransaction_Click(object sender, EventArgs e)
        {
            foreach (var selectedItem in lstProductSearchResults.SelectedItems)
            {
                var transactionLineItem = _viewModel.Transaction.AddTransactionLineItem((Product)selectedItem, 1);
                _transactionLineItemsListControl.AddTransactionLineItem(transactionLineItem);
            }
        }


        private void txtSearchProductName_TextChanged(object sender, EventArgs e)
        {
            lstProductSearchResults.Items.Clear();

            var foundProducts = _viewModel.FindProductsByName(txtSearchProductName.Text);
            foundProducts.ForEach(p => lstProductSearchResults.Items.Add(p));
        }


        private void cboSearchProductCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchProductName.Text = string.Empty;
            lstProductSearchResults.Items.Clear();

            var foundProducts = _viewModel.FindProductsByCategory((ProductCategory)cboSearchProductCategories.SelectedItem);
            foundProducts.ForEach(p => lstProductSearchResults.Items.Add(p));
        }


        private void DoClearTransaction()
        {
            lstProductSearchResults.Items.Clear();
            _viewModel.Clear();
            _transactionLineItemsListControl.Clear();
            _transactionLineItemsListControl.TransactionLineItemListChanged -= TransactionLineItemsListControl_TransactionLineItemListChanged;
        }


        private void cmdCancelTransaction_Click(object sender, EventArgs e)
        {
            DoClearTransaction();
            OnTransactionCanceled(new EventArgs());
        }


        private void cmdPay_Click(object sender, EventArgs e)
        {
            DialogResult rc = Program.NinjectKernel.Get<PayTransactionView>().ShowDialog();
            if (rc == DialogResult.OK)
            {
                DoClearTransaction();
                OnTransactionCompleted(new EventArgs());
            }
        }
    }
}
