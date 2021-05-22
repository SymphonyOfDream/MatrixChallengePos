using System;
using MatrixChallengePos.Models;
using Microsoft.Data.Sqlite;

namespace MatrixChallengePos.Services.Impl.Sqlite
{
    /// <summary>
    /// Implements the IAddressService functionality against a SQLite database.
    /// </summary>
    public class AddressServiceSqlite : IAddressService
    {
        ///<inheritdoc/>
        public void Insert(Address item)
        {
            if (item == null)
                throw new Exception("Address is null");

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                INSERT INTO Addresses (street1_tx, street2_tx, city_tx, state_id, zip_tx) 
                VALUES ($street1, $street2, $city, $state, $zip) 
                RETURNING address_id;
                ";
            command.Parameters.AddWithValue("$street1", item.Street1);
            command.Parameters.AddWithValue("$street2", item.Street2);
            command.Parameters.AddWithValue("$city", item.City);
            command.Parameters.AddWithValue("$state", item.StateId);
            command.Parameters.AddWithValue("$zip", item.Zip);

            var newId = command.ExecuteScalar();

            item.Id = (int)(long)newId;
        }


        ///<inheritdoc/>
        public Address Get(int id)
        {
            if (id < 1)
                return null;

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                SELECT street1_tx, street2_tx, city_tx, state_id, zip_tx
                FROM Addresses
                WHERE address_id = $id;
                ";
            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            // address_id is the PK, so will either return a single record or none
            if (reader.Read())
            {
                return new Address()
                {
                    Id = id,
                    Street1 = reader.IsDBNull(0) ? null : reader.GetString(0),
                    Street2 = reader.IsDBNull(1) ? null : reader.GetString(1),
                    City = reader.IsDBNull(2) ? null : reader.GetString(2),
                    StateId = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Zip = reader.IsDBNull(4) ? null : reader.GetString(4)
                };
            }

            return null;
        }


        ///<inheritdoc/>
        public void Update(Address item)
        {
            if (item == null)
                throw new Exception("Address is null");

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                UPDATE Addresses
                SET street1_tx = $street1, 
                    street2_tx = $street2, 
                    city_tx = $city, 
                    state_id = $state, 
                    zip_tx = $zip
                WHERE address_id = $id;
                ";
            command.Parameters.AddWithValue("$street1", item.Street1);
            command.Parameters.AddWithValue("$street2", item.Street2);
            command.Parameters.AddWithValue("$city", item.City);
            command.Parameters.AddWithValue("$state", item.StateId);
            command.Parameters.AddWithValue("$zip", item.Zip);
            command.Parameters.AddWithValue("$id", item.Id);

            var updateCount = command.ExecuteNonQuery();
            if (updateCount == 0)
                throw new Exception("Address update failed.");
        }


        ///<inheritdoc/>
        public void Delete(Address item)
        {
            if (item == null)
                throw new Exception("Address is null");

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                DELETE FROM Addresses
                WHERE address_id = $id;
                ";
            command.Parameters.AddWithValue("$id", item.Id);

            var deleteCount = command.ExecuteNonQuery();
            if (deleteCount == 0)
                throw new Exception("Address deletion failed.");
        }

    }
}