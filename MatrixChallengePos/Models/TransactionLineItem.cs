using System;
using System.Globalization;

namespace MatrixChallengePos.Models
{
    public class TransactionLineItem
    {
        private int _id;
        private readonly Transaction _owningTransaction;
        private Product _product;
        private int _quantity;


        public TransactionLineItem(Transaction owner)
        {
            _owningTransaction = owner;
        }


        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public Product Product
        {
            get => _product;
            set => _product = value;
        }

        public int Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }


        public decimal TransactionSubTotal
        {
            get
            {
                if (_product != null)
                    return _product.RetailPrice * _quantity;

                return 0;
            }
        }


        public override string ToString()
        {
            return _product.Name.PadRight(_owningTransaction.LargestProductNameLen + 4)
                   + "x " + _quantity.ToString().PadRight(4)
                   + "$" + $"{TransactionSubTotal:C2}".PadLeft(6);
        }


        protected bool Equals(TransactionLineItem other)
        {
            return _id == other._id;
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TransactionLineItem) obj);
        }


        public override int GetHashCode()
        {
            return _id;
        }

    }
}