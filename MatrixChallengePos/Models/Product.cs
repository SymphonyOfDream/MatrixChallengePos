namespace MatrixChallengePos.Models
{
    public class Product
    {
        private int _id;
        private string _sku;
        private string _name;
        private string _description;
        private ProductCategory _productCategory;
        private decimal _wholesalePrice;
        private decimal _retailPrice;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Sku
        {
            get => _sku;
            set => _sku = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public ProductCategory ProductCategory
        {
            get => _productCategory;
            set => _productCategory = value;
        }

        public decimal WholesalePrice
        {
            get => _wholesalePrice;
            set => _wholesalePrice = value;
        }

        public decimal RetailPrice
        {
            get => _retailPrice;
            set => _retailPrice = value;
        }
    }
}