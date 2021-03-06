using System.Collections.Generic;
using MatrixChallengePos.Models;
using MatrixChallengePos.Services;

namespace MatrixChallengePos.ViewModels
{
    public class PurchaseTransactionViewModel
    {
        private readonly IProductService _productService;
        private readonly IProductInventoryService _productInventoryService;

        private Transaction _transaction = new Transaction();


        public PurchaseTransactionViewModel(IProductService productService,
                                            IProductInventoryService productInventoryService)
        {
            _productService = productService;
            _productInventoryService = productInventoryService;
        }

        public void Clear()
        {
            _transaction = new Transaction();
        }

        public List<TransactionLineItem> TransactionLineItems => _transaction.TransactionLineItems;

        public Transaction Transaction => _transaction;

        public decimal TransactionSubTotal => _transaction.TransactionSubTotal;

        public decimal TransactionTax => _transaction.TransactionSubTotal * (decimal)0.075;

        public decimal TransactionGrandTotal => TransactionSubTotal + TransactionTax;



        public void AddTransactionLineItem(Product product, int quantity)
        {
            _transaction.AddTransactionLineItem(product, quantity);
        }


        public List<Product> FindProductsByName(string name)
        {
            return _productService.FindByName(name);
        }


        public List<Product> FindProductsByCategory(ProductCategory productCategory)
        {
            return _productService.FindByCategory(productCategory);
        }

    }
}