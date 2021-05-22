using System.Data.Common;
using Microsoft.Data.Sqlite;

namespace MatrixChallengePos.Services.Impl.Sqlite
{
    public class DbServiceSqlite : IDbService
    {
        private static DbServiceSqlite _instance = null;
        private static readonly object _lock = new object();

        private readonly SqliteConnection _sqliteConnection;


        private DbServiceSqlite()
        {
            _sqliteConnection = new SqliteConnection(@"Data Source=C:\Users\davel\source\repos\MatrixChallengePos\SqliteDataSource\MatrixChallengePos.sqlite");
            _sqliteConnection.Open();

#if DEBUG
            SetupDb();
#endif
        }


        public static DbServiceSqlite Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DbServiceSqlite();
                        }
                    }
                }

                return _instance;
            }
        }

        ///<inheritdoc/>
        public DbConnection SqlConnection => _sqliteConnection;


#if DEBUG
        private void SetupDb()
        {
            bool hasData = false;
            using (var command = _sqliteConnection.CreateCommand())
            {
                command.CommandText = "SELECT EXISTS (SELECT 1 FROM People)";
                var val = command.ExecuteScalar();
                hasData = (int)(long) command.ExecuteScalar() > 0;
            }

            if (!hasData)
                PopulateTestData();
        }

        /// <summary>
        /// Ugly hack for now just to get demo system running
        /// </summary>
        private void PopulateTestData()
        {
            using var command = _sqliteConnection.CreateCommand();

            // All test data is fake and represents no known person/address/etc.
            command.CommandText =
                @"
                    INSERT INTO Addresses (street1_tx, city_tx, state_id, zip_tx)
                    VALUES
                      ('111 1st St TEST', 'First City TEST', 'OH', '11111')
                    , ('222 2nd Rd TEST', 'Second City TEST', 'OH', '22222')
                    , ('333 3rd Ct TEST', 'Third City TEST', 'OH', '33333')
                    , ('444 4th Ave TEST', 'Fourth City TEST', 'OH', '44444')
                    , ('555 5th St TEST', 'Fifth City TEST', 'OH', '55555')
                    , ('666 6th Rd TEST', 'Sixth City TEST', 'OH', '66666')
                    , ('777 7th Ct TEST', 'Seventh City TEST', 'OH', '77777')
                    , ('888 8th Ave TEST', 'Eight City TEST', 'OH', '88888')
                    , ('999 9th St TEST', 'Ninth City TEST', 'OH', '99999')
                    , ('1010 10th Ct TEST', 'Tenth City TEST', 'OH', '10101');
                ";
            command.ExecuteNonQuery();

            command.CommandText =
                @"
                    INSERT INTO People (first_name_tx, last_name_tx, middle_name_tx, email_tx, home_phone_tx, cell_phone_tx, address_id)
                    VALUES
                      ('DinahTEST', 'LashbrookTEST', null, 'dlashbrook@TEST.com', null, null, 1)
                    , ('LouanneTEST', 'FaireyTEST', null, 'lfairey@TEST.com', null, null, 2)
                    , ('MurrayTEST', 'KeelTEST', null, 'mkeel@TEST.com', null, null, 3)
                    , ('CarlenaTEST', 'SiegleTEST', null, 'csiegle@TEST.com', null, null, 4)
                    , ('PaulTEST', 'VoganTEST', null, 'pvogan@TEST.com', null, null, 5)
                    , ('RobbynTEST', 'CanasTEST', null, 'rcanas@TEST.com', null, null, 6)
                    , ('JeroldTEST', 'BlackTEST', null, 'jblack@TEST.com', null, null, 7)
                    , ('AlecTEST', 'WeeklyTEST', null, 'aweekly@TEST.com', null, null, 8)
                    , ('ErasmoTEST', 'ArangoTEST', null, 'earango@TEST.com', null, null, 9)
                    , ('OtisTEST', 'SilversteinTEST', null, 'osilverstein@TEST.com', null, null, 10);
                ";
            command.ExecuteNonQuery();

            // Cleartext Passwords are, in order, 'aaa', 'bbb', 'ccc', 'ddd'
            command.CommandText =
                @"
                    INSERT INTO Employees (person_id, hashed_password_tx, salt_tx)
                    VALUES
                      (1, 'ikvad5WmPyKuXVAzU+tF13bmuaXnYzkiS63PMfqaB4pY6iE9mrEiNJ4Ek0O7SXTCmJM=', 'Qssqmz/7WJAa+Ioa0xEImQ==')
                    , (2, '0vW7tzE8bcWdX4CHoSnp3qO5O7UIGPpAL2NHxOlvGPZ4kTpdihLp0Jx9KYBp1P1mbMM=', 'xGpxG9LG8VY1oB0smVzs4A==')
                    , (3, 'zxvAlUtN0Nq//zbQmluXbsWXa3sMZiFtqZ26XW/Y9pBcLi3LNl62apE0kJqukA+zoH4=', 'TGWOLjTlQEKoEsThNKnnrg==')
                    , (4, '12iFDF/zMptbFYi/vgyMQn1iBOfPBzbcIpjhi+WQbm/2UGCi1h7Qx+spx/Cir8g1D0A=', 'aeqmK6CK34/viC13yfjmSA==');
                ";
            command.ExecuteNonQuery();

            command.CommandText =
                @"
                    INSERT INTO Customers (person_id)
                    VALUES
                      (5)
                    , (6)
                    , (7)
                    , (8)
                    , (9)
                    , (10);
                ";
            command.ExecuteNonQuery();

            command.CommandText =
                @"
                    INSERT INTO ProductCategories (name_tx)
                    VALUES
                      ('Produce')
                    , ('Snacks')
                    , ('OfficeEquipment')
                    , ('ElectronicEquipment')
                    , ('ElectronicGames')
                    , ('Books')
                    , ('Magazines');
                ";
            command.ExecuteNonQuery();

            command.CommandText =
                @"
                    INSERT INTO Products (sku_tx, name_tx, description_tx, product_category_id, wholesale_price_val, retail_price_val)
                    VALUES
                      ('TEST SKU1',  'Banana', 'Organic banana', 1, 0.25, 0.35)
                    , ('TEST SKU2',  'Orange', 'Florida orange', 1, 0.50, 0.75)
                    , ('TEST SKU3',  'Corn Chips', 'Quality ingredients', 2, 1.00, 2.50)
                    , ('TEST SKU4',  'Potato Chips', 'Cannot eat just one', 2, 1.00, 2.75)
                    , ('TEST SKU5',  'Pencil', 'For the olde fashioned ones', 3, 0.10, 0.25)
                    , ('TEST SKU6',  'Pen', 'For the slightly less olde fashioned ones', 3, 0.25, 0.50)
                    , ('TEST SKU7',  'Mad Magazine', 'Blast from the past', 7, 2.00, 3.50)
                    , ('TEST SKU8',  'A Taste of Home', 'My life now', 7, 3.00, 5.75)
                    , ('TEST SKU9',  'Walkman', 'Cassette tapes while you walk', 4, 25.00, 35.00)
                    , ('TEST SKU10', 'Discman', 'Disc music', 4, 35.00, 45.00)
                    , ('TEST SKU11', 'Nintendo Wii', 'Wii best Console', 5, 100.00, 200.00)
                    , ('TEST SKU12', 'Microsoft XBox One', 'No, XBox best Console', 5, 75.00, 175.00)
                ";
            command.ExecuteNonQuery();

            command.CommandText =
                @"
                    INSERT INTO ProductInventory (product_id, quantity_val)
                    VALUES
                      (1, 150)
                    , (2, 75)
                    , (3, 100)
                    , (4, 100)
                    , (5, 25)
                    , (6, 35)
                    , (7, 4)
                    , (8, 5)
                    , (9, 3)
                    , (10, 6)
                    , (11, 2)
                    , (12, 14);
                ";
            command.ExecuteNonQuery();
        }
#endif

    }
}
