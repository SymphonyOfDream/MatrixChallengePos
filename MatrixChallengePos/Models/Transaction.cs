using System.Collections.Generic;

namespace MatrixChallengePos.Models
{
    public class Transaction
    {
        private int _id;

        private readonly List<TransactionLineItem> _transactionLineItems = new List<TransactionLineItem>();

        private int _largestProductNameLen = 0;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public List<TransactionLineItem> TransactionLineItems => _transactionLineItems;


        public int LargestProductNameLen
        {
            get => _largestProductNameLen;
            set => _largestProductNameLen = value;
        }

        public void AddTransactionLineItem(Product product, int quantity)
        {
            var newTransactionLineItem = new TransactionLineItem(this)
            {
                Product = product,
                Quantity = quantity
            };
            var alreadyExistingItem = _transactionLineItems.Find(i => i.Equals(newTransactionLineItem));

            if (alreadyExistingItem != null)
            {
                alreadyExistingItem.Quantity += newTransactionLineItem.Quantity;
            }
            else
            {
                _transactionLineItems.Add(newTransactionLineItem);

                // Get largest
                if (_largestProductNameLen < newTransactionLineItem.Product.Name.Length)
                    _largestProductNameLen = newTransactionLineItem.Product.Name.Length;
            }
        }


        public void RemoveTransactionLineItem(TransactionLineItem item)
        {
            _transactionLineItems.Remove(item);
        }


        public decimal TransactionSubTotal
        {
            get
            {
                var total = decimal.Zero;
                _transactionLineItems.ForEach(i => total += i.TransactionSubTotal);
                return total;
            }
        }


    }
}