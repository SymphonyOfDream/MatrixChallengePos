namespace MatrixChallengePos.Models
{
    /// <summary>
    /// A single, unique address.
    /// </summary>
    public class Address
    {
        private int _id;
        private string _street1;
        private string _street2;
        private string _city;
        private string _stateId;
        private string _zip;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Street1
        {
            get => _street1;
            set => _street1 = value;
        }

        public string Street2
        {
            get => _street2;
            set => _street2 = value;
        }

        public string City
        {
            get => _city;
            set => _city = value;
        }

        public string StateId
        {
            get => _stateId;
            set => _stateId = value;
        }

        public string Zip
        {
            get => _zip;
            set => _zip = value;
        }
    }
}