namespace MatrixChallengePos.Models
{
    public class Employee : Person
    {
        private int _id;
        private string _hashedPassword;
        private string _salt;


        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string HashedPassword
        {
            get => _hashedPassword;
            set => _hashedPassword = value;
        }

        public string Salt
        {
            get => _salt;
            set => _salt = value;
        }
    }
}