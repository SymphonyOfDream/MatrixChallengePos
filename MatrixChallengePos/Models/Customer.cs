namespace MatrixChallengePos.Models
{
    /// <summary>
    /// Represents a customer.
    /// </summary>
    /// <remarks>Not used in this iteration of the software.</remarks>
    public class Customer : Person
    {
        private int _id;

        public int Id
        {
            get => _id;
            set => _id = value;
        }
    }
}