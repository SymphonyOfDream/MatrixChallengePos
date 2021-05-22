using System;

namespace MatrixChallengePos.Models
{
    /// <summary>
    /// Represents the category a product can belong to.
    /// </summary>
    public class ProductCategory
    {
        private int _id;
        private string _name;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }


        public override string ToString()
        {
            return _name;
        }
    }

}