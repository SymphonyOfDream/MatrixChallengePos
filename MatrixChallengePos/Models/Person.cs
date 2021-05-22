using System;

namespace MatrixChallengePos.Models
{
    /// <summary>
    /// Represents a person.
    /// </summary>
    public class Person
    {
        private int _personId;
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private string _email;
        private string _homePhone;
        private string _cellPhone;
        private Address _address;

        public int PersonId
        {
            get => _personId;
            set => _personId = value;
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public string MiddleName
        {
            get => _middleName;
            set => _middleName = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string HomePhone
        {
            get => _homePhone;
            set => _homePhone = value;
        }

        public string CellPhone
        {
            get => _cellPhone;
            set => _cellPhone = value;
        }

        public Address Address
        {
            get => _address;
            set => _address = value;
        }
    }
}