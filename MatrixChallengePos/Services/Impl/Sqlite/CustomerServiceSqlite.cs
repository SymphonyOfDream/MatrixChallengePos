using System;
using MatrixChallengePos.Models;
using Microsoft.Data.Sqlite;

namespace MatrixChallengePos.Services.Impl.Sqlite
{
    /// <summary>
    /// Implements the ICustomerService functionality against a SQLite database.
    /// </summary>
    public class CustomerServiceSqlite : ICustomerService
    {
        private readonly IAddressService _addressService;
        private readonly IPersonService _personService;

        public CustomerServiceSqlite(IAddressService addressService, IPersonService personService)
        {
            _personService = personService;
            _addressService = addressService;
        }


        ///<inheritdoc/>
        public void Insert(Customer item)
        {
            if (item == null)
                throw new Exception("Customer is null");

            if (item.PersonId < 1)
            {
                _personService.Insert(item);
            }

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                INSERT INTO Customers (person_id) 
                VALUES ($personId) 
                RETURNING customer_id;
                ";
            command.Parameters.AddWithValue("$personId", item.PersonId);

            var newId = command.ExecuteScalar();

            if (newId != null)
            {
                item.Id = (int) (long) newId;
            }
            else
            {
                throw new Exception("Customer insertion failed");
            }
        }


        ///<inheritdoc/>
        public Customer Get(int id)
        {
            if (id < 1)
                return null;

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                SELECT c.person_id,
                       p.first_name_tx,
                       p.last_name_tx,
                       p.middle_name_tx,
                       p.email_tx,
                       p.home_phone_tx,
                       p.cell_phone_tx,
                       p.address_id
                FROM Customers c
                    JOIN People p
                      ON p.person_id = c.person_id
                WHERE c.customer_id = $id;
                ";
            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            // customer_id is the PK, so will either return a single record or none
            if (reader.Read())
            {
                var newCustomer = new Customer()
                {
                    Id = id,
                    PersonId = reader.GetInt32(0),
                    FirstName = reader.IsDBNull(1) ? null : reader.GetString(1),
                    LastName = reader.IsDBNull(2) ? null : reader.GetString(2),
                    MiddleName = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Email = reader.IsDBNull(4) ? null : reader.GetString(4),
                    HomePhone = reader.IsDBNull(5) ? null : reader.GetString(5),
                    CellPhone = reader.IsDBNull(6) ? null : reader.GetString(6),
                };

                var addressId = reader.GetInt32(7);
                newCustomer.Address = _addressService.Get(addressId);

                return newCustomer;
            }

            return null;
        }


        ///<inheritdoc/>
        public void Update(Customer item)
        {
            if (item == null)
                throw new Exception("Customer is null");

            _personService.Update(item);
        }


        ///<inheritdoc/>
        public void Delete(Customer item)
        {
            if (item == null)
                throw new Exception("Customer is null");

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                DELETE FROM Customers
                WHERE customer_id = $id;
                ";
            command.Parameters.AddWithValue("$id", item.Id);

            var deleteCount = command.ExecuteNonQuery();
            if (deleteCount == 0)
                throw new Exception("Customer deletion failed.");
        }
    }
}