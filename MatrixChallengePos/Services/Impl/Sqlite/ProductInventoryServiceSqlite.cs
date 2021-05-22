using System;
using MatrixChallengePos.Models;
using Microsoft.Data.Sqlite;

namespace MatrixChallengePos.Services.Impl.Sqlite
{
    /// <summary>
    /// Implements the IProductInventoryService functionality against a SQLite database.
    /// </summary>
    public class ProductInventoryServiceSqlite : IProductInventoryService
    {
        private readonly IProductService _productService;


        public ProductInventoryServiceSqlite(IProductService productService)
        {
            _productService = productService;
        }


        ///<inheritdoc/>
        public void Insert(ProductInventory item)
        {
            if (item == null)
                throw new Exception("Address is null");

            if (item.Product == null)
                throw new Exception("ProductInventory has no product associated with it, insert failed");

            if (item.Product.Id < 1)
            {
                _productService.Insert(item.Product);
            }

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                INSERT INTO ProductInventory (product_id, quantity_val) 
                VALUES ($productId, $quantity);
                ";
            command.Parameters.AddWithValue("$productId", item.Product.Id);
            command.Parameters.AddWithValue("$quantity", item.Quantity);

            var updateCount = command.ExecuteNonQuery();
            if (updateCount == 0)
                throw new Exception("ProductInventory insert failed.");
        }


        ///<inheritdoc/>
        public ProductInventory Get(int id)
        {
            if (id < 1)
                return null;

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                SELECT product_id, quantity_val
                FROM ProductInventory
                WHERE product_id = $id;
                ";
            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            // address_id is the PK, so will either return a single record or none
            if (reader.Read())
            {
                var productId = reader.GetInt32(0);

                return new ProductInventory()
                {
                    Product = _productService.Get(productId),
                    Quantity = reader.GetInt32(1)
                };
            }

            return null;
        }


        ///<inheritdoc/>
        public void Update(ProductInventory item)
        {
            if (item == null)
                throw new Exception("ProductInventory is null");

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                UPDATE ProductInventory
                SET quantity_val = $quantity
                WHERE product_id = $id;
                ";
            command.Parameters.AddWithValue("$quantity", item.Quantity);
            command.Parameters.AddWithValue("$id", item.Product.Id);

            var updateCount = command.ExecuteNonQuery();
            if (updateCount == 0)
                throw new Exception("ProductInventory update failed.");
        }


        ///<inheritdoc/>
        public void Delete(ProductInventory item)
        {
            if (item == null)
                throw new Exception("ProductInventory is null");

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                DELETE FROM ProductInventory
                WHERE product_id = $id;
                ";
            command.Parameters.AddWithValue("$id", item.Product.Id);

            var deleteCount = command.ExecuteNonQuery();
            if (deleteCount == 0)
                throw new Exception("ProductInventory deletion failed.");
        }

    }
}