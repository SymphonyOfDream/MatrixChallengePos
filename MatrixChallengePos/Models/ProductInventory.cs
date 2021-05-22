namespace MatrixChallengePos.Models
{
    public class ProductInventory
    {
        private Product _product;
        private int _quantity;

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
    }
}