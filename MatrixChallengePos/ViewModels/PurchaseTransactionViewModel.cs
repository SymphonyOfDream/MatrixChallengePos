using System.Collections.Generic;
using MatrixChallengePos.Models;
using MatrixChallengePos.Services;

namespace MatrixChallengePos.ViewModels
{
    public class PurchaseTransactionViewModel
    {
        private readonly IProductService _productService;
        private readonly IProductInventoryService _productInventoryService;

        private readonly Transaction _transaction = new Transaction();


        public PurchaseTransactionViewModel(IProductService productService,
                                            IProductInventoryService productInventoryService)
        {
            _productService = productService;
            _productInventoryService = productInventoryService;
        }


        public List<TransactionLineItem> TransactionLineItems => _transaction.TransactionLineItems;

        public decimal TransactionSubTotal => _transaction.TransactionSubTotal;


    }
}