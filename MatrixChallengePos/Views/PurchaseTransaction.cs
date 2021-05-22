using System;
using System.Windows.Forms;
using MatrixChallengePos.Services;
using MatrixChallengePos.ViewModels;
using MatrixChallengePos.Views;

namespace MatrixChallengePos.Models
{
    public partial class PurchaseTransaction : UserControl
    {
        private readonly PurchaseTransactionViewModel _viewModel;

        private readonly IProductCategoryService _productCategoryService;
        
        private readonly TransactionLineItemsList _transactionLineItemsList;


        public PurchaseTransaction(PurchaseTransactionViewModel viewModel,
                                   IProductCategoryService productCategoryService)
        {
            _viewModel = viewModel;
            _productCategoryService = productCategoryService;

            InitializeComponent();

            // Create the user control that will hold all of our TransactionLineItem controls.
            // Quick and dirty sizing due to time constraints.
            _transactionLineItemsList = new TransactionLineItemsList();
            _transactionLineItemsList.Anchor =
                AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            _transactionLineItemsList.Left = 10;
            _transactionLineItemsList.Top = 20;
            _transactionLineItemsList.Width = grpTransaction.Width - 21;
            _transactionLineItemsList.Height = grpTransaction.Height - 31;

            grpTransaction.Controls.Add(_transactionLineItemsList);

            // Add all of our categories to the dropdown
            _productCategoryService.All.ForEach( c => cboSearchProductCategories.Items.Add(c));
            // Create a blank ProductCategory so we have an item we can select to DE-select filtering by Categories.
            cboSearchProductCategories.Items.Insert(0, new ProductCategory(){Name = ""});
        }


        private void lstProductSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdAddFoundProductsToTransaction.Enabled = lstProductSearchResults.SelectedItems.Count > 0;
        }


        private void cmdAddFoundProductsToTransaction_Click(object sender, EventArgs e)
        {
            foreach (var selectedItem in lstProductSearchResults.SelectedItems)
            {
                _viewModel.Transaction.AddTransactionLineItem((Product)selectedItem, 1);
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
    }
}
