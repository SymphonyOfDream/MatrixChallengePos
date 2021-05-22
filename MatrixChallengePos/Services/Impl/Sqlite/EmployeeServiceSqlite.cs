using System;
using MatrixChallengePos.Models;
using Microsoft.Data.Sqlite;

namespace MatrixChallengePos.Services.Impl.Sqlite
{
    /// <summary>
    /// Implements the IEmployeeService functionality against a SQLite database.
    /// </summary>
    public class EmployeeServiceSqlite : IEmployeeService
    {
        private readonly IAddressService _addressService;
        private readonly IPersonService _personService;

        public EmployeeServiceSqlite(IAddressService addressService, IPersonService personService)
        {
            _personService = personService;
            _addressService = addressService;
        }


        ///<inheritdoc/>
        public void Insert(Employee item)
        {
            if (item == null)
                throw new Exception("Employee is null");


            if (item.PersonId < 1)
            {
                _personService.Insert(item);
            }
            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                INSERT INTO Employees (person_id, hashed_password_tx, salt_tx) 
                VALUES ($personId, $hashedPassword, $salt) 
                RETURNING employee_id;
                ";
            command.Parameters.AddWithValue("$personId", item.PersonId);
            command.Parameters.AddWithValue("$hashedPassword", item.HashedPassword);
            command.Parameters.AddWithValue("$salt", item.Salt);

            var newId = command.ExecuteScalar();

            if (newId != null)
            {
                item.Id = (int)(long)newId;
            }
            else
            {
                throw new Exception("Employee insertion failed");
            }
        }


        ///<inheritdoc/>
        public Employee Get(int id)
        {
            if (id < 1)
                return null;

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                SELECT e.person_id,
                       e.hashed_password_tx,
                       e.salt_tx,
                       p.first_name_tx,
                       p.last_name_tx,
                       p.middle_name_tx,
                       p.email_tx,
                       p.home_phone_tx,
                       p.cell_phone_tx,
                       p.address_id
                FROM Employees e
                    JOIN People p
                      ON p.person_id = e.person_id
                WHERE e.employee_id = $id;
                ";
            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            // employee_id is the PK, so will either return a single record or none
            if (reader.Read())
            {
                // We no longer need the HashedPassword and Salt data, so we do not
                // put those values in the new Employee object.
                var newEmployee = new Employee()
                {
                    Id = id,
                    PersonId = reader.GetInt32(0),
                    FirstName = reader.IsDBNull(3) ? null : reader.GetString(3),
                    LastName = reader.IsDBNull(4) ? null : reader.GetString(4),
                    MiddleName = reader.IsDBNull(5) ? null : reader.GetString(5),
                    Email = reader.IsDBNull(6) ? null : reader.GetString(6),
                    HomePhone = reader.IsDBNull(7) ? null : reader.GetString(7),
                    CellPhone = reader.IsDBNull(8) ? null : reader.GetString(8),
                };

                var addressId = reader.GetInt32(9);
                newEmployee.Address = _addressService.Get(addressId);

                return newEmployee;
            }

            return null;
        }

        ///<inheritdoc/>
        public void Update(Employee item)
        {
            if (item == null)
                throw new Exception("Employee is null");

            _personService.Update(item);

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                UPDATE Employees
                SET hashed_password_tx = $hashedPassword,
                    salt_tx = $salt
                WHERE employee_id = $id;
                ";
            command.Parameters.AddWithValue("$hashedPassword", item.HashedPassword);
            command.Parameters.AddWithValue("$salt", item.Salt);
            command.Parameters.AddWithValue("$id", item.Id);

            var updateCount = command.ExecuteNonQuery();
            if (updateCount == 0)
                throw new Exception("Employee update failed.");
        }


        ///<inheritdoc/>
        public void Delete(Employee item)
        {
            if (item == null)
                throw new Exception("Employee is null");

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                DELETE FROM Employees
                WHERE employee_id = $id;
                ";
            command.Parameters.AddWithValue("$id", item.Id);

            var deleteCount = command.ExecuteNonQuery();
            if (deleteCount == 0)
                throw new Exception("Employee deletion failed.");
        }
    }
}