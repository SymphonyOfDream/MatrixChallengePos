namespace MatrixChallengePos.Models
{
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