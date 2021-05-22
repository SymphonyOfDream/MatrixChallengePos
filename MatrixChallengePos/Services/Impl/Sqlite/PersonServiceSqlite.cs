using System;
using MatrixChallengePos.Models;
using Microsoft.Data.Sqlite;

namespace MatrixChallengePos.Services.Impl.Sqlite
{
    /// <summary>
    /// Implements the IPersonService functionality against a SQLite database.
    /// </summary>
    public class PersonServiceSqlite : IPersonService
    {
        private readonly IAddressService _addressService;


        public PersonServiceSqlite(IAddressService addressService)
        {
            _addressService = addressService;
        }


        ///<inheritdoc/>
        public void Insert(Person item)
        {
            if (item == null)
                throw new Exception("Person is null");

            if (item.Address != null && item.Address.Id < 1)
            {
                _addressService.Insert(item.Address);
            }

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                INSERT INTO People (first_name_tx, last_name_tx, middle_name_tx, email_tx, home_phone_tx, cell_phone_tx, address_id) 
                VALUES ($firstName, $lastName, $middleName, $email, $homePhone, $cellPhone, $addressId);
                ";
            command.Parameters.AddWithValue("$firstName", item.FirstName);
            command.Parameters.AddWithValue("$lastName", item.LastName);
            command.Parameters.AddWithValue("$middleName", item.MiddleName);
            command.Parameters.AddWithValue("$email", item.Email);
            command.Parameters.AddWithValue("$homePhone", item.HomePhone);
            command.Parameters.AddWithValue("$cellPhone", item.CellPhone);
            if (item.Address != null)
            {
                command.Parameters.AddWithValue("$addressId", item.Address.Id);
            }
            else
            {
                command.Parameters.AddWithValue("$addressId", null);
            }

            var newId = command.ExecuteScalar();

            if (newId != null)
            {
                item.PersonId = (int)(long)newId;
            }
            else
            {
                throw new Exception("Person insertion failed");
            }
        }


        ///<inheritdoc/>
        public Person Get(int id)
        {
            if (id < 1)
                return null;

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                SELECT person_id,
                       first_name_tx,
                       last_name_tx,
                       middle_name_tx,
                       email_tx,
                       home_phone_tx,
                       cell_phone_tx,
                       address_id
                FROM People
                WHERE person_id = $id;
                ";
            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            // person_id is the PK, so will either return a single record or none
            if (reader.Read())
            {
                var newPerson = new Person()
                {
                    PersonId = reader.GetInt32(0),
                    FirstName = reader.IsDBNull(1) ? null : reader.GetString(1),
                    LastName = reader.IsDBNull(2) ? null : reader.GetString(2),
                    MiddleName = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Email = reader.IsDBNull(4) ? null : reader.GetString(4),
                    HomePhone = reader.IsDBNull(5) ? null : reader.GetString(5),
                    CellPhone = reader.IsDBNull(6) ? null : reader.GetString(6),
                };

                var addressId = reader.GetInt32(7);
                newPerson.Address = _addressService.Get(addressId);

                return newPerson;
            }

            return null;
        }


        ///<inheritdoc/>
        public void Update(Person item)
        {
            if (item == null)
                throw new Exception("Person is null");

            // In case person is at an entirely new address
            if (item.Address.Id < 1)
            {
                _addressService.Insert(item.Address);
            }
            else
            {
                _addressService.Update(item.Address);
            }

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                UPDATE People
                SET first_name_tx = $firstName, 
                    last_name_tx = $lastName, 
                    middle_name_tx = $middleName, 
                    email_tx = $email, 
                    home_phone_tx = $homePhone, 
                    cell_phone_tx = $cellPhone, 
                    address_id = $addressId
                WHERE person_id = $id;
                ";
            command.Parameters.AddWithValue("$firstName", item.FirstName);
            command.Parameters.AddWithValue("$lastName", item.LastName);
            command.Parameters.AddWithValue("$middleName", item.MiddleName);
            command.Parameters.AddWithValue("$email", item.Email);
            command.Parameters.AddWithValue("$homePhone", item.HomePhone);
            command.Parameters.AddWithValue("$cellPhone", item.CellPhone);
            command.Parameters.AddWithValue("$addressId", item.Address.Id);
            command.Parameters.AddWithValue("$id", item.PersonId);

            var updateCount = command.ExecuteNonQuery();
            if (updateCount == 0)
                throw new Exception("Address update failed.");
        }
        

        ///<inheritdoc/>
        public void Delete(Person item)
        {
            if (item == null)
                throw new Exception("Person is null");

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                DELETE FROM People
                WHERE person_id = $id;
                ";
            command.Parameters.AddWithValue("$id", item.PersonId);

            var deleteCount = command.ExecuteNonQuery();
            if (deleteCount == 0)
                throw new Exception("Person deletion failed.");
        }

    }
}