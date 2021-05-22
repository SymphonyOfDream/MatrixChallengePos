namespace MatrixChallengePos.Models
{
    /// <summary>
    /// Represents how much of a product the store should have.
    /// </summary>
    /// <remarks>Not used for this iteration of the code.</remarks>
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